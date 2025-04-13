using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace datntdev.Microservices.EntityFrameworkCore;

public static class MicroservicesDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<MicroservicesDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<MicroservicesDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
