namespace evoFlix.Services
{
    public interface IUserServices
    {
        bool UsernameIsValid(string username);

        bool PasswordIsStrong(string password);
    }
}