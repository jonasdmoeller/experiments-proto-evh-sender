using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Identity;

namespace ProtoEventHubSender;

public class EventPublisher : IAsyncDisposable
{
    private readonly EventHubProducerClient _producerClient;

    public EventPublisher()
    {
        const string fullyQualifiedNamespace = "your-event-hub-namespace.servicebus.windows.net";
        const string eventHubName = "your-event-hub-name";
            
        _producerClient = new EventHubProducerClient(
            fullyQualifiedNamespace,
            eventHubName,
            new DefaultAzureCredential());
    }

    public async Task SendMessageAsync(byte[] bytes)
    {
        try
        {
            using var eventBatch = await _producerClient.CreateBatchAsync();
            eventBatch.TryAdd(new EventData(bytes));

            await _producerClient.SendAsync(eventBatch);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
            throw;
        }
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
        
    private async Task DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            await _producerClient.DisposeAsync();
        }
    }
}