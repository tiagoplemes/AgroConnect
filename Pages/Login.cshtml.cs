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
        public Usuario UsuarioFront { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (_context.usuarios == null || UsuarioFront == null)
            {
                return Page();
            }

            List<Usuario> Comparar = await _context.usuarios.ToListAsync();

            bool Acesso = Comparar.Any(x => UsuarioFront.Email == x.Email && UsuarioFront.Senha == x.Senha);

            if (Acesso)
            {
                Usuario usuarioLogando = await _context.usuarios.FirstOrDefaultAsync(NomeIgual => (NomeIgual.Email == UsuarioFront.Email && UsuarioFront.Senha == NomeIgual.Senha));

                // Put the id of the logged user on a cookie for future use

                SetIdCookie(usuarioLogando.Id);

                return RedirectToPage("Home");
            }
            else
            {
                return RedirectToPage("Login");
            }
        }

        public void SetIdCookie(int id)
        {
            Response.Cookies.Append("UsuarioLogado", id.ToString());
        }
        
    }
}
