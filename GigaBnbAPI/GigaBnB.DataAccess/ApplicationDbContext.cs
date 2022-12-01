using Microsoft.EntityFrameworkCore;
using GigaBnB.Model.Models;

namespace GigaBnB.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Listing> Listings { get; set; }
}