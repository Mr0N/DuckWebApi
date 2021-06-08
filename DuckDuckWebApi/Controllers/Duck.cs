using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Fizzler;
using Fizzler.Systems;
using Fizzler.Systems.HtmlAgilityPack;
using DuckDuckWebApi.Model;

namespace DuckDuckWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Duck : Controller
    {
        HttpClient client;
        public Duck(IHttpClientFactory factory)
        {
            this.client = factory.CreateClient("name");
        }
        [HttpGet]
        public async Task<Result<string>> Get(string query)
        {
            try
            {
                query = WebUtility.UrlEncode(query);
                string link = $"http://myseria.co/?do=search&subaction=search&story=" +
                     $"{query}";
                var response = await this.client.GetAsync(link);
                var html = await response.Content.ReadAsStringAsync();
                var node = HtmlNode.CreateNode(html ?? throw new Exception("Exception"));
                var result = node.QuerySelectorAll("div[class='item-search-header'] a")
                    .Select(a => a.InnerText)
                    .Select(a => WebUtility.HtmlDecode(a ?? ""));
                return new Result<string>(result);
            }
            catch (Exception ex)
            {
                return new Result<string>(ex.Message);
            }
        }
    }
}
