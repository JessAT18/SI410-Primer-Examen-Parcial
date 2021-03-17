using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace fncImpar
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("qimpar", Connection = "Endpoint=sb://queueparcial1jess.servicebus.windows.net/;SharedAccessKeyName=Escuchar;SharedAccessKey=wvKB24Ler1PJJlg0MVgOykCE1rcoxKUdsU6f2pwy3Aw=;EntityPath=qimpar")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
