using Backend.Entities.Models;
using Backend.Entities.References;

namespace Backend.Business.Interface.Config
{
    public interface ILoginBusiness
    {
        Result<bool> GetToken(Authenticate authenticate);
    }
}
