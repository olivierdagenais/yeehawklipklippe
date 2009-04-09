using System;
using System.Collections.Generic;

using Microsoft.DirectX.DirectInput;

namespace ElectricSunlightOrchestra
{
    public abstract class MappingBase
    {
        private readonly Guid mDeviceGuid;
        private readonly string mDeviceName;

        public MappingBase(Guid deviceGuid, string deviceName)
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

        public string Alias { get; set; }
    }
}
