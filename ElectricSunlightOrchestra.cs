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
        private List<DeviceInstance> mDeviceInstances = new List<DeviceInstance>();
        private List<Device> mDevices = new List<Device>();

        private BindingSource mButtonConfigurationBridge = new BindingSource();
        private Dictionary<Device, List<ButtonMapping>> mButtonMappingsByDevice 
            = new Dictionary<Device, List<ButtonMapping>>();
        private List<ButtonMapping> mButtonMappings = new List<ButtonMapping>();

        private BindingSource mAxisConfigurationBridge = new BindingSource();
        private Dictionary<Device, List<AxisMapping>> mAxisMappingsByDevice 
            = new Dictionary<Device, List<AxisMapping>>();
        private List<AxisMapping> mAxisMappings = new List<AxisMapping>();


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

            // TODO: Now that I'm using MappingBase, the column names are in the wrong order
            deviceButtonConfiguration.DataSource = mButtonConfigurationBridge;
            deviceAxisConfiguration.DataSource = mAxisConfigurationBridge;

            // Must set-up a call-back timer because we can't bind the datagrids in the Load event
            // TODO: I think this is a race condition; we'd be better off checking the first paint or something
            doneLoading.Enabled = true;
        }

        private void joystickPoll_Tick(object sender, EventArgs e)
        {
            bool atLeastOneDigitalChange = false;
            bool atLeastOneAnalogChange = false;
            foreach (Device d in mDevices)
            {
                d.Poll();
                var state = d.CurrentJoystickState;
                atLeastOneDigitalChange |= ReactToDigitalEvents(mButtonMappingsByDevice[d], state);
                atLeastOneAnalogChange |= ReactToAnalogEvents(mAxisMappingsByDevice[d], state);
            }
            if (atLeastOneDigitalChange)
            {
                mButtonConfigurationBridge.EndEdit();
                deviceButtonConfiguration.Refresh();
            }
            if (atLeastOneAnalogChange)
            {
                mAxisConfigurationBridge.EndEdit();
                deviceAxisConfiguration.Refresh();
            }
        }

        private bool ReactToDigitalEvents(List<ButtonMapping> mappingsForDevice, JoystickState state)
        {
            byte[] buttonStates = state.GetButtons();
            bool atLeastOneChange = false;
            for (int i = 0; i < mappingsForDevice.Count; i++)
            {
                byte bs = buttonStates[i];
                if (bs >= 128)
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
            return atLeastOneChange;
        }

        private bool ReactToAnalogEvents(List<AxisMapping> mappingsForDevice, JoystickState state)
        {
            int[] initialAxisValues = AxisMapping.GetValues(state);
            bool atLeastOneChange = false;
            for (int i = 0; i < mappingsForDevice.Count; i++)
            {
                var am = mappingsForDevice[i];
                int value = initialAxisValues[i];
                if (value != am.Value)
                {
                    atLeastOneChange = true;
                    am.Value = value;
                    if (value == am.NeutralValue)
                    {
                        // TODO: carry out configured _released_ action, if appropriate
                    }
                    else
                    {
                        // TODO: carry out configured _value_ action, if appropriate
                    }
                }
           }
           return atLeastOneChange;
        }

        private void ReloadDevices()
        {
            mButtonMappings.Clear();
            mAxisMappings.Clear();
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
                for (int b = 0; b < d.Caps.NumberButtons; b++)
                {
                    ButtonMapping bm
                        = new ButtonMapping(d.DeviceInformation.InstanceGuid, d.DeviceInformation.InstanceName);
                    bm.Alias = String.Format("#{0}", b + 1);
                    bm.Pressed = false;
                    bm.SoundFileToPlayOnPress = "";

                    mButtonMappings.Add(bm);
                    buttonMappings.Add(bm);
                }
                // TODO: consider adding the "Point of View Hat" instances as a set of analog (and/or digital) inputs
                mButtonMappingsByDevice.Add(d, buttonMappings);

                var axisMappings = new List<AxisMapping>();
                d.Poll();
                int[] initialAxisValues = AxisMapping.GetValues( d.CurrentJoystickState );
                for (int a = 0; a < initialAxisValues.Length; a++)
                {
                    AxisMapping am
                        = new AxisMapping(d.DeviceInformation.InstanceGuid, d.DeviceInformation.InstanceName);
                    am.Alias = String.Format("#{0}", a + 1);
                    
                    am.NeutralValue = initialAxisValues[a];
                    am.Value = 0;

                    mAxisMappings.Add(am);
                    axisMappings.Add(am);
                }
                mAxisMappingsByDevice.Add(d, axisMappings);
            }

            mButtonConfigurationBridge.DataSource = mButtonMappings;
            deviceButtonConfiguration.Refresh();
            mAxisConfigurationBridge.DataSource = mAxisMappings;
            deviceAxisConfiguration.Refresh();

            joystickPoll.Enabled = true;
        }

        private void doneLoading_Tick(object sender, EventArgs e)
        {
            doneLoading.Enabled = false;
            ReloadDevices();
        }

    }
}
