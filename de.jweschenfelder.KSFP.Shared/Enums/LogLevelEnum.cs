﻿using System;
using System.ComponentModel;
using de.jweschenfelder.KSFP.Shared.Attributes;

namespace de.jweschenfelder.KSFP.Shared.Enums
{
    [Serializable]
    public enum LogLevelEnum
    {
        [Description("Critical"), BackColorName("Transparent"), FrontColorName("DarkRed")]
        Critical = 5,

        [Description("Error"), BackColorName("Transparent"), FrontColorName("Red")]
        Error = 4,

        [Description("Warn"), BackColorName("Transparent"), FrontColorName("DarkOrange")]
        Warn = 3,

        [Description("Debug"), BackColorName("Transparent"), FrontColorName("DarkGreen")]
        Debug = 2,

        [Description("Info"), BackColorName("Transparent"), FrontColorName("CornflowerBlue")]
        Info = 1,

        [Description("None"), BackColorName("Transparent"), FrontColorName("Black")]
        None = 0
    }
}
