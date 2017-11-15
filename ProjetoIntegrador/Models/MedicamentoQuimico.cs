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
    [Table("MedicamentosQuimicos")]
    public class MedicamentoQuimico
    {
        public int ID { get; set; }

        [DisplayName("Medicamento")]
        public int MedicamentoId { get; set; }

        [DisplayName("Químico")]
        public int QuimicoId { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public float Quantidade { get; set; }

        public virtual Medicamento Medicamento { get; set; }

        [DisplayName("Químico")]
        public virtual Quimico Quimico { get; set; }
    }
}