using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RailDBProject.Model
{
    public enum DangerousDefectCodes
    {
        [Description("20.1")]
        DefectCode_20_1,
        [Description("20.2")]
        DefectCode_20_2,
        [Description("21.1")]
        DefectCode_21_1,
        [Description("21.2")]
        DefectCode_21_2,
        [Description("24")]
        DefectCode_24,
        [Description("27.1")]
        DefectCode_27_1,
        [Description("27.2")]
        DefectCode_27_2,
        [Description("25")]
        DefectCode_25
    }
}