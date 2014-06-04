﻿namespace Sharpex2D.Framework.Input.XInput
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Tested)]
    public static class XInputAPI
    {
        /// <summary>
        ///     Gets the XInput state.
        /// </summary>
        /// <param name="dwUserIndex">The Index.</param>
        /// <param name="pState">The InputState.</param>
        /// <returns></returns>
        internal static int XInputGetState(int dwUserIndex, ref XInputState pState)
        {
            return NativeMethods.XInputGetState(dwUserIndex, ref pState);
        }

        /// <summary>
        ///     Sets the Input state.
        /// </summary>
        /// <param name="dwUserIndex">The Index.</param>
        /// <param name="pVibration">The Vibration.</param>
        /// <returns></returns>
        internal static int XInputSetState(int dwUserIndex, ref XInputVibration pVibration)
        {
            return NativeMethods.XInputSetState(dwUserIndex, ref pVibration);
        }

        /// <summary>
        ///     Gets the Capabilities.
        /// </summary>
        /// <param name="dwUserIndex">The Index.</param>
        /// <param name="dwFlags">The dwFlags.</param>
        /// <param name="pCapabilities">The Capabilities.</param>
        /// <returns></returns>
        internal static int XInputGetCapabilities(int dwUserIndex, int dwFlags, ref XInputCapabilities pCapabilities)
        {
            return NativeMethods.XInputGetCapabilities(dwUserIndex, dwFlags, ref pCapabilities);
        }

        /// <summary>
        ///     Gets the Battery information.
        /// </summary>
        /// <param name="dwUserIndex">The Index.</param>
        /// <param name="devType">The DevType.</param>
        /// <param name="pBatteryInformation">The BatteryInformation.</param>
        /// <returns></returns>
        internal static int XInputGetBatteryInformation(int dwUserIndex, byte devType,
            ref XInputBatteryInformation pBatteryInformation)
        {
            return NativeMethods.XInputGetBatteryInformation(dwUserIndex, devType, ref pBatteryInformation);
        }
    }
}