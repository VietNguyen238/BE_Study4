using be_study4.Models;

namespace be_study4.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}