using FunctionApp1.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionApp1;

public class Helper
{
    internal static async Task<(HttpResponseMessage, BasicPokemon)> AssignStarter(string receivedMessage)
    {
        var pokemon = JsonConvert.DeserializeObject<BasicPokemon>(receivedMessage);
        var starter = new StarterPokemon(pokemon);
        var client = new HttpClient();
        var response = await client.PostAsJsonAsync(new Uri(StarterPokemon.ASSIGNED_STARTER_URL), starter);

        return (response, pokemon);
    }
}
