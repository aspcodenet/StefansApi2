using Microsoft.AspNetCore.Mvc;
using StefansApi2.Data;
using StefansApi2.Models;

namespace StefansApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        public SuperHeroController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //private static readonly List<SuperHero> heroes = new List<SuperHero>
        //{
        //    new SuperHero
        //    {
        //        Id = 1,
        //        Name = "Spiderman",
        //        FirstName = "Peter",
        //        SurName = "Parker",
        //        City = "New York"
        //    },
        //    new SuperHero
        //    {
        //        Id = 2,
        //        Name = "Ironman",
        //        FirstName = "Tony",
        //        SurName = "Stark",
        //        City = "New York"
        //    }
        //};
        private readonly ApplicationDbContext dbContext;

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(dbContext.SuperHeroes);
        }
        [HttpPost]
        public async Task<ActionResult<SuperHero>> PostHero(NewSuperHero newHero)
        {
            SuperHero hero = new SuperHero
            {
                City = newHero.City,
                FirstName = newHero.FirstName,
                Name = newHero.Name,
                SurName = newHero.SurName
            };
            dbContext.SuperHeroes.Add(hero);
            return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, UpdateSuperHero hero)
        {
            var heroToUpdate = dbContext.SuperHeroes.FirstOrDefault(s => s.Id == id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }
            heroToUpdate.City = hero.FirstName;
            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.SurName = hero.SurName;
            dbContext.SaveChanges();
            return Ok(heroToUpdate);
            
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var hero = dbContext.SuperHeroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            dbContext.SuperHeroes.Remove(hero);
            dbContext.SaveChanges();
            return NoContent();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = dbContext.SuperHeroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }
    }
}
