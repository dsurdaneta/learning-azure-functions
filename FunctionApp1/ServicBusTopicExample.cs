using System;
using FunctionApp1.Model;
using System.IO;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        var response = await Helper.AssignStarter(mySbMsg);

        //TODO process response
    }    
}
