using System;

namespace ElectricSunlightOrchestra
{
    public class ButtonMapping : MappingBase
    {
        public ButtonMapping(Guid deviceGuid, string deviceName)
            : base(deviceGuid, deviceName)
        {
        }

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
