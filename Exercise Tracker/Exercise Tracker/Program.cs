using Exercise_Tracker.Controllers;
using Exercise_Tracker.Repositories;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();

// TODO if type not SQLite

var connection = new DatabaseController(config);
var repo = ExerciseRepository.Initialize(connection);

Console.WriteLine("Exercise Repository initialized");

// TODO create a SQLite database service
// TODO create a SQLite repository