﻿using System;
using Sharpex2D.Framework.Components;
using Sharpex2D.Framework.Debug.Logging;

namespace Sharpex2D.Framework.Debug
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Untested)]
    public class ExceptionHandler : IComponent
    {
        #region IComponent Implementation

        /// <summary>
        ///     Gets the guid.
        /// </summary>
        public Guid Guid
        {
            get { return new Guid("4FE0400B-0520-4B43-ADAD-B588B13C38D8"); }
        }

        #endregion

        private bool _enabled;

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if ((value && _enabled) || (!value && !_enabled))
                {
                }
                else
                {
                    if (value)
                    {
                        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    }
                    else
                    {
                        AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
                    }

                    _enabled = value;
                }
            }
        }

        /// <summary>
        ///     Logs the unhandled exceptions.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">The EventArgs.</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Next(((Exception) e.ExceptionObject).Message, LogLevel.Critical, LogMode.StandardOut);
        }
    }
}