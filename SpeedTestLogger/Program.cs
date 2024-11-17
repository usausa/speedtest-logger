using System.Text.Json;

using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;

using SpeedTestLogger;

using File = System.IO.File;

var json = args[0];
var url = args[1];
var organization = args[2];
var bucket = args[3];
var token = args[4];

await using var stream = File.OpenRead(json);
var result = await JsonSerializer.DeserializeAsync<Result>(stream, JsonSerializerOptions.Web);
if (result is not null)
{
    using var client = new InfluxDBClient(url, token);

    var writer = client.GetWriteApiAsync();
    var value = new Entity
    {
        Timestamp = result.Timestamp,
        Download = result.Download.Bandwidth,
        Upload = result.Upload.Bandwidth
    };

    await writer.WriteMeasurementAsync(value, WritePrecision.Ns, bucket, organization);
}
