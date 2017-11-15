using ProjetoIntegrador.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador.Models
{
    [Table("Quimicos")]
    public class Quimico
    {
        public int ID { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Nome { get; set; }
    }
}