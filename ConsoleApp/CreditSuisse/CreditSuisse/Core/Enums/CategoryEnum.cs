using System.ComponentModel;

namespace CreditSuisse.Core.Enums
{
    public enum CategoryEnum
    {
        [Description("Expired")]
        Expired = 0,

        [Description("HighRisk")]
        HighRisk = 1,

        [Description("MediumRisk")]
        MediumRisk = 2
    }
}
