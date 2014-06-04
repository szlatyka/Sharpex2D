﻿namespace Sharpex2D.Framework.Input.XInput
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Tested)]
    public static class XInputConstants
    {
        /// <summary>
        ///     Devtype Gamepad.
        /// </summary>
        public const int XINPUT_DEVTYPE_GAMEPAD = 0x01;

        /// <summary>
        ///     Subtype gamepad.
        /// </summary>
        public const int XINPUT_DEVSUBTYPE_GAMEPAD = 0x01;

        /// <summary>
        ///     Threshold Left thumb deadzone.
        /// </summary>
        public const int XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE = 7849;

        /// <summary>
        ///     Threshold Right thumb deadzone.
        /// </summary>
        public const int XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE = 8689;

        /// <summary>
        ///     Threshold trigger deadzone.
        /// </summary>
        public const int XINPUT_GAMEPAD_TRIGGER_THRESHOLD = 30;

        /// <summary>
        ///     Flag Gamepad.
        /// </summary>
        public const int XINPUT_FLAG_GAMEPAD = 0x00000001;
    }
}