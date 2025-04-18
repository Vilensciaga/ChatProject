using Dto.Models.UserDtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Jwt
{
    public interface IJwtAuthManager
    {
        string Authenticate(LoginDto authUser, User u);
    }
}
