using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using FunctionApp1.Model;

namespace FunctionApp1;

public static class HttpExample
{
    [FunctionName("HttpExample")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var pokemon = JsonConvert.DeserializeObject<BasicPokemon>(requestBody);
        var starter = new StarterPokemon(pokemon);
        var client = new HttpClient();
        var response = await client.PostAsJsonAsync(new Uri(StarterPokemon.ASSIGNED_STARTER_URL), starter);

        return new OkObjectResult(response);
    }
}
