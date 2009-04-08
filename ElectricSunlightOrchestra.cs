using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace ElectricSunlightOrchestra
{
    public partial class ElectricSunlightOrchestra : Form
    {
        private bool mDoneLoading = false;
        private Device mCurrentDevice;
        private BindingSource mConfigurationBridge = new BindingSource();
        private List<ButtonMapping> mButtonMappings = new List<ButtonMapping>();

        public ElectricSunlightOrchestra()
        {
            InitializeComponent();
        }

        private void ElectricSunlightOrchestra_Load(object sender, EventArgs e)
        {
            deviceCombo.DisplayMember = "InstanceName";
            deviceCombo.ValueMember = "InstanceGuid";
            deviceCombo.DataSource = Devices;

            //mConfigurationBridge.DataSource = mButtonMappings;
            deviceConfiguration.DataSource = mConfigurationBridge;
            // TODO: I think this is a race condition; we'd be better off checking the first paint or something
            doneLoading.Enabled = true;
        }

        private static List<DeviceInstance> Devices
        {
            get
            {
                var devices = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
                var deviceList = new List<DeviceInstance>();
                foreach (DeviceInstance di in devices)
                {
                    deviceList.Add(di);
                }
                return deviceList;
            }
        }

        private void joystickPoll_Tick(object sender, EventArgs e)
        {
            if (mCurrentDevice != null)
            {
                mCurrentDevice.Poll();
                var state = mCurrentDevice.CurrentJoystickState;
                byte[] buttonStates = state.GetButtons();
                bool atLeastOneChange = false;
                for (int i = 0; i < mButtonMappings.Count; i++)
                {
                    byte bs = buttonStates[i];
                    if ( bs >= 128)
                    {
                        if (!mButtonMappings[i].Pressed)
                        {
                            mButtonMappings[i].Pressed = true;
                            atLeastOneChange = true;
                            // TODO: carry out configured action, if appropriate
                        }
                    }
                    else
                    {
                        if (mButtonMappings[i].Pressed)
                        {
                            mButtonMappings[i].Pressed = false;
                            atLeastOneChange = true;
                        }
                    }
                }
                if (atLeastOneChange)
                {
                    mConfigurationBridge.EndEdit();
                    deviceConfiguration.Refresh();
                }
            }
        }

        private void deviceCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (mDoneLoading)
            {
                RefreshSelection();
            }
        }

        private void RefreshSelection()
        {
            joystickPoll.Enabled = false;
            if (deviceCombo.SelectedIndex >= 0)
            {
                Guid instanceGuid = (Guid) deviceCombo.SelectedValue;
                if (mCurrentDevice == null || mCurrentDevice.DeviceInformation.InstanceGuid != instanceGuid)
                {
                    if (mCurrentDevice != null)
                    {
                        mCurrentDevice.Unacquire();
                    }
                    mCurrentDevice = new Device(instanceGuid);
                    mCurrentDevice.SetCooperativeLevel(Handle,
                        CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
                    mCurrentDevice.SetDataFormat(DeviceDataFormat.Joystick);
                    mCurrentDevice.Acquire();
                    // TODO: investigate the use of mCurrentDevice.SetEventNotification();

                    mButtonMappings.Clear();
                    for (int c = 0; c < mCurrentDevice.Caps.NumberButtons; c++)
                    {
                        ButtonMapping bm = new ButtonMapping();
                        bm.Number = c;
                        bm.Pressed = false;
                        bm.TriggerFile = "";
                        mButtonMappings.Add(bm);
                    }
                    mConfigurationBridge.DataSource = mButtonMappings;
                    deviceConfiguration.Refresh();
                    joystickPoll.Enabled = true;
                }
            }

        }

        private void doneLoading_Tick(object sender, EventArgs e)
        {
            doneLoading.Enabled = false;
            mDoneLoading = true;
            RefreshSelection();
        }

    }
}
