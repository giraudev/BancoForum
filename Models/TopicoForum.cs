using System;

namespace webforum.Models
{
    public class TopicoForum
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }


    }
}