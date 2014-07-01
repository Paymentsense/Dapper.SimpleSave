using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstDataApplicationEnums
    {
        
    }

    public enum Application_InfoBusiness_InformationAdvert_Broch_Mail
    {
        Yes,
        No,
    }

    public enum Application_InfoBusiness_InformationAdvert_Catalog
    {
        Yes,
        No,
    }
    public enum Application_InfoBusiness_InformationAdvert_Internet
    {
        Yes,
        No,
    }
    public enum Application_InfoBusiness_InformationAdvert_News_Mag
    {
        Yes,
        No,
    }

    public enum Application_InfoBusiness_InformationAdvert_Tv_Radio
    {
        Yes,
        No,
    }

    public enum Application_InfoBusiness_InformationAdvert_Phone
    {
        Yes,
        No,
    }

    public enum Application_InfoBusiness_InformationChange_Reason
    {
        Rate,
        Service,
        TerminatedByBank,
        Other,
        Banking,
    }

    public enum Application_InfoBusiness_InformationName_Certification
    {
        CompanyReg,
        MemoArticleofAssociation,
        None,
        VAT
    }

    public enum Application_InfoBusiness_InformationPricing_Strategy
    {
        HBOSGENERALPRICING1,
        HBOSNONQUAL,
    }


    public enum Application_InfoBusiness_InformationSales_Area
    {
        Item5,
        Item15,
        Item99,
    }

    public enum Application_InfoBusiness_InformationSales_Channel
    {
        Direct,
        Corporate,
        Trade,
        Relationship,
    }

    public enum Application_InfoBusiness_InformationBank_Relationship
    {
        CORP,
        BUSINESS,
        Other,
    }

    public enum Application_InfoBusiness_InformationContactless_Payment_Merchant
    {
        Yes,
        No,
    }

    public enum Application_InfoBusiness_InformationInternational_Tax_Exempt
    {
        Yes,
        No,
        Unknown,
    }

    public enum Application_InfoBusiness_InformationBusiness_Type
    {
        PrivateLimitedCompany,
        PublicLimitedCompany,
        Partnership,
        Trust,
        LimitedLiabilityPartnership,
        SoleTrader,
    }


    public enum Application_InfoPrincipalTitle
    {
        Mr,
        Mrs,
        Miss,
        Ms,
    }

    public enum Application_InfoPrincipalGender
    {
        Male,
        Female,
    }

    public enum Application_InfoPrincipalMarital_Status
    {
        COHABITATING,
        DIVORCED,
        ENGAGED,
        MARRIED,
        NOTASKED,
        OTHER,
        NOTGIVEN,
        SINGLE,
        WIDOW,
    }

    public enum Application_InfoPrincipalNationality
    {
        ABW,        AFG,        AGO,        AIA,        ALB,        AND,        ANT,        ARE,        ARG,        ARM,        ASM,        ATA,        ATF,        ATG,        AUS,        AUT,        AZE,        BDI,        BEL,        BEN,        BFA,        BGD,        BGR,        BHR,        BHS,        BIH,        BLR,        BLZ,        BMU,        BOL,        BRA,        BRB,        BRN,        BTN,        BVT,        BWA,        CAF,        CAN,        CCK,        CHE,        CHL,        CIV,        CMR,        CNN,        COG,        COK,        COL,        COM,        CPV,        CRI,        CXR,        CYM,        CYP,        CZE,        DEU,        DJI,        DMA,        DNK,        DOM,        DZA,        ECU,        EGY,        ESH,        ESP,        EST,        ETH,        FIN,        FJI,        FLK,        FRA,        FRO,        FSM,        GAB,        GBR,        GEO,        GHA,        GIB,        GIN,        GLP,        GMB,        GNB,        GNQ,        GRC,        GRD,        GRL,        GTM,        GUF,        GUM,        GUY,        HKG,        HMD,        HND,        HRV,        HTI,        HUN,        IDN,        IND,        IOT,        IRL,        IRN,        IRQ,        ISL,        ISR,        ITA,        JAM,        JOR,        JPN,        KAZ,        KEN,        KGZ,        KHM,        KIR,        KNA,        KOR,        KWT,        LAO,        LBN,        LBR,        LBY,        LCA,        LIE,        LKA,        LSO,        LTU,        LUX,        LVA,        MAC,        MAR,        MCO,        MDA,        MDG,        MDV,        MEX,        MHL,        MKD,        MLI,        MLT,        MMR,        MNG,        MNP,        MOZ,        MRT,        MSR,        MTQ,        MUS,        MWI,        MYS,        NAM,        NCL,        NER,        NFK,        NGA,        NIC,        NIU,        NLD,        NOR,        NPL,        NRU,        NZL,        OMN,        PAK,        PAN,        PCN,        PER,        PHL,        PLW,        PNG,        POL,        PRI,        PRK,        PRT,        PRY,        PSE,        PYF,        QAT,        REU,        ROM,        RUS,        RWA,        SAU,        SDN,        SEN,        SGP,        SHN,        SJM,        SLB,        SLE,        SLV,        SMR,        SOM,        SPM,        STP,        SUR,        SVK,        SVN,        SWE,        SWZ,        SYC,        SYR,        TCA,        TDD,        TGO,        THA,        TJK,        TKL,        TKM,        TMP,        TON,        TTO,        TUN,        TUR,        TUV,        TWN,        TZA,        UGA,        UKR,        UMI,        URY,        USA,        UZB,        VAT,        VCT,        VEN,        VGB,        VIR,        VNM,        VUT,        WLF,        WSM,        YEM,        YUG,        ZAF,        ZAR,        ZMB,        ZWE,
    }

    public enum Application_InfoPrincipalJob_Title
    {
        Treasurer,
        Owner,
        Partner,
        CEO,
        Secretary,
        Director,
        Other,
        SoleProprietor,
    }

    public enum Application_InfoPrincipalPersonal_Guarantee
    {
        Y,
        N,
    }

    public enum Application_InfoPrincipalCurrent_Address_Ownership_Type
    {
        Owned,
        Rented,
        LiveWithParents,
    }

    public enum Application_InfoPrincipalPrevious_Address_Ownership_Type
    {
        Item,
        Owned,
        Rented,
        LiveWithParents,
    }

    public enum Application_InfoPrincipalPrincipal_Ever_Been_Adjucted
    {
        Y,
        N,
    }

    public enum Application_InfoPrincipalPrincipal_Ever_Been_Associated
    {
        Y,
        N,
    }

    public enum Application_InfoBanking_InformationOutlet_Corp
    {
        Outlet,
        Corp,
    }


    public enum Application_InfoOutletOutlet_AddressPremises_Rented
    {
        Y,
        N,
    }

    public enum Application_InfoOutletOutlet_Business_InfoBusiness_Type
    {
        Internet,
        MOTO,
        Hotel,
        Restaurant,
        Retail,
    }

    public enum Application_InfoOutletOutlet_Business_InfoMail_Statement_To
    {
        RollupToOutlet,
        RollupToChain,
        RolluptoCorp,
        None,
    }

    public enum Application_InfoOutletOutlet_Business_InfoBusiness_Email1_Type_One
    {
        None,
        Statements,
        Retrievals,
        Chargebacks,
    }

    public enum Application_InfoOutletOutlet_Business_InfoBusiness_Email1_Type_Two
    {
        None,
        Statements,
        Retrievals,
        Chargebacks,
    }

    public enum Application_InfoOutletOutlet_Business_InfoStatement_Delivery_Method
    {
        Print,
        Hold,
        Email,
        MailandEmail,
    }

    public enum Application_InfoOutletOutlet_Business_InfoStatement_Type
    {
        None,
        FDCSDetail,
        FDCSSummary,
    }

    public enum Application_InfoOutletOutlet_Business_InfoCurrency_Code
    {
        BritishSterling,
        Euro,
        USDollar,
    }
    public enum Application_InfoOutletOutlet_Business_InfoNon_Qualifying_Transaction
    {
        None,
        AllCardpresentandnonQualfeesL05,
        CNPandnonQualfeesV15,
        eCommerceW16,
    }

    public enum Application_InfoOutletOutlet_Business_InfoEnable_Split_Funding
    {
        Y,
        N,
    }

    public enum Application_InfoOutletOutlet_Business_InfoSettlement_Timeframe_Indicator
    {
        BACS,
        ZERODAYHOLD,
        ONEDAYHOLD,
        TWODAYHOLD,
    }

    public enum Application_InfoOutletOutlet_Business_InfoBacs
    {
        N,
        Y,
    }

    public enum Application_InfoOutletOutlet_Trading_InfoFull_Payments_Ever_Taken_Before_Delivery
    {
        Y,
        N,
    }

    public enum Application_InfoOutletOutlet_Trading_InfoPayment_Accepted_Card_Membership_Subscription
    {
        Y,
        N,
    }

    public enum Application_InfoOutletOutlet_Trading_InfoSubmit_To_Refund
    {
        Item03Days,
        Item47Days,
        Item814Days,
        Item14Days,
    }

    public enum Application_InfoOutletOutlet_Trading_InfoDeposits_Required
    {
        Y,
        N,
    }

    public enum Application_InfoOutletOutlet_Trading_InfoPayments_For_Guarantees_Warranties
    {
        Y,
        N,
    }

    public enum Application_InfoOutletOutlet_Trading_InfoAutomatic_Renewals_Transaction
    {
        Y,
        N,
    }

    public enum Application_InfoOutletEntitlementCard_Type
    {
        VisaCredit,
        VisaCreditChip,
        UKVisaDelta,
        UKVisaDeltaChip,
        VisaCommercial,
        VisaElectron,
        MasterCardCredit,
        MasterCardCreditChip,
        MasterCardDebit,
        MasterCardDebitChip,
        MasterCardCommercial,
        Maestro,
        AMEX,
        JCB,
        Diners,
        Transax,
    }

    public enum Application_InfoOutletEntitlementRequest_Type
    {
        Item,
        New,
        Existing,
    }

    public enum Application_InfoOutletOutlet_EquipmentOperating_Method
    {
        Online,
        Polled,
        Paper,
        Internet,
    }

    public enum Application_InfoOutletOutlet_EquipmentBanking_Window_From
    {
        Item100,
        Item1600,
    }

    public enum Application_InfoOutletOutlet_EquipmentBanking_Window_To
    {
        Item300,
        Item1800,
    }

    public enum Application_InfoOutletOutlet_EquipmentBilling_Method
    {
        Lease,
        Purchase,
    }

    public enum Application_InfoOutletOutlet_EquipmentEquipment_Details_InfoBill_Method
    {
        Item,
        CustOwned,
        Lease36Month,
        Lease48Month,
        Lease60Month,
    }


    public enum Application_InfoOutletFeeCard_Type
    {
        ALL,
        VisaCredit,
        VisaCommercial,
        VisaElectron,
        MasterCardCredit,
        MastercardDebit,
        MastercardDebitChip,
        MasterCardCommercial,
        Maestro,
        Polling,
        StatementDelivery,
        SettlementIndicator,
        CashBack,
        VisaChip,
        MasterCardChip,
        VisaDelta,
        VisaDeltaChip,
    }
    public enum AmExSelection
    {
        None = 0,
        Exists = 1,
        New = 2
    }

    public enum CurrencyCode
    {
        BritishSterling = 1,
        Euro = 2,
        UsDollar = 3
    }
}
