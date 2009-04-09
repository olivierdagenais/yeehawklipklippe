using System;
using Microsoft.DirectX.DirectInput;

namespace ElectricSunlightOrchestra
{
    public class AxisMapping : MappingBase
    {
        public AxisMapping(Guid deviceGuid, string deviceName)
            : base(deviceGuid, deviceName)
        {
        }

        /// <summary>
        /// The value when the analog device is at rest.
        /// </summary>
        /// 
        /// <remarks>
        /// This isn't always one of the extremes; the Rockband/Harmonix Guitar's whammy bar is 32511 at rest, but as
        /// soon as you hit it, it goes from 0 (depressed a little) to 65535 (fully depressed).
        /// </remarks>
        public int NeutralValue { get; set; }

        public int Value { get; set; }

        // TODO: allow user to configure the action based on value (vibrato, pitch shift, etc.)

        /// <summary>
        /// Emulates behaviour like that of <see cref="JoystickState.GetButtons()"/>.
        /// </summary>
        /// 
        /// <param name="state">
        /// The <see cref="JoystickState"/> instance to query.
        /// </param>
        /// 
        /// <returns>
        /// An array of integers representing the values of the respective axes.
        /// </returns>
        /// 
        /// <remarks>
        /// The irony here is that the value are probably read from an array in the first place.
        /// </remarks>
        public static int[] GetValues(JoystickState state)
        {
            int[] result = new int[] {
                state.ARx,
                state.ARy,
                state.ARz,
                state.AX,
                state.AY,
                state.AZ,
                state.FRx,
                state.FRy,
                state.FRz,
                state.FX,
                state.FY,
                state.FZ,
                state.Rx,
                state.Ry,
                state.Rz,
                state.VRx,
                state.VRy,
                state.VRz,
                state.VX,
                state.VY,
                state.VZ,
                state.X,
                state.Y,
                state.Z,
            };
            return result;
        }
    }
}
