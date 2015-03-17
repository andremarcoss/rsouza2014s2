using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Domain.Entities;
using System.ComponentModel.DataAnnotations;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.WebUI.Models
{
    public class RemesssaViewModel
    {
        public Remessa remessa { get; set; }
        [Required]
        public int? parentescoId { get; set; }
        [Required]
        public int? motivoId { get; set; }
        public string observacao { get; set; }

    }
}