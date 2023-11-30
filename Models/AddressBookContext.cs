using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class AddressBookContext : DbContext
{
    public AddressBookContext(DbContextOptions<AddressBookContext> options)
        : base(options)
    {
    }

    public DbSet<AddressBook> TodoItems { get; set; } = null!;
}
