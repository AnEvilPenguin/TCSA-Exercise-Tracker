using Dapper;
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
        using var connection = _controller.GetConnection();

        var sql = """
                  SELECT *
                  FROM Exercise 
                  WHERE Id = @id;
                  """;
        
        var response = connection.QuerySingle<Exercise>(sql, new { id });
        
        return response;
    }

    public IEnumerable<Exercise> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Exercise entity)
    {
        using var connection = _controller.GetConnection();

        var sql = """
                  INSERT INTO Exercise (DateStart, DateEnd, Comments)
                  VALUES (@DateStart, @DateEnd, @Comments)
                  """;
        
        connection.Execute(sql, entity);
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