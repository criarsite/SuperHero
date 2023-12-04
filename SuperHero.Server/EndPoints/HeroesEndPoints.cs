using Microsoft.EntityFrameworkCore;
using SuperHero.Server.Data;

namespace SuperHero.Server.EndPoints
{
    public static class HeroesEndPoints
    {
        public static void ConfigureHeroesEndpoints(this WebApplication app)
        {
           

          /*  
           var group = app.MapGroup("/api").WithParameterValidation();
            group.MapGet("/", async (Contexto db) =>
              {
                  return await db.SuperHerois.ToListAsync();
              }).WithName("GetHeros");


            group.MapGet("/{id:int}", async (Contexto db, int id) =>
                {
                return await db.SuperHerois.FirstOrDefaultAsync(c => c.Id == id);
                }).WithName("GetHero");

            app.MapGet("/GetByName/{name}", async (Contexto db, string name) =>
            {
                return await db.SuperHerois.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
                //return await db.SuperHerois.FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            });

            group.MapPost("/", async (SuperHero hero, Contexto db) =>
            {
                db.SuperHerois.Add(hero);
                await db.SaveChangesAsync();

                return Results.CreatedAtRoute("GetHero", new { id = hero.Id }, hero);
            }).WithName("CreateHero");

            group.MapPut("/{id}", async (int id, SuperHero updatedHero, Contexto db) =>
            {
                var result = await db.SuperHerois.Where(hero => hero.Id == id).ExecuteUpdateAsync(updates =>
                                updates.SetProperty(hero => hero.Name, updatedHero.Name)
                                       .SetProperty(hero => hero.FirstName, updatedHero.FirstName)
                                       .SetProperty(hero => hero.LastName, updatedHero.LastName)
                                       .SetProperty(hero => hero.Place, updatedHero.Place));

                return result == 0 ? Results.NotFound() : Results.NoContent();
            }).WithName("UpdateHero");

            group.MapDelete("/{id}", async (int id, Contexto db) =>
            {
                var result = await db.SuperHerois.Where(hero => hero.Id == id).ExecuteDeleteAsync();

                return result == 0 ? Results.NotFound() : Results.NoContent();
            }).WithName("DeleteHero");
           */

         var group = app.MapGroup("/api").WithParameterValidation();
 
    group.MapGet("/", GetSuperHeroes).WithName("GetHeros");
    group.MapGet("/{id:int}", GetSuperHeroById).WithName("GetHero");
    group.MapPost("/", CreateSuperHero).WithName("CreateHero");
    group.MapPut("/{id}", UpdateSuperHero).WithName("UpdateHero");
    group.MapDelete("/{id}", DeleteSuperHero).WithName("DeleteHero");
 

app.MapGet("/GetByName/{name}", GetSuperHeroByName);

async Task<List<SuperHero>> GetSuperHeroes(Contexto db)
{
    return await db.SuperHerois.ToListAsync();
}

async Task<SuperHero> GetSuperHeroById(Contexto db, int id)
{
    return await db.SuperHerois.FirstOrDefaultAsync(c => c.Id == id);
}

async Task<SuperHero> GetSuperHeroByName(Contexto db, string name)
{
   // return await db.SuperHerois.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    return await db.SuperHerois.FirstOrDefaultAsync(c => c.Name.ToLower().StartsWith( name.ToLower()));
}

async Task<IResult> CreateSuperHero(SuperHero hero, Contexto db)
{
    db.SuperHerois.Add(hero);
    await db.SaveChangesAsync();

    return Results.CreatedAtRoute("GetHero", new { id = hero.Id }, hero);
}

async Task<IResult> UpdateSuperHero(int id, SuperHero updatedHero, Contexto db)
{
    var result = await db.SuperHerois.Where(hero => hero.Id == id).ExecuteUpdateAsync(updates =>
                    updates.SetProperty(hero => hero.Name, updatedHero.Name)
                           .SetProperty(hero => hero.FirstName, updatedHero.FirstName)
                           .SetProperty(hero => hero.LastName, updatedHero.LastName)
                           .SetProperty(hero => hero.Place, updatedHero.Place));

    return result == 0 ? Results.NotFound() : Results.NoContent();
}

async Task<IResult> DeleteSuperHero(int id, Contexto db)
{
    var result = await db.SuperHerois.Where(hero => hero.Id == id).ExecuteDeleteAsync();

    return result == 0 ? Results.NotFound() : Results.NoContent();
}

        }
    }
}