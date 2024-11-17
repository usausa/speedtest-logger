namespace SpeedTestLogger;

using InfluxDB.Client.Core;

[Measurement("SpeedTest")]
internal sealed class Entity
{
    [Column(IsTimestamp = true)]
    public DateTime Timestamp { get; set; }

    [Column]
    public int Download { get; set; } = default!;

    [Column]
    public int Upload { get; set; } = default!;
}
