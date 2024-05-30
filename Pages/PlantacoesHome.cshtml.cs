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

        public async Task<IActionResult> OnGetAsync()
        {
            if (!TempData.ContainsKey("UsuarioLogado"))
            {
                return RedirectToPage("/Error");
            }

            string idUsuarioLogado = TempData["UsuarioLogado"].ToString();

            PlantacoesFront = await _context.plantacoes.Where(x => x.UsuarioId == idUsuarioLogado).OrderBy(x => x.Id).ToListAsync();

            return Page();
        }
    }
}
