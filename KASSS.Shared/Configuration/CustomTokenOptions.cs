using System;
using System.Collections.Generic;
using System.Text;

namespace KASSS.Shared.Configuration
{
    public class CustomTokenOptions
    {
        public List<String> Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
