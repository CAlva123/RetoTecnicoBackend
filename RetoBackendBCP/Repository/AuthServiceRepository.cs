using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RetoBackendBCP.Repository
{
    public class AuthServiceRepository
    {
        private readonly IConfiguration _configuration;

        public AuthServiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool ValidateLogin(string username, string password)
        {
            if (username.Equals("usuario") && password.Equals("123"))
                return true;
            return false;
        }

        public string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez)
        {
            var fechaExpiracion = fechaActual.Add(tiempoValidez);
            //Configuramos las claims
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim("roles","Cliente"),
                new Claim("roles","Administrador"),
            };

            //Añadimos las credenciales
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AuthenticationSettings:SigningKey"])),
                    SecurityAlgorithms.HmacSha256Signature
            );

            //Configuracion del jwt token
            var jwt = new JwtSecurityToken(
                issuer: "Peticionario",
                audience: "Public",
                claims: claims,
                notBefore: fechaActual,
                expires: fechaExpiracion,
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return "Bearer " + encodedJwt;
        }
    }
}
