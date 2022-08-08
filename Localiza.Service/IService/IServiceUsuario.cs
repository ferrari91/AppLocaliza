using Localiza.Base.Models;

namespace Localiza.Service.IService
{
    public interface IServiceUsuario
    {
        List<SegUsuario> GetAllRows();

        SegUsuario Include(SegUsuario usuario);

        void Delete(int index);

        string GetUsuario(string user, string pass);

        string AuthenticateUser(string user, string rule);
    }
}
