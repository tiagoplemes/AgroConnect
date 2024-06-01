using AgroConnect.Data;
using AgroConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgroConnect.Pages
{
    public class GadoHomeModel : PageModel
    {
        private readonly AgroConnectDbContext _context;

        private int? _idUsuarioLogado;
        public GadoHomeModel(AgroConnectDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Gado> GadosFront { get; set; }

        [BindProperty]
        public Gado GadoCadastro { get; set; }

        [BindProperty]
        public Gado GadoEditar { get; set; }

        [BindProperty]
        public Gado GadoDeletar { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            GetCookieIdUsuarioLogado();

            if (_idUsuarioLogado == null)
            {
                return RedirectToPage("/Error");
            }

            /// Busca todas as plantações do usuário logado.
            GadosFront = await _context.gados.Where(x => x.UsuarioId == _idUsuarioLogado).OrderBy(x => x.Id).ToListAsync();

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostCreate()
        {
            GetCookieIdUsuarioLogado();
            GadoCadastro.UsuarioId = _idUsuarioLogado.Value;

            GadoCadastro.Historico = new GadoHistorico() { Reproducao = "", Saude = "", Vacina = "" };

            _context.gados.Add(GadoCadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUpdate()
        {
            GetCookieIdUsuarioLogado();
            GadoEditar.UsuarioId = _idUsuarioLogado.Value;

            _context.gados.Update(GadoEditar);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDelete()
        {
            GetCookieIdUsuarioLogado();
            GadoDeletar.UsuarioId = _idUsuarioLogado.Value;

            _context.gados.Remove(GadoDeletar);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        private void GetCookieIdUsuarioLogado()
        {
            var cookie = Request.Cookies["UsuarioLogado"];
            _idUsuarioLogado = cookie == null ? null : int.Parse(cookie);
        }
    }
}
