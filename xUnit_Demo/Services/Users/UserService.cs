using Microsoft.EntityFrameworkCore;
using xUnit_Demo.Data;
using xUnit_Demo.Models;

namespace xUnit_Demo.Services.Users;

#pragma warning disable

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<bool> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async ValueTask<bool> DeleteAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async ValueTask<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async ValueTask<User> GetByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async ValueTask<bool> UpdateAsync(int userId, User user)
    {
        var existingUser = await _context.Users.FindAsync(userId);
        if (existingUser == null)
            return false;

        existingUser.Name = user.Name;

        await _context.SaveChangesAsync();
        return true;
    }
}
