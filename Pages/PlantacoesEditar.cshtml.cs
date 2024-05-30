using AgroConnect.Data;
using AgroConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgroConnect.Pages
{
    public class PlantacoesEditarModel : PageModel
    {
        private readonly AgroConnectDbContext _context;

        public PlantacoesEditarModel(AgroConnectDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plantacao PlantacoesFront { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!TempData.ContainsKey("UsuarioLogado"))
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            _context.plantacoes.Add(PlantacoesFront);
            await _context.SaveChangesAsync();
            return RedirectToPage("PlantacoesHome");
        }
    }
}
