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
    [Table("Medicamentos")]
    public class Medicamento
    {
        public int ID { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Descricao { get; set; }

        [DisplayName("Conteúdo")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Conteudo { get; set; }

        [DisplayName("Conservação")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Conservacao { get; set; }

        [DisplayName("Indicação")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Indicacao { get; set; }

        [DisplayName("Contraindicação")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Contraindicacao { get; set; }

        [DisplayName("Modo de Utilização")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string ModoUtilizacao { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Tipo { get; set; }

        [DisplayName("Faixa Etária")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string FaixaEtaria { get; set; }

        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public string Bula { get; set; }

        [DisplayName("Quantidade em Estoque")]
        [Required(ErrorMessage = Constantes.MENSAGEM_CAMPO_VAZIO_DEFAULT)]
        public int QuantidadeEstoque { get; set; }

        [DisplayName("Fabricante")]
        public int FabricanteID { get; set; }

        public virtual Fabricante Fabricante { get; set; }
    }
}