using Google.Protobuf;
using ProtoEventHubSender;

for (var i = 0; i < 10; i++)
{
    var eventPublisher = new EventPublisher();
    var eventData = new PersistSubmittedTransactionBuilder().Build();
    
    await eventPublisher.SendMessageAsync(eventData.ToByteArray());
    
    Console.WriteLine($"Message {eventData.OrchestrationInstanceId} sent successfully");
}
