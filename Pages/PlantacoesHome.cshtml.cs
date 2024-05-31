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

        public async Task<IActionResult> OnGetAsync()
        {
            GetCookieIdUsuarioLogado();

            if (_idUsuarioLogado == null)
            {
                return RedirectToPage("/Error");
            }

            /// Busca todas as plantações do usuário logado.
            PlantacoesFront = await _context.plantacoes.Where(x => x.UsuarioId == _idUsuarioLogado).OrderBy(x => x.Id).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            GetCookieIdUsuarioLogado();
            PlantacaoCadastro.UsuarioId = _idUsuarioLogado.Value;

            /// Converter a Data do Plantio e a Data da Colheita para UTC (Coordinated Universal Time), devido ao postgresql armazenar a data em UTC.
            PlantacaoCadastro.DataPlantio = PlantacaoCadastro.DataPlantio.ToUniversalTime();
            PlantacaoCadastro.DataColheita = PlantacaoCadastro.DataColheita.ToUniversalTime();

            _context.plantacoes.Add(PlantacaoCadastro);
            await _context.SaveChangesAsync();
            return Page();
        }

        private void GetCookieIdUsuarioLogado()
        {
            var cookie = Request.Cookies["UsuarioLogado"];
            _idUsuarioLogado = cookie == null ? null : int.Parse(cookie);
        }
    }
}
