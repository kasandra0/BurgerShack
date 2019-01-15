
using System;
using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    // private readonly FakeDB dB;

    public Burger GetBurgerById(int id)
    {
      try
      {
        return FakeDB.Burgers[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Burger AddBurger(Burger goodBurger)
    {
      FakeDB.Burgers.Add(goodBurger);
      return goodBurger;
    }
    public Burger EditBurger(int id, Burger burg)
    {
      try
      {
        FakeDB.Burgers[id] = burg;
        return burg;
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
        FakeDB.Burgers.Remove(FakeDB.Burgers[id]);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }
    public BurgerRepository()
    {

    }
  }
}