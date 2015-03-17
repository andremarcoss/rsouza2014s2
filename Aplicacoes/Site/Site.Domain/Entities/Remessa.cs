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
    public class Remessa
    {
        [Key]
        public string rmsChave { get; set; }
        public string rmsIdentificador { get; set; }
        public string rmsNotaFiscal { get; set; }
        public string rmsTransportadora { get; set; }
        public string rmsMotorista { get; set; }
        public string rmsPedido { get; set; }
        public string rmsRomaneio { get; set; }
        public string rmsEnderecoEntrega { get; set; }
        public string rmsCepEntrega { get; set; }
        public string rmsCidadeEntrega { get; set; }
        public string rmsUFEntrega { get; set; }
        public string rmsObservacaoEnderecoEntrega { get; set; }
        public string rmsDestinatarioEntrega { get; set; }
        public int rmsTotalVolumes { get; set; }
        public int? rmsParentescoRecebedor { get; set; }
        public int? rmsMotivo { get; set; }
        public DateTime? rmsDataBaixa { get; set; }
        public DateTime? rmsDataIntegracao { get; set; }
        public string rmsObservacaoEntrega { get; set; }
        public bool rmsIntegrado { get; set; }
    }
}
