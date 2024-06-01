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

        private int? _idUsuarioLogado;

        public PlantacoesHomeModel(AgroConnectDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Plantacao> PlantacoesFront { get; set; }

        [BindProperty]
        public Plantacao PlantacaoCadastro { get; set; }
        
        [BindProperty]
        public Plantacao PlantacaoEditar { get; set; }
        [BindProperty]
        public Plantacao PlantacaoDeletar { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            GetCookieIdUsuarioLogado();

            if (_idUsuarioLogado == null)
            {
                return RedirectToPage("/Error");
            }

            /// Busca todas as plantações do usuário logado.
            PlantacoesFront = await _context.plantacoes.Where(x => x.UsuarioId == _idUsuarioLogado).OrderBy(x => x.Id).ToListAsync();

            PlantacoesFront.ForEach(x => {
                ConvertaDataUTCParaLocal(x);
            });

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostCreate()
        {
            GetCookieIdUsuarioLogado();
            PlantacaoCadastro.UsuarioId = _idUsuarioLogado.Value;

            ConvertaDataLocalParaUTC(PlantacaoCadastro);

            _context.plantacoes.Add(PlantacaoCadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUpdate()
        {
            GetCookieIdUsuarioLogado();
            
            ConvertaDataLocalParaUTC(PlantacaoEditar);
            PlantacaoEditar.UsuarioId = _idUsuarioLogado.Value;

            _context.plantacoes.Update(PlantacaoEditar);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            GetCookieIdUsuarioLogado();
            PlantacaoDeletar.UsuarioId = _idUsuarioLogado.Value;

            Plantacao Plantacao = await _context.plantacoes.FirstOrDefaultAsync(x => x.Id == PlantacaoDeletar.Id);

            _context.plantacoes.Remove(Plantacao);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        private void GetCookieIdUsuarioLogado()
        {
            var cookie = Request.Cookies["UsuarioLogado"];
            _idUsuarioLogado = cookie == null ? null : int.Parse(cookie);
        }

        private Plantacao ConvertaDataLocalParaUTC(Plantacao plantacao)
        {
            plantacao.DataPlantio = plantacao.DataPlantio.ToUniversalTime();
            plantacao.DataColheita = plantacao.DataColheita.ToUniversalTime();

            return plantacao;
        }

        private Plantacao ConvertaDataUTCParaLocal(Plantacao plantacao)
        {
            plantacao.DataPlantio = plantacao.DataPlantio.ToLocalTime();
            plantacao.DataColheita = plantacao.DataColheita.ToLocalTime();

            return plantacao;
        }
    }
}
