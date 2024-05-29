using AgroConnect.Data;
using AgroConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgroConnect.Pages
{
    public class PlantacoesHomeModel : PageModel
    {
        private readonly AgroConnectDbContext _context;

        public PlantacoesHomeModel(AgroConnectDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Plantacao> PlantacoesFront { get; set; }

        public  IActionResult OnGet()
        {
            if (!TempData.ContainsKey("UsuarioLogado"))
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public async Task OnGetPlantacoesAsync()
        {
            PlantacoesFront = await _context.plantacoes.ToListAsync();
        }
    }
}
