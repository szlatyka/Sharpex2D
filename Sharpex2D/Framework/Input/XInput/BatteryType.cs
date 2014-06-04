﻿namespace Sharpex2D.Framework.Input.XInput
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Tested)]
    public enum BatteryType : byte
    {
        /// <summary>
        ///     Device not connected.
        /// </summary>
        BATTERY_TYPE_DISCONNECTED = 0x00,

        /// <summary>
        ///     Wired, no battery.
        /// </summary>
        BATTERY_TYPE_WIRED = 0x01,

        /// <summary>
        ///     Alkaline.
        /// </summary>
        BATTERY_TYPE_ALKALINE = 0x02,

        /// <summary>
        ///     Nickel Metal Hydride.
        /// </summary>
        BATTERY_TYPE_NIMH = 0x03,

        /// <summary>
        ///     Unknown.
        /// </summary>
        BATTERY_TYPE_UNKNOWN = 0xFF,
    };
}