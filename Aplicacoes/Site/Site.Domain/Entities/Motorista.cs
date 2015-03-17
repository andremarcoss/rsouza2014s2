using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.Domain.Entities
{
    public class Motorista
    {
        [Key]
        public string mtCpf { get; set; }
        public string mtNome { get; set; }
        public string mtSenha { get; set; }
    }
}
