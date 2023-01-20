using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FootballCatalogue.Data;
using FootballCatalogue.Models;

namespace FootballCatalogue.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly FootballCatalogue.Data.FootballCatalogueContext _context;

        public IndexModel(FootballCatalogue.Data.FootballCatalogueContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                Player = await _context.Player.ToListAsync();
            }
        }
    }
}
