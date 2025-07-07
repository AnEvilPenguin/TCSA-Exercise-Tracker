using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Exercise_Tracker.Controllers;

internal class DatabaseController
{
    private IConfiguration _configuration;

    internal DatabaseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    internal SqliteConnection GetConnection() =>
        new (_configuration.GetConnectionString("Exercise"));
}