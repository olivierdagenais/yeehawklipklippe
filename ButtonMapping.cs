using System;
using System.Collections.Generic;

using Microsoft.DirectX.DirectInput;

namespace ElectricSunlightOrchestra
{
    public class ButtonMapping
    {
        private readonly Guid mDeviceGuid;
        private readonly string mDeviceName;

        public ButtonMapping(Guid deviceGuid, string deviceName)
        {
            mDeviceGuid = deviceGuid;
            mDeviceName = deviceName;
        }

        /// <summary>
        /// The ID of the <see cref="Device"/>.
        /// </summary>
        /// 
        /// <remarks>
        /// Not a property to prevent it from showing up in the <see cref="DataGridView"/>.
        /// </remarks>
        /// 
        /// <returns>
        /// </returns>
        public Guid GetId()
        {
            return mDeviceGuid;
        }

        public string DeviceName
        {
            get
            {
                return mDeviceName;
            }
        }
        public int Number { get; set; }
        public bool Pressed { get; set; }

        /// <summary>
        /// The sound file to play when the button is pressed.
        /// </summary>
        public string SoundFileToPlayOnPress { get; set; }

        /// <summary>
        /// The sound file to play when the button is released.
        /// </summary>
        public string SoundFileToPlayOnRelease { get; set; }
    }
}
