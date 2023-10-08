using System.Text.Json;

namespace SuchByte.PiHolePlugin.Models;

public class DisablePiHoleActionConfigModel : ISerializableConfiguration
{

    public long Seconds { get; set; } = 10;


    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
    public static DisablePiHoleActionConfigModel Deserialize(string config)
    {
        return ISerializableConfiguration.Deserialize<DisablePiHoleActionConfigModel>(config);
    }
}