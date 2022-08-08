using Localiza.Base.Models;

namespace Localiza.Service.IService
{
    public interface IServiceUsuario
    {
        List<SegUsuario> GetAllRows();

        bool Include(SegUsuario usuario);

        bool Delete(int index);

        string GetUsuario(string user, string pass);

        string AuthenticateUser(string user, string rule);
    }
}
