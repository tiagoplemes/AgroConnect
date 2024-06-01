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
                x.DataPlantio = x.DataPlantio.Date;
                x.DataColheita = x.DataColheita.Date;
            });

            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostCreate()
        {
            GetCookieIdUsuarioLogado();
            PlantacaoCadastro.UsuarioId = _idUsuarioLogado.Value;

            /// Converter a Data do Plantio e a Data da Colheita para UTC (Coordinated Universal Time), devido ao postgresql armazenar a data em UTC.
            PlantacaoCadastro.DataPlantio = PlantacaoCadastro.DataPlantio.ToUniversalTime();
            PlantacaoCadastro.DataColheita = PlantacaoCadastro.DataColheita.ToUniversalTime();

            _context.plantacoes.Add(PlantacaoCadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction("OnGetAsync");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostUpdate()
        {
            GetCookieIdUsuarioLogado();
            /// Converter a Data do Plantio e a Data da Colheita para UTC (Coordinated Universal Time), devido ao postgresql armazenar a data em UTC.
            PlantacaoEditar.DataPlantio = PlantacaoEditar.DataPlantio.ToUniversalTime();
            PlantacaoEditar.DataColheita = PlantacaoEditar.DataColheita.ToUniversalTime();
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
    }
}
