using SuchByte.PiHolePlugin.Models;

namespace SuchByte.PiHolePlugin.ViewModels;

internal interface ISerializableConfigViewModel
{
    protected ISerializableConfiguration SerializableConfiguration { get; }

    void SetConfig();

    bool SaveConfig();
}