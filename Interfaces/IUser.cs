using WebApiClients.Entities;

namespace WebApiClients.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<Users.Response>> GetAllUsers(CancellationToken cancellationToken);
        Task<Users.Response> CreateUser(Users.Request user, CancellationToken cancellationToken);
        Task<Users.Response> ChangeUser(Users.Request user, CancellationToken cancellationToken);
        Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
    }
}
