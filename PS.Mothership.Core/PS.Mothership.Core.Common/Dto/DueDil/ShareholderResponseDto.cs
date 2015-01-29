using System;
using System.Net;
using System.Runtime.Serialization;
using PS.Mothership.Core.Common.Enums.DueDil;

namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class ShareholderResponseDto
    {
        public string Id { get; set; }

        public string LastUpdate { get; set; }

        public string Company { get; set; }

        public string Tittle { get; set; }

        public string ForeName { get; set; }

        public string SurName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }

        public string Address5 { get; set; }

        public string Type { get; set; }

        public decimal? Number { get; set; }

        public decimal? Value { get; set; }

        public string Currency { get; set; }
    }
}
