using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FootballCatalogue.Data;
using FootballCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballCatalogue.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly FootballCatalogue.Data.FootballCatalogueContext _context;
        public HashSet<string> Teams;

        public CreateModel(FootballCatalogue.Data.FootballCatalogueContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Teams = new();
            var players = await _context.Player.ToListAsync();
            foreach (var player in players)
            {
                if (player.Team != null)
                {
                    _ = Teams.Add(player.Team);
                }
            }
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Player == null || Player == null)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
