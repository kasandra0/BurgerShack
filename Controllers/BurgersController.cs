using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {
    public List<Burger> Burgers = new List<Burger>()
    {
      new Burger("Mark Burger", "with bacon and other stuff", 7.59f),
      new Burger("Jake Burger", "Comes with fries", 8.54f),
      new Burger("D$ Burger", "Vegetarian Burger", 5.99f)
    };
    // GET api/Burgers
    [HttpGet]
    public IEnumerable<Burger> Get()
    {
      return Burgers;
    }

    // GET api/Burgers/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      try
      {
        return Burgers[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }

    // POST api/Burgers
    [HttpPost]
    public ActionResult<List<Burger>> Post([FromBody] Burger burger)
    {
      Burgers.Add(burger);
      return Burgers;
    }

    // PUT api/Burgers/5
    [HttpPut("{id}")]
    public ActionResult<List<Burger>> Put(int id, [FromBody] Burger burger)
    {
      try
      {
        Burgers[id] = burger;
        return Burgers;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }

    // DELETE api/Burgers/5
    [HttpDelete("{id}")]
    public ActionResult<List<Burger>> Delete(int id)
    {
      try
      {
        Burgers.Remove(Burgers[id]);
        return Burgers;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }
  }
}
