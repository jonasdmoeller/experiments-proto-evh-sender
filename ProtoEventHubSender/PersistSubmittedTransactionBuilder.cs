using Google.Protobuf.WellKnownTypes;

namespace ProtoEventHubSender;

public class PersistSubmittedTransactionBuilder
{
    public PersistSubmittedTransaction Build()
    {
        var pst = new PersistSubmittedTransaction
        {
            Version = "1.0",
            OrchestrationInstanceId = Guid.NewGuid().ToString(),
            OrchestrationType = OrchestrationType.OtSubmittedMeasureData,
            MeteringPointId = Guid.NewGuid().ToString(),
            TransactionId = Guid.NewGuid().ToString(),
            TransactionCreationDatetime = Timestamp.FromDateTimeOffset(DateTimeOffset.Now),
            StartDatetime = Timestamp.FromDateTimeOffset(DateTimeOffset.Now),
            EndDatetime = Timestamp.FromDateTimeOffset(DateTimeOffset.Now),
            MeteringPointType = MeteringPointType.MptConsumption,
            Product = "SomeProduct",
            Unit = Unit.UKvarh,
            Resolution = Resolution.RPt15M
        };
        
        pst.Points.Add(new Point { Position = 1, Quantity = new DecimalValue{Nanos = 1, Units = 2}, Quality = Quality.QMeasured});
        pst.Points.Add(new Point { Position = 2, Quantity = new DecimalValue{Nanos = 1, Units = 2}, Quality = Quality.QMeasured});
        pst.Points.Add(new Point { Position = 3, Quantity = new DecimalValue{Nanos = 1, Units = 2}, Quality = Quality.QMeasured});

        return pst;
    }
}