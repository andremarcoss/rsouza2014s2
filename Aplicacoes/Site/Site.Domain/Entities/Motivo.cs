using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.Domain.Entities
{
    public class Motivo
    {
        [Key]
        public int mtvId { get; set; }
        public string mtvDescricao { get; set; }
    }
}
