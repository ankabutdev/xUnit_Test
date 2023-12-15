using xUnit_Demo.Models;

namespace xUnit_Demo.Services.Users;

public interface IUserService
{
    public ValueTask<IEnumerable<User>> GetAllUsers();

    public ValueTask<User> GetByIdAsync(int userId);

    public ValueTask<bool> CreateAsync(User user);

    public ValueTask<bool> UpdateAsync(int Id, User user);

    public ValueTask<bool> DeleteAsync(int UserId);

}
