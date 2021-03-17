namespace fncPar
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Random = Models.Random;

    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(

            [ServiceBusTrigger(
                    "qpar",
                    Connection = "MyConn"
            )] string myQueueItem,

            [CosmosDB(
                    databaseName:"dbPar",
                    collectionName:"Par",
                    ConnectionStringSetting = "strCosmos"
             )] IAsyncCollector<object> datos,

            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Random>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No es posible insertar datos: {ex.Message}");
            }
        }
    }
}
