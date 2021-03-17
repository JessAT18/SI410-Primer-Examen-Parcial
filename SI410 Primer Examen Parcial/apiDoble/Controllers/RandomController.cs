using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Messaging.ServiceBus;

using Random = apiDoble.Models.Random;

namespace apiDoble.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Random myRandomNumber)
        {
            string connectionStringPar = "Endpoint=sb://queueparcial1jess.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=wjH4SnwrswZkHgBs2sIgTOxK2UorUE1z8Z46yO/8gu4=;EntityPath=qpar";
            string connectionStringImpar = "Endpoint=sb://queueparcial1jess.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=vKYqivE+lLnVGc+sSot5FxgCWD+QerA+v/c1CnyCSqg=;EntityPath=qimpar";
            string queueNamePar = "qpar";
            string queueNameImpar = "qimpar";
            string mensaje = JsonConvert.SerializeObject(myRandomNumber);

            if (myRandomNumber.random % 2 == 0)
            {//SI EL NUMERO ES PAR
                await using (ServiceBusClient client = new ServiceBusClient(connectionStringPar))
                {
                    // create a sender for the queue 
                    ServiceBusSender sender = client.CreateSender(queueNamePar);

                    // create a message that we can send
                    ServiceBusMessage message = new ServiceBusMessage(mensaje);

                    // send the message
                    await sender.SendMessageAsync(message);
                    Console.WriteLine($"Sent a single message to the queue: {queueNamePar}");
                }
                return true;
            }
            else
            {//SI EL NUMERO ES IMPAR
                if (myRandomNumber.random % 2 != 0)
                {
                    await using (ServiceBusClient client = new ServiceBusClient(connectionStringImpar))
                    {
                        // create a sender for the queue 
                        ServiceBusSender sender = client.CreateSender(queueNameImpar);

                        // create a message that we can send
                        ServiceBusMessage message = new ServiceBusMessage(mensaje);

                        // send the message
                        await sender.SendMessageAsync(message);
                        Console.WriteLine($"Sent a single message to the queue: {queueNameImpar}");
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
