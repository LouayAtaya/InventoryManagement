using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManagement.Application.Helpers
{
    public class JwtTokenGenerator
    {
        /*public static string JwtTokenSigningKey = "superSecretKey@5215";
        public static string GenerateToken(User user)
        {

            Svar securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSigningKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userName", user.Name),
                new Claim("userId", user.Id.ToString()),

            };

            // Add roles as multiple claims
            var userRoles = new List<string>();
            foreach (var role in user.Roles)
            {
                userRoles.Add(role.Name);
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            //store roles Array
            claims.Add(new Claim("userRoles", JsonConvert.SerializeObject(userRoles)));


            //Create Secrurity token object by giving required parameters

            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(claims);
            var token = new JwtSecurityToken(header, payload);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt_token;
        }*/
    }
}
