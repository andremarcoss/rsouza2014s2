using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Domain.Entities;
using System.ComponentModel.DataAnnotations;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.WebUI.Models
{
    public class AlterarSenhaViewModel
    {
        public Motorista motorista { get; set; }

        [Required(ErrorMessage = "Informe a nova senha!")]
        public string novaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha!")]
        public string confirmacaoSenha { get; set; }
    }
}