using System;
using System.Collections.Generic;
using RestSharp;
namespace culqi.net
{
    public class Util
    {

        Config config = new Config();

        public Util()
        {
        }

        public String Request(Object model, string url, string api_key, string type_method, string custom_url_api_base = null)
        {

            var client = new RestClient(custom_url_api_base ?? config.url_api_base);

            RestSharp.RestRequest request = new RestRequest();

            if (type_method.Equals("get"))
            {
                request = new RestRequest(url, Method.GET);
                if (model != null)
                {
                    Dictionary<string, object> query_params = (Dictionary<string, object>)model;
                    foreach (KeyValuePair<string, object> entry in query_params)
                    {
                        request.AddParameter(entry.Key, entry.Value, ParameterType.QueryString);
                    }
                }
            }
            else if (type_method.Equals("delete"))
            {
                request = new RestRequest(url, Method.DELETE);
            }
            else if (type_method.Equals("post"))
            {
                request = new RestRequest(url, Method.POST);
                request.AddJsonBody(model);
            }
            else if (type_method.Equals("patch"))
            {
                request = new RestRequest(url, Method.PATCH);
                request.AddJsonBody(model);
            }

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + api_key);
            IRestResponse response = client.Execute(request);
            return response.Content;

        }

    }
}
