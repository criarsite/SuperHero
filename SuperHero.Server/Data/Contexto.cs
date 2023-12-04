using Microsoft.EntityFrameworkCore;

namespace SuperHero.Server.Data;

public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto> options): base(options)
    {
        
    }
    public DbSet<SuperHero> SuperHerois { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<SuperHero>().HasData(
        new SuperHero
        {
            Id = 1,
            Name = "Mulher Maravilha",
            FirstName = "Diana",
            LastName = "Prince",
            Place = "Themyscira"
        },
        new SuperHero
        {
            Id = 2,
            Name = "Viúva Negra",
            FirstName = "Natasha",
            LastName = "Romanoff",
            Place = "Rússia"
        },
        new SuperHero
        {
            Id = 3,
            Name = "Capitã Marvel",
            FirstName = "Carol",
            LastName = "Danvers",
            Place = "Boston"
        },
        new SuperHero
        {
            Id = 4,
            Name = "Feiticeira Escarlate",
            FirstName = "Wanda",
            LastName = "Maximoff",
            Place = "Sokovia"
        },
        new SuperHero
        {
            Id = 5,
            Name = "Tempestade",
            FirstName = "Ororo",
            LastName = "Munroe",
            Place = "Cairo"
        }
    );
}

} 