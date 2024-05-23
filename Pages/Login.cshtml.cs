using AgroConnect.Data;
using AgroConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgroConnect.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AgroConnectDbContext _context;

        public LoginModel(AgroConnectDbContext context)
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
            if (_context.usuarios == null || Usuarios == null)
            {
                return Page();
            }

            List<Usuario> Comparar = await _context.usuarios.ToListAsync();

            bool Acesso = Comparar.Any(x =>  Usuarios.Email == x.Email && Usuarios.Senha == x.Senha);

            if (Acesso)
            {
                return RedirectToPage("Home");
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}
