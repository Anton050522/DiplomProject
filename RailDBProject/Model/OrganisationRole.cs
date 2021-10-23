using System.ComponentModel;

namespace RailDBProject.Model
{
    public enum OrganisationRole
    {
        [Description("ЦДИ")]
        CDI,
        [Description("УПР")]
        UPR,
        [Description("НОД")]
        NOD,
        [Description("ПЧ")]
        PCH
    }
}
