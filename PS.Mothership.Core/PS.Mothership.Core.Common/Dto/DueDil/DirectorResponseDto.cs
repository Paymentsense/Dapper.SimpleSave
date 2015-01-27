using System;
using System.Runtime.Serialization;


namespace PS.Mothership.Core.Common.Dto.DueDil
{
    public class DirectorResponseDto
    {
        public string Id { get; set; }

        public string LastUpdate { get; set; }

        public string RetiredDirectorshipsCount { get; set; }

        public string RetiredTradingDirectorshipsCount { get; set; }

        public string RetiredTradingDirectorDirectorshipsCount { get; set; }

        public string RetiredTradingSecretaryDirectorshipsCount { get; set; }

        public string DirectorDirectorshipsCount { get; set; }

        public string RetiredDirectorDirectorshipsCount { get; set; }

        public string SecretaryDirectorshipsCount { get; set; }

        public string RetiredSecretaryDirectorshipsCount { get; set; }

        public string ForeName { get; set; }

        public string SurName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string DirectorshipsUrl { get; set; }

        public string CompaniesUrl { get; set; }

        public string DirectorUrl { get; set; }

        public string Title { get; set; }

        public string MiddleName { get; set; }

        public string PostalTitle { get; set; }

        public string Nationality { get; set; }

        public string NationCode { get; set; }
    }
}
