using CC230286_DESAFIO_03.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CC230286_DESAFIO_03.Tests;

public static class Setup
{
    public static ApplicationDbContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationDbContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}