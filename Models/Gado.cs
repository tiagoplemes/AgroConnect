﻿using System.ComponentModel.DataAnnotations;

namespace AgroConnect.Models
{
    public class Gado
    {
        [Key]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Raca { get; set; }

        public double Peso { get; set; }

        public double Dono { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public GadoHistorico Historico { get; set; }
    }
}
