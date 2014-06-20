using System.Xml.Serialization;

namespace PS.Mothership.Core.Common.Enums.CompaniesHouse
{
    public enum NumAppInd
    {
        [XmlEnum(Name="")]
        NotSpecified = -1,

        /// <remarks/>
        GE1000,
    }

    public enum AppointmentType
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        DIR,

        /// <remarks/>
        SEC,

        /// <remarks/>
        NOMDIR,

        /// <remarks/>
        NOMSEC,

        /// <remarks/>
        LLPMEM,

        /// <remarks/>
        LLPDMEM,

        /// <remarks/>
        LLPGPART,

        /// <remarks/>
        LLPPART,

        /// <remarks/>
        EEIGMAN,

        /// <remarks/>
        PERSAUTHA,

        /// <remarks/>
        PERSAUTHR,

        /// <remarks/>
        PERSAUTHRA,

        /// <remarks/>
        CICMAN,

        /// <remarks/>
        RECMAN,

        /// <remarks/>
        FACTOR,
    }

    public enum AppointmentStatus
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        CURRENT,

        /// <remarks/>
        RESIGNED,
    }

    public enum ApptDatePrefix
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        PRE,
    }

    public enum Overdue
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        NO,

        /// <remarks/>
        OVERDUE,

        /// <remarks/>
        PENDING,
    }

    public enum MortgageInd
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        NO,

        /// <remarks/>
        LT300,

        /// <remarks/>
        GE300,
    }

    public enum Media
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        ARCHIVE,

        /// <remarks/>
        JUKEBOX,

        /// <remarks/>
        CACHE,

        /// <remarks/>
        UNAVAILABLE,
    }

    public enum FHistCPLXtTypeChildDocumentChildDocumentType
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        DOCUMENT,

        /// <remarks/>
        ANNOTATION,

        STATEMENTOFCAPITAL,
    }

    public enum ItemsChoiceType
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        ChargeCode,

        /// <remarks/>
        Description,
    }

    public enum ChargeSatisfied
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        OUTSTANDING,

        /// <remarks/>
        SATISFIED,

        /// <remarks/>
        PARTSATISFIED,
    }

    public enum DataSet
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        LIVE,

        /// <remarks/>
        DISSOLVED,

        /// <remarks/>
        FORMER,

        /// <remarks/>
        PROPOSED,
    }

    public enum CompanyIndexStatus
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        EFFECTIVE,

        /// <remarks/>
        REJECTED,

        /// <remarks/>
        DISSOLVED,

        /// <remarks/>
        CNGOFNAME,

        /// <remarks/>
        INLIQ,

        /// <remarks/>
        REMOVED,

        /// <remarks/>
        STATUSR,

        /// <remarks/>
        STATUSA,

        /// <remarks/>
        STATUSV,
    }

    public enum SearchMatch
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        NEAR,

        /// <remarks/>
        EXACT,
    }

    public enum OfficerType
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        /// <remarks/>
        CUR,

        /// <remarks/>
        LLP,

        /// <remarks/>
        DIS,

        /// <remarks/>
        EUR,
    }

    public enum RegDateType
    {
        [XmlEnum(Name = "")]
        NotSpecified = -1,

        DateOfRegistration = 0,
        DateOfFormationInGB = 1,
        DateOfTransferIntoGB = 2,
        DateOfTransformation = 3,
        DateOfConversion = 4
    }
}
