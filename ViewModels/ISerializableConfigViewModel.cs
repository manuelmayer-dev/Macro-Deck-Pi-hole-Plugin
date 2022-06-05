using SuchByte.PiHolePlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin.ViewModels
{
    internal interface ISerializableConfigViewModel
    {
        protected ISerializableConfiguration SerializableConfiguration { get; }

        void SetConfig();

        bool SaveConfig();
    }
}
