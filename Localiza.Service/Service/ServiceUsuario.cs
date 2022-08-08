using Localiza.Base.Models;
using Localiza.Repository.Interface;
using Localiza.Service.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Localiza.Service.Service
{
    public class ServiceUsuario : IServiceUsuario
    {
        protected readonly IRepositoryUsuario _r;

        public ServiceUsuario(IRepositoryUsuario r)
        {
            _r = r;
        }

        public static string tokenHash = "fedaf7d8863b48e197b9287d492b708e";

        public string AuthenticateUser(string user, string rule)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(tokenHash);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Role, rule)
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

        public void Delete(int index)
        {
            _r.Delete(index);
        }

        public List<SegUsuario> GetAllRows()
        {
            return _r.GetAllDatas();
        }

        public string GetUsuario(string user, string pass)
        {
            var users = _r.GetAllDatas();

            if (users.Count() == 0)
                return null;

            return users.Where(x => x.Usuario == user).Where(x => x.Senha == pass).First()?.Tipo;
        }

        public SegUsuario Include(SegUsuario usuario)
        {
            var users = _r.GetAllDatas();
            if (users.Count() == 0)
                usuario.IdUsuario = 1;
            else
            {
                var lastId = users.OrderBy(x => x.IdUsuario).Last().IdUsuario;
                usuario.IdUsuario = lastId + 1;
            }

            return _r.Include(usuario);
        }
    }
}
