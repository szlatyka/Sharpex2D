﻿namespace Sharpex2D.Framework.Input.XInput
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Tested)]
    public enum BatteryLevel : byte
    {
        /// <summary>
        ///     Empty.
        /// </summary>
        BATTERY_LEVEL_EMPTY = 0x00,

        /// <summary>
        ///     Low.
        /// </summary>
        BATTERY_LEVEL_LOW = 0x01,

        /// <summary>
        ///     Medium.
        /// </summary>
        BATTERY_LEVEL_MEDIUM = 0x02,

        /// <summary>
        ///     Full.
        /// </summary>
        BATTERY_LEVEL_FULL = 0x03
    };
}