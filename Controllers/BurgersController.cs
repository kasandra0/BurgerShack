using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {
    private readonly BurgerRepository _burgRepo;
    public BurgersController(BurgerRepository repo)
    {
      _burgRepo = repo;
    }
    public List<Burger> Burgers = new List<Burger>();
    // GET api/Burgers
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      return Ok(_burgRepo.GetAll());
    }

    // GET api/Burgers/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      Burger result = _burgRepo.GetBurgerById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
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
