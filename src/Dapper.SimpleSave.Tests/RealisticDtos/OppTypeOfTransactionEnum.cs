using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [DataContract]
    [Table("[opp].TYPE_OF_TRANSACTION_ENUM"), ReferenceData]
    public enum OppTypeOfTransactionEnum : int
    {
        [Description("None")]
        [EnumMember]
        None = 0,
        [Description("Chip & Pin")]
        [EnumMember]
        F2F = 1,
        [Description("ECOM")]
        [EnumMember]
        ECOM = 2,
        [Description("MOTO")]
        [EnumMember]
        MOTO = 3,
        [Description("PSConnect (Terminal)")]
        [EnumMember]
        PSConnectTerminal = 5,
        [Description("PS Connect (Ecom)")]
        [EnumMember]
        PSConnectEcom = 6,
        [Description("VAR (YesPay)")]
        [EnumMember]
        VARYesPay = 7,
        [Description("EPOS")]
        [EnumMember]
        EPOS = 8,
        [Description("PSConnect (MOTO)")]
        [EnumMember]
        PSConnectMOTO = 9,

    }
}
