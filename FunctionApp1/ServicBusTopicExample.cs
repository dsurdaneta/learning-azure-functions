using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FunctionApp1;

public class ServicBusTopicExample
{
    private readonly ILogger<ServicBusTopicExample> _logger;

    public ServicBusTopicExample(ILogger<ServicBusTopicExample> log)
    {
        _logger = log;
    }

    [FunctionName("ServicBusTopicExample")]
    public async Task RunAsync([ServiceBusTrigger("mytopic", "mysubscription", Connection = "testConnectionString")]string mySbMsg)
    {
        _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

        var (response, pokemon) = await Helper.AssignStarter(mySbMsg);

        if (response is null)
        {
            _logger.LogError($"It was not possible to assing pokemon, received message: {mySbMsg}");
            return;
        }

        if (response.IsSuccessStatusCode)
            _logger.LogInformation($"{response.StatusCode} {pokemon.Name} succesfuly assigned as Starter Pokemon.");
        else
            _logger.LogWarning($"{response.StatusCode} {pokemon.Name} was not assigned as Starter.");
    }    
}
