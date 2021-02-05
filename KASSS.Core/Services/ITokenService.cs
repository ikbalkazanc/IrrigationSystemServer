using KASSS.Core.Configuration;
using KASSS.Core.DTOs;
using KASSS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(Customer userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
