﻿using System.Runtime.Serialization;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
    [DataContract]
    public class OfferDebitPriorityDto
    {
        [DataMember]
        public int DebitPriorityKey { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public double SelectedDefault { get; set; }

        [DataMember]
        public double SelectedFloor { get; set; }

        [DataMember]
        public double SelectedCeiling { get; set; }

        [DataMember]
        public double DeclinedDefault { get; set; }

        [DataMember]
        public double DeclinedFloor { get; set; }

        [DataMember]
        public double DeclinedCeiling { get; set; }
    }
}
