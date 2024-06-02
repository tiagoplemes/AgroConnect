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

            GadosFront = await _context.gados.Where(x => x.UsuarioId == _idUsuarioLogado).OrderBy(x => x.Id).ToListAsync();

            GadosFront.ForEach(x =>
            {
                if (x.Historico == null && x.HistoricoId == null)
                {
                    x.Historico = new GadoHistorico() { Reproducao = "", Saude = "", Vacina = "" };
                }
                else
                {
                    x.Historico = _context.gadoHistoricos.Find(x.HistoricoId);
                }
            });

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostCreate()
        {
            GetCookieIdUsuarioLogado();
            GadoCadastro.UsuarioId = _idUsuarioLogado.Value;

            if(GadoCadastro.Historico == null)
            {
                GadoCadastro.Historico = new GadoHistorico() { Reproducao = "", Saude = "", Vacina = "" };
            }

            _context.gadoHistoricos.Add(GadoCadastro.Historico);
            await _context.SaveChangesAsync();
            GadoCadastro.Historico = await _context.gadoHistoricos.OrderByDescending(gh => gh.Id).FirstOrDefaultAsync();

            _context.gados.Add(GadoCadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUpdate()
        {
            GetCookieIdUsuarioLogado();
            GadoEditar.UsuarioId = _idUsuarioLogado.Value;

            if (GadoEditar.Historico == null)
            {
                GadoEditar.Historico = new GadoHistorico() { Reproducao = "", Saude = "", Vacina = "" };
            }

            _context.gadoHistoricos.Update(GadoEditar.Historico);
            await _context.SaveChangesAsync();

            _context.gados.Update(GadoEditar);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDelete()
        {
            GetCookieIdUsuarioLogado();
            GadoDeletar.UsuarioId = _idUsuarioLogado.Value;

            var historicoId = await _context.gados.Where(x => x.Id == GadoDeletar.Id).Select(x => x.HistoricoId).FirstOrDefaultAsync();
            var historico = await _context.gadoHistoricos.FindAsync(historicoId);

            _context.gadoHistoricos.Remove(historico);
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
