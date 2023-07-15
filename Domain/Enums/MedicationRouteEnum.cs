using System.ComponentModel;

namespace Domain.Enums
{
    public enum MedicationRouteEnum : short
    {
        [Description("Oral")]
        Oral,

        [Description("Rectal")]
        Rectal,

        [Description("Sublingual")]
        Sublingual,

        [Description("Injectable")]
        Injectable,

        [Description("Dermatological")]
        Dermatological,

        [Description("Nasal")]
        Nasal,

        [Description("Ophthalmic")]
        Ophthalmic
    }
}