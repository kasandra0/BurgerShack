
using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack
{

  static class FakeDB
  {

    public static List<Burger> Burgers = new List<Burger>(){
      new Burger("Mark Burger", "with bacon and other stuff", 7.59f),
      new Burger("Jake Burger", "Comes with fries", 8.54f),
      new Burger("D$ Burger", "Vegetarian Burger", 5.99f)
    };


  }
}