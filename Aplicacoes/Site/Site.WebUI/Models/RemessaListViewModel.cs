using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Site.Domain.Entities;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.WebUI.Models
{
    public class RemessaListViewModel
    {
        public IEnumerable<Remessa> Remessas { get; set; }
    }
}