namespace SpeedTestLogger;

public sealed class Transfer
{
    public int Bandwidth { get; set; }
}

public sealed class Result
{
    public DateTime Timestamp { get; set; }

    public Transfer Download { get; set; } = default!;

    public Transfer Upload { get; set; } = default!;
}
