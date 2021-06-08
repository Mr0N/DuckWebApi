using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DuckDuckWebApi.Services
{
    public class ConfigClient
    {
        public HttpClient Curent { get { return client; } }
        protected virtual void Start()
        {
            //this.client.DefaultRequestHeaders.Add("Accept", "*");
            //this.client.DefaultRequestHeaders.Add("Accept-Language", "*");

        }
        HttpClient client;
        public ConfigClient(HttpClient httpClient)
        {
            this.client = httpClient;
            this.Start();
        }
    }
}
