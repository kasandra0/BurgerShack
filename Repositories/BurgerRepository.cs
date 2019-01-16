
using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _dB;

    public IEnumerable<Burger> GetAll()
    {
      return _dB.Query<Burger>("SELECT * FROM Burgers3");
    }
    public Burger GetBurgerById(int id)
    {
      return _dB.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers3 WHERE id = @id", new { id });
    }
    public Burger AddBurger(Burger newBurger)
    {
      int id = _dB.ExecuteScalar<int>(@"
 	INSERT INTO burgers3 (name, description, price) VALUES (@Name, @Description, @Price); 
 	SELECT LAST_INSERT_ID();", newBurger);
      newBurger.Id = id;
      return newBurger;
    }
    public Burger EditBurger(int id, Burger burg)
    {
      try
      {
        return _dB.QueryFirstOrDefault<Burger>($@"
        UPDATE burgers3 SET
        Name = @Name, 
        Description = @Description,
        Price = @Price
        WHERE Id =@id;
        SELECT * FROM burgers3 WHERE Id = @id;", burg);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public bool DeleteBurger(int id)
    {
      try
      {
        _dB.QueryFirstOrDefault($@"DELETE FROM burgers3 WHERE Id = @id;", new { id });
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }
    public BurgerRepository(IDbConnection dB)
    {
      _dB = dB;
    }
  }
}