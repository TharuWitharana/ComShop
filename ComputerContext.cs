using ComputerShop.Models;
using System.Collections.Generic;


using Microsoft.EntityFrameworkCore;


public class ComputerContext : DbContext
{
    public ComputerContext(DbContextOptions<ComputerContext> options)
        : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Admin> Admins{ get; set; }
    public DbSet<ComputerShop.Models.Admin> Admin_1 { get; set; }
}