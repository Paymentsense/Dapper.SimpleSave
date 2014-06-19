namespace PS.Mothership.Core.Common.Enums.CompaniesHouse
{
    public enum NumAppInd
    {
        /// <remarks/>
        GE1000,
    }

    public enum AppointmentType
    {
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
        /// <remarks/>
        CURRENT,

        /// <remarks/>
        RESIGNED,
    }

    public enum ApptDatePrefix
    {
        /// <remarks/>
        PRE,
    }

    public enum Overdue
    {
        /// <remarks/>
        NO,

        /// <remarks/>
        OVERDUE,

        /// <remarks/>
        PENDING,
    }

    public enum MortgageInd
    {
        /// <remarks/>
        NO,

        /// <remarks/>
        LT300,

        /// <remarks/>
        GE300,
    }

    public enum Media
    {
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
        /// <remarks/>
        DOCUMENT,

        /// <remarks/>
        ANNOTATION,
    }

    public enum ItemsChoiceType
    {
        /// <remarks/>
        ChargeCode,

        /// <remarks/>
        Description,
    }

    public enum ChargeSatisfied
    {
        /// <remarks/>
        OUTSTANDING,

        /// <remarks/>
        SATISFIED,

        /// <remarks/>
        PARTSATISFIED,
    }

    public enum DataSet
    {
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
        /// <remarks/>
        NEAR,

        /// <remarks/>
        EXACT,
    }

    public enum OfficerType
    {
        /// <remarks/>
        CUR,

        /// <remarks/>
        LLP,

        /// <remarks/>
        DIS,

        /// <remarks/>
        EUR,
    }
}
