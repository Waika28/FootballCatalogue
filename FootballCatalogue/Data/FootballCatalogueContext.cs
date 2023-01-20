using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootballCatalogue.Models;

namespace FootballCatalogue.Data
{
    public class FootballCatalogueContext : DbContext
    {
        public FootballCatalogueContext (DbContextOptions<FootballCatalogueContext> options)
            : base(options)
        {
        }

        public DbSet<FootballCatalogue.Models.Player> Player { get; set; } = default!;
    }
}
