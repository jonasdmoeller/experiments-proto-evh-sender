using Google.Protobuf;
using ProtoEventHubSender;

var eventDataBuilder = new PersistSubmittedTransactionBuilder();
var eventPublisher = new EventPublisher();

for (var i = 0; i < 15; i++)
{
    var eventData = eventDataBuilder.Build();
    
    await eventPublisher.SendEventAsync(eventData.ToByteArray());
    
    Console.WriteLine($"Message {eventData.OrchestrationInstanceId} sent successfully");
}
