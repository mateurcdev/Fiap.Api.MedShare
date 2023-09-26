using Fiap.Api.MedShare.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.MedShare.Repository.Context;

public class DataBaseContext : DbContext
{

    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    protected DataBaseContext()
    {
    }
    public DbSet<RepresentanteModel> Representante { get; set; }
}