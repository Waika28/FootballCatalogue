using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballCatalogue.Data;
using FootballCatalogue.Models;

namespace FootballCatalogue.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly FootballCatalogue.Data.FootballCatalogueContext _context;
        public HashSet<string> Teams;
        public EditModel(FootballCatalogue.Data.FootballCatalogueContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player =  await _context.Player.FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            Teams = new();
            var players = await _context.Player.ToListAsync();
            foreach (var _player in players)
            {
                if (_player.Team != null)
                {
                    _ = Teams.Add(_player.Team);
                }
            }
            Player = player;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
          return (_context.Player?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
