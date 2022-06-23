using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }

        public DbSet<DeveloperEntity> Developers {get;set;}

        public DbSet<GameEntity> Game {get; set;} 

    }