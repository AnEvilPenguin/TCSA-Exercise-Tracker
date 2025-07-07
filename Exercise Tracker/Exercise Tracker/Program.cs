using Exercise_Tracker;
using Exercise_Tracker.Controllers;
using Exercise_Tracker.Model;
using Exercise_Tracker.Repositories;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();

var connectionType = Enum.Parse<ConnectionType>(config.GetSection("ConnectionType").Value ?? "Sqlite");

IRepository<Exercise>? repo = null;

if (connectionType == ConnectionType.Sqlite) {
    var connection = new DatabaseController(config);
    repo = ExerciseRepository.Initialize(connection);
}

if (repo == null)
{
    throw new Exception("Unable to initialize repository");
}

Console.WriteLine("Exercise Repository initialized");

repo.Add(new Exercise()
{
    DateStart = DateTime.Now,
});

Console.WriteLine("New exercise created");

var ex = repo.GetById(1);

Console.WriteLine($"Found exercise { ex.Id }, started: { ex.DateStart }, ended: { ex.DateEnd }");

// TODO create a SQLite database service
// TODO create a SQLite repository