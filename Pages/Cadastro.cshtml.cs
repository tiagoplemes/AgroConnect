using AgroConnect.Data;
using AgroConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgroConnect.Pages
{
    public class CadastroModel : PageModel
    {
        private readonly AgroConnectDbContext _context;

        public CadastroModel(AgroConnectDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Usuario Usuarios { get; set; }
        public async Task<IActionResult> OnPost() 
        {
            if(_context.usuarios == null || Usuarios == null)
            {
                return Page();
            }
            _context.usuarios.Add(Usuarios);
            await _context.SaveChangesAsync();

            return RedirectToPage("Login");
        }
    }
}
