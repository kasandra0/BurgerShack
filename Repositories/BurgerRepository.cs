
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
    // public Burger AddBurger(Burger goodBurger)
    // {
    //   FakeDB.Burgers.Add(goodBurger);
    //   return goodBurger;
    // }
    // public Burger EditBurger(int id, Burger burg)
    // {
    //   try
    //   {
    //     FakeDB.Burgers[id] = burg;
    //     return burg;
    //   }
    //   catch (Exception ex)
    //   {
    //     Console.WriteLine(ex);
    //     return null;
    //   }
    // }
    // public bool DeleteBurger(int id)
    // {
    //   try
    //   {
    //     FakeDB.Burgers.Remove(FakeDB.Burgers[id]);
    //     return true;
    //   }
    //   catch (Exception ex)
    //   {
    //     Console.WriteLine(ex);
    //     return false;
    //   }
    // }
    public BurgerRepository(IDbConnection dB)
    {
      _dB = dB;
    }
  }
}