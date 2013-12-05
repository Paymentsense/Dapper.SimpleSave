using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Config
{
    public class WcfClientCertificateValidator : X509CertificateValidator
    {
        private const string AllowedIssuerName = "CN=RootPSMothership2";

        public override void Validate(X509Certificate2 certificate)
        {
            // Check that there is a certificate.
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }

            // Check that the certificate issuer matches the configured issuer.
            if (AllowedIssuerName != certificate.IssuerName.Name)
            {
                throw new SecurityTokenValidationException("Certificate was not issued by a PaymentSense !");
            }
        }
    }
}
