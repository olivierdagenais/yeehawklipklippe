using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.DirectX.DirectInput;

namespace ElectricSunlightOrchestra
{
    public partial class ElectricSunlightOrchestra : Form
    {
        private BindingSource mConfigurationBridge = new BindingSource();
        private List<DeviceInstance> mDeviceInstances = new List<DeviceInstance>();
        private List<Device> mDevices = new List<Device>();
        private Dictionary<Device, List<ButtonMapping>> mButtonMappingsByDevice = new Dictionary<Device, List<ButtonMapping>>();
        private List<ButtonMapping> mButtonMappings = new List<ButtonMapping>();

        public ElectricSunlightOrchestra()
        {
            InitializeComponent();
        }

        private void ElectricSunlightOrchestra_Load(object sender, EventArgs e)
        {
            var devices = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
            foreach (DeviceInstance di in devices)
            {
                mDeviceInstances.Add(di);
            }

            deviceButtonConfiguration.DataSource = mConfigurationBridge;

            // Must set-up a call-back timer because we can't bind the datagrids in the Load event
            // TODO: I think this is a race condition; we'd be better off checking the first paint or something
            doneLoading.Enabled = true;
        }

        private void joystickPoll_Tick(object sender, EventArgs e)
        {
            foreach(Device d in mDevices)
            {
                d.Poll();
                var state = d.CurrentJoystickState;
                byte[] buttonStates = state.GetButtons();
                bool atLeastOneChange = false;
                List<ButtonMapping> mappingsForDevice = mButtonMappingsByDevice[d];
                for (int i = 0; i < mappingsForDevice.Count; i++)
                {
                    byte bs = buttonStates[i];
                    if ( bs >= 128)
                    {
                        if (!mappingsForDevice[i].Pressed)
                        {
                            mappingsForDevice[i].Pressed = true;
                            atLeastOneChange = true;
                            // TODO: carry out configured _pressed_ action, if appropriate
                        }
                    }
                    else
                    {
                        if (mappingsForDevice[i].Pressed)
                        {
                            mappingsForDevice[i].Pressed = false;
                            atLeastOneChange = true;
                            // TODO: carry out configured _release_ action, if appropriate
                        }
                    }
                }
                if (atLeastOneChange)
                {
                    mConfigurationBridge.EndEdit();
                    deviceButtonConfiguration.Refresh();
                }
            }
        }

        private void ReloadDevices()
        {
            mButtonMappings.Clear();
            foreach (DeviceInstance di in mDeviceInstances)
            {
                Device d = new Device(di.InstanceGuid);
                d.SetCooperativeLevel(Handle,
                    CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
                d.SetDataFormat(DeviceDataFormat.Joystick);
                mDevices.Add(d);
                d.Acquire();
                // TODO: investigate the use of d.SetEventNotification();
                var buttonMappings = new List<ButtonMapping>();
                for (int c = 0; c < d.Caps.NumberButtons; c++)
                {
                    ButtonMapping bm = new ButtonMapping(d.DeviceInformation.InstanceGuid, d.DeviceInformation.InstanceName);
                    bm.Number = c;
                    bm.Pressed = false;
                    bm.SoundFileToPlayOnPress = "";

                    mButtonMappings.Add(bm);
                    buttonMappings.Add(bm);
                }
                mButtonMappingsByDevice.Add(d, buttonMappings);

                // TODO: axis buttonMappings
            }
            mConfigurationBridge.DataSource = mButtonMappings;
            deviceButtonConfiguration.Refresh();
            joystickPoll.Enabled = true;
        }

        private void doneLoading_Tick(object sender, EventArgs e)
        {
            doneLoading.Enabled = false;
            ReloadDevices();
        }

    }
}
