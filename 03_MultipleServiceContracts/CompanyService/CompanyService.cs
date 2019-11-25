using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyService
{
    public class CompanyService : ICompanyPublicService, ICompanyConfidentialService
    {
        public string GetConfidentialInformation()
        {
            return "confidential information";
        }

        public string GetPublicInformation()
        {
            return "public information";
        }
    }
}
