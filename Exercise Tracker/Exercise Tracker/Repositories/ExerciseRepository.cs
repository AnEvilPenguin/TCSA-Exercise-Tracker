using Exercise_Tracker.Controllers;
using Exercise_Tracker.Model;

namespace Exercise_Tracker.Repositories;

internal class ExerciseRepository : IRepository<Exercise>
{
    // TODO DatabaseService - picks up config and ensures database itself exists
    // Connect (FWIW)
    // Ensure that table exists
    private DatabaseController _controller;

    private ExerciseRepository(DatabaseController controller)
    {
        _controller = controller;
    }

    public static ExerciseRepository Initialize(DatabaseController controller)
    {
        using var connection = controller.GetConnection();
        
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = """
                              CREATE TABLE IF NOT EXISTS Exercise (
                                  Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                  DateStart TEXT NOT NULL,
                                  DateEnd TEXT,
                                  Comments TEXT 
                              );
                              """;
        
        command.ExecuteNonQuery();
        
        return new ExerciseRepository(controller);
    }
    
    public Exercise GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Exercise> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Exercise entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Exercise entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Exercise entity)
    {
        throw new NotImplementedException();
    }
}