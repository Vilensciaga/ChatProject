using Auth.EncryptionMethods;
using Dto.Models.UserDtos;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Auth.Jwt
{
    public class JwtAuthManager:IJwtAuthManager
    {
        private readonly string key;

        public JwtAuthManager(string key)
        {
            this.key = key; 
        }

        public string Authenticate(LoginDto userAuth, User user)
        {

            if (!((userAuth.email == user.email) && (userAuth.password == Encryption.DecryptPassword(user.password))))
            {
                Console.WriteLine("User info is not valid");
                return null;
            }


            // Define the secret key used to sign the token
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Define the signing credentials using the secret key and algorithm
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            // Define the claims for the token
            var claims = new[]
            {
                new Claim("userData", JsonConvert.SerializeObject(user)),
                new Claim("FirstName", JsonConvert.SerializeObject(user.FirstName)),
                new Claim("LastName", JsonConvert.SerializeObject(user.LastName)),
                new Claim("email", JsonConvert.SerializeObject(user.email)),
            };

            // Define the token parameters, including the claims and signing credentials
            var tokenParameters = new JwtSecurityToken
            (
                //issuer: "example.com",
                //audience: "example.com",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: signingCredentials
            );

            // Generate the token using the parameters and a JWT security token handler and returning it
            var token = new JwtSecurityTokenHandler().WriteToken(tokenParameters);
            string tokenObj = JsonConvert.SerializeObject(token);
            return tokenObj;
        }
    }
}
