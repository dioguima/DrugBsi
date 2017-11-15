using ProjetoIntegrador.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador.Models
{
    [Table("Fabricantes")]
    public class Fabricante
    {
        public int ID { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Nome { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Endereco { get; set; }
    }
}