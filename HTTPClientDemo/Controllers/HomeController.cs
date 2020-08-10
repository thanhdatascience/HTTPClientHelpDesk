using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HTTPClientDemo.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
//using Newtonsoft.Json;

namespace HTTPClientDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private static HttpClient _httpClient = new HttpClient();
        public IEnumerable<Ticket> Tickets { get; set; }
        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<ActionResult<IEnumerable<Ticket>>> Index()
        {
            var url = "http://gn-helpdesk-dev.azurewebsites.net/api/ticket/";
            var request = new HttpRequestMessage(HttpMethod.Get,
                url);
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                Tickets = await JsonSerializer.DeserializeAsync
                    <IEnumerable<Ticket>>(responseStream);
            }
            else
            {
                Tickets = new List<Ticket>();
            }

            return Tickets.ToList();
        }

        public async Task<bool> HTTPPost()
        {
            var url = "http://gn-helpdesk-dev.azurewebsites.net/api/ticket/create";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
                return false;
        }
       
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
        
    }
}
