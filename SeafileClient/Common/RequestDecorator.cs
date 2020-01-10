using RestSharp;
using SeafileClient.Common;
using SeafileClient.Common.Attributes;
using SeafileClient.Common.Converters;
using SeafileClient.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeafileClient
{
    struct HeaderInfo
    {
        public string Name;
        public string Template;
        public Tuple<string, int>[] ArgPositions;
    }
    struct ParamInfo
    {
        public string Name;
        public int ArgPosition;
        public bool IgnoreIfDefault;
        public object DefaultValue;
        public ISeafileValueConverter Converter;
    }
    struct PostInfo
    {
        public string Name;
        public int ArgPosition;
        public bool IsFile;
        public bool IgnoreIfDefault;
        public object DefaultValue;
        public ISeafileValueConverter Converter;
    }
    struct RestInfo
    {
        public Method HttpMethod;
        public string UrlTemplate;
        public bool IsAsync;
        public bool IsAbsoluteUrl;
        public HeaderInfo[] HeaderInfos;
        public PostInfo[] PostInfos;
        public ParamInfo[] QueryStringInfos;
        public ParamInfo[] UrlSegmentInfos;
    }
    struct DestructureInfo
    {
        public string Key;
        public Type Type;
        public PropertyInfo ItemsProp;
    }

    public class RequestDecorator<T> : DispatchProxy where T : IApi
    {
        private T _decorated;
        private RestClient restClient;
        private readonly Dictionary<string, RestInfo> methodMap = new Dictionary<string, RestInfo>();
        private readonly Dictionary<string, DestructureInfo> destructureMap = new Dictionary<string, DestructureInfo>();

        public virtual void BeforeRequest(RestRequest request, string methodName, object[] args)
        {
        }
        public virtual void AfterResponse(IRestResponse resp, string methodName, ref string content)
        {
            if (!(resp.StatusCode == HttpStatusCode.Created || resp.StatusCode == HttpStatusCode.OK))
            {
                return;
            }
            if (resp.Content == "\"success\"")
            {
                content = "true";
            }
            // Follow the seafile doc, `RenameDirectory` api only check the StatusCode, the content will be ignored.
            if (methodName == "RenameDirectory")
            {
                content = "true";
            }
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var result = methodMap.TryGetValue(targetMethod.Name, out var info);
            // Directly call original method if the method name is not in methodMap.
            if (!result)
            {
                return targetMethod.Invoke(_decorated, args);
            }

            // Start creating rest request.
            RestRequest request;
            // If UrlTemplate has only one urlSegment and urlSegment value is an absolute url, 
            // the rest request will send to the url directly without the `BaseUrl`.
            if (info.IsAbsoluteUrl && info.UrlSegmentInfos.Length == 1 && args[info.UrlSegmentInfos[0].ArgPosition].ToString().StartsWith("http"))
            {
                request = new RestRequest(new Uri(args[info.UrlSegmentInfos[0].ArgPosition].ToString()), info.HttpMethod);
            }
            else
            {
                request = new RestRequest(info.UrlTemplate, info.HttpMethod);
                FillUrlSegments(request, info, args);
            }

            FillHeaders(request, info, args);
            FillQueryStrings(request, info, args);
            FillPostBody(request, info, args);

            BeforeRequest(request, targetMethod.Name, args);

            if (info.IsAsync)
            {
                var resultType = targetMethod.ReturnType.GetGenericArguments()[0];
                return ResultTypedTaskFactory.Create(DeserializeResultAsync(restClient.ExecuteTaskAsync(request), targetMethod.Name, resultType), resultType);
            }
            else
            {
                var resp = restClient.Execute(request);
                return DeserializeResult(resp, targetMethod.Name, targetMethod.ReturnType);
            }
        }

        private void FillPostBody(RestRequest request, RestInfo info, object[] args)
        {
            if (info.PostInfos != null)
            {
                foreach (var p in info.PostInfos)
                {
                    if (p.IsFile)
                    {
                        if (args[p.ArgPosition] is IEnumerable<string>)
                        {
                            var files = args[p.ArgPosition] as IEnumerable<string>;
                            foreach (var file in files)
                            {
                                request.AddFile(p.Name, file);
                            }
                        }
                        else
                        {
                            request.AddFile(p.Name, args[p.ArgPosition].ToString());
                        }
                    }
                    else if (p.ArgPosition == -1)
                    {
                        var value = p.Converter != null ? p.Converter.Convert(p.DefaultValue) : p.DefaultValue;
                        request.AddParameter(p.Name, value.ToString());
                    }
                    else if (p.DefaultValue != args[p.ArgPosition] || !p.IgnoreIfDefault)
                    {
                        var value = args[p.ArgPosition];
                        if (p.Converter != null)
                        {
                            value = p.Converter.Convert(value);
                        }

                        if (value is IEnumerable<object>)
                        {
                            foreach (var v in value as IEnumerable<object>)
                            {
                                request.AddParameter(p.Name, v.ToString());
                            }
                        }
                        else
                        {
                            request.AddParameter(p.Name, value);
                        }
                    }
                }
            }
        }

        private void FillQueryStrings(RestRequest request, RestInfo info, object[] args)
        {
            if (info.QueryStringInfos != null)
            {
                foreach (var qs in info.QueryStringInfos)
                {
                    if (qs.ArgPosition == -1)
                    {
                        var value = qs.Converter != null ? qs.Converter.Convert(qs.DefaultValue) : qs.DefaultValue;
                        request.AddQueryParameter(qs.Name, value.ToString());
                    }
                    else if (qs.DefaultValue != args[qs.ArgPosition] || !qs.IgnoreIfDefault)
                    {
                        var value = args[qs.ArgPosition];
                        if (value is IEnumerable<object>)
                        {
                            foreach (var v in value as IEnumerable<object>)
                            {
                                request.AddParameter(qs.Name, v.ToString());
                            }
                        }
                        else
                        {
                            if (qs.Converter != null)
                            {
                                value = qs.Converter.Convert(value);
                            }
                            request.AddQueryParameter(qs.Name, value.ToString());
                        }
                    }
                }
            }

        }

        private void FillUrlSegments(RestRequest request, RestInfo info, object[] args)
        {
            if (info.UrlSegmentInfos != null)
            {
                foreach (var urlSegment in info.UrlSegmentInfos)
                {
                    request.AddUrlSegment(urlSegment.Name, args[urlSegment.ArgPosition]);
                }
            }
        }

        private void FillHeaders(RestRequest request, RestInfo info, object[] args)
        {
            if (info.HeaderInfos != null)
            {
                foreach (var headerInfo in info.HeaderInfos)
                {
                    var template = new string(headerInfo.Template);
                    foreach (var tuple in headerInfo.ArgPositions)
                    {
                        template = template.Replace(WrapWithVariableChars(tuple.Item1), args[tuple.Item2].ToString());
                    }
                    request.AddHeader(headerInfo.Name, template);
                }
            }
        }

        private async Task<object> DeserializeResultAsync(Task<IRestResponse> executeTask, string methodName, Type resultType)
        {
            var response = await executeTask.ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new SeafileException((int)response.ResponseStatus, response.ResponseStatus.ToString("G"));
            }
            var content = response.Content;
            AfterResponse(response, methodName, ref content);
            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.Accepted)
            {
                throw new SeafileException((int)response.StatusCode, content ?? response.StatusDescription);
            }
            return JsonSerializer.Deserialize(content, resultType);
        }

        private object DeserializeResult(IRestResponse response, string methodName, Type resultType)
        {

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new SeafileException((int)response.ResponseStatus, response.ResponseStatus.ToString("G"));
            }
            var content = response.Content;

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.Accepted)
            {
                throw new SeafileException((int)response.StatusCode, content ?? response.StatusDescription);
            }

            AfterResponse(response, methodName, ref content);
            var result = destructureMap.TryGetValue(methodName, out var destructureInfo);
            if (result)
            {
                var dict = JsonSerializer.Deserialize(content, destructureInfo.Type);
                return destructureInfo.ItemsProp.GetValue(dict, new object[] { destructureInfo.Key });
            }
            return JsonSerializer.Deserialize(content, resultType);
        }


        /// <summary>
        /// 创建一个代理实例
        /// </summary>
        /// <param name="decorated"></param>
        /// <returns></returns>
        public static T Create(T decorated)
        {
            object proxy = Create<T, RequestDecorator<T>>();
            (proxy as RequestDecorator<T>)?.Initialize(decorated);
            return (T)proxy;
        }

        private void Initialize(T decorated)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }

            _decorated = decorated;
            restClient = new RestClient(_decorated.ServiceRoot);

            // 以下的都是用来解析各种 Attribute，将信息存到 methodMap 里
            var headerAttributeType = typeof(RequestHeaderAttribute);
            var restAttributeType = typeof(RestAttribute);
            var forHeaderAttributeType = typeof(ForHeaderAttribute);
            var forQueryStringAttributeType = typeof(ForQueryStringAttribute);
            var forParameterAttributeType = typeof(ForParameterAttribute);
            var forUrlSegmentAttributeType = typeof(ForUrlSegmentAttribute);
            var destructAttributeType = typeof(DestructureAttribute);

            var methods = _decorated.GetType().GetMethods();
            foreach (var method in methods)
            {
                if (!(method.GetCustomAttribute<RestAttribute>() is RestAttribute restAttribute))
                {
                    continue;
                }

                var methodInfo = new RestInfo();
                methodInfo.HttpMethod = restAttribute.Method;
                methodInfo.UrlTemplate = restAttribute.Template;
                methodInfo.IsAbsoluteUrl = restAttribute.IsAbsoluteUrl;
                methodInfo.IsAsync = IsAsyncMethod(method);

                var headerAttributes = method.GetCustomAttributes<RequestHeaderAttribute>();
                var parameterInfos = method.GetParameters();
                if (headerAttributes.Any())
                {
                    methodInfo.HeaderInfos = headerAttributes.Select(
                        h => new HeaderInfo
                        {
                            Name = h.Key,
                            Template = h.ValueTemplate,
                            ArgPositions = ParseRouteFormat(h.ValueTemplate).Select(
                                s => parameterInfos.Where(pi => pi.Name == s).First()
                            ).Select(pi => new Tuple<string, int>(pi.Name, pi.Position)).ToArray()
                        }
                    ).ToArray();
                }

                var i = 0;
                var paramInfos = new List<ParamInfo>();
                var postInfos = new List<PostInfo>();
                var urlSegmentInfos = new List<ParamInfo>();

                var methodPostInfos = method.GetCustomAttributes<ForParameterAttribute>();
                if (methodPostInfos != null && methodPostInfos.Any())
                {
                    foreach (var pp in methodPostInfos)
                    {
                        postInfos.Add(new PostInfo
                        {
                            Name = pp.Name,
                            ArgPosition = -1,
                            IsFile = false,
                            IgnoreIfDefault = false,
                            DefaultValue = pp.Value,
                            Converter = pp.ConverterType != null ? Activator.CreateInstance(pp.ConverterType) as ISeafileValueConverter : null
                        });
                    }
                }

                var methodParamInfos = method.GetCustomAttributes<ForQueryStringAttribute>();
                if (methodParamInfos != null && methodParamInfos.Any())
                {
                    foreach (var p in methodParamInfos)
                    {
                        paramInfos.Add(new ParamInfo
                        {
                            Name = p.Name,
                            ArgPosition = -1,
                            IgnoreIfDefault = false,
                            DefaultValue = p.Value,
                            Converter = p.ConverterType != null ? Activator.CreateInstance(p.ConverterType) as ISeafileValueConverter : null
                        });
                    }
                }

                foreach (var pi in parameterInfos)
                {

                    if (pi.GetCustomAttribute(forParameterAttributeType) is ForParameterAttribute pp)
                    {
                        postInfos.Add(new PostInfo
                        {
                            Name = pp.Name ?? pi.Name,
                            ArgPosition = i,
                            IsFile = pp.IsFile,
                            IgnoreIfDefault = pp.IgnoreIfDefault,
                            DefaultValue = pi.DefaultValue,
                            Converter = pp.ConverterType != null ? Activator.CreateInstance(pp.ConverterType) as ISeafileValueConverter : null
                        });
                    }

                    if (pi.GetCustomAttribute(forQueryStringAttributeType) is ForQueryStringAttribute pq)
                    {

                        paramInfos.Add(new ParamInfo
                        {
                            Name = pq.Name ?? pi.Name,
                            ArgPosition = i,
                            IgnoreIfDefault = pq.IgnoreIfDefault,
                            DefaultValue = pi.DefaultValue,
                            Converter = pq.ConverterType != null ? Activator.CreateInstance(pq.ConverterType) as ISeafileValueConverter : null
                        }); ;
                    }

                    if (pi.GetCustomAttribute(forUrlSegmentAttributeType) is ForUrlSegmentAttribute pu)
                    {
                        urlSegmentInfos.Add(new ParamInfo
                        {
                            Name = pu.Name ?? pi.Name,
                            ArgPosition = i
                        });
                    }
                    i++;
                }

                methodInfo.PostInfos = postInfos.ToArray();
                methodInfo.QueryStringInfos = paramInfos.ToArray();
                methodInfo.UrlSegmentInfos = urlSegmentInfos.ToArray();
                methodMap.Add(method.Name, methodInfo);

                var destructureAttribute = method.GetCustomAttribute(destructAttributeType) as DestructureAttribute;
                if (destructureAttribute != null)
                {

                    var dictType = typeof(Dictionary<,>);
                    Type[] types = { typeof(string), method.ReturnType };
                    var tempType = dictType.MakeGenericType(types);
                    var propertyInfo = tempType.GetProperty("Item");

                    destructureMap.Add(method.Name, new DestructureInfo
                    {
                        Key = destructureAttribute.Key,
                        Type = tempType,
                        ItemsProp = propertyInfo
                    });
                }
            }
        }

        private static bool IsAsyncMethod(MethodInfo method)
        {
            Type attType = typeof(AsyncStateMachineAttribute);
            var attrib = (AsyncStateMachineAttribute)method.GetCustomAttribute(attType);
            return (attrib != null);
        }

        private static IEnumerable<string> ParseRouteFormat(string template)
        {
            var variableList = new List<string>();
            var matchCollection = Regex.Matches(template, @"[{].+?[}]", RegexOptions.IgnoreCase);

            foreach (var match in matchCollection)
            {
                variableList.Add(RemoteVariableChars(match.ToString()));
            }

            return variableList as IEnumerable<string>;
        }

        private static string RemoteVariableChars(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            string result = new string(input);
            result = result.Replace("{", string.Empty).Replace("}", string.Empty);
            return result;
        }

        private static string WrapWithVariableChars(string input)
        {
            return string.Format("{{{0}}}", input);
        }
    }
    internal static class ResultTypedTaskFactory
    {
        public static object Create(Task<object> task, Type resultType)
        {
            var genericType = typeof(TaskInvoker<>).MakeGenericType(resultType);
            var taskGetter = (ITaskGetter)Activator.CreateInstance(genericType, task);
            return taskGetter.ResultTypedTask;
        }

        private interface ITaskGetter
        {
            object ResultTypedTask { get; }
        }

        private sealed class TaskInvoker<TResult> : ITaskGetter
        {
            public object ResultTypedTask { get; }

            public TaskInvoker(Task<object> task)
            {
                ResultTypedTask = InvokeAsync();

                async Task<TResult> InvokeAsync()
                {
                    return (TResult)(await task.ConfigureAwait(false))!;
                }
            }
        }
    }
}