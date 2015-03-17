using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Tcc2014.Domain.Entities
{
    public class Remessas
    {
        public List<Remessa> itens { get; set; }
        public Motorista motorista { get; set; }

        public Remessas(Motorista motorista)
        {
            //Conexao.Conexao conexao = new Conexao.Conexao();
            //itens = new List<Remessa>();
            //this.motorista = motorista;

            //StringBuilder sbr = new StringBuilder();
            //sbr.AppendLine("SELECT ");
            //sbr.AppendLine("COUNT(0)[rmsEntregas],");
            //sbr.AppendLine("MIN(rmsIdentificador)[rmsIdentificador],");
            //sbr.AppendLine("rmsNotaFiscal,");
            //sbr.AppendLine("rmsTransportadora,");
            //sbr.AppendLine("rmsMotorista,");
            //sbr.AppendLine("rmsPedido,");
            //sbr.AppendLine("rmsCepEntrega,");
            //sbr.AppendLine("rmsDestinatarioEntrega,");
            //sbr.AppendLine("rmsEnderecoEntrega,");
            //sbr.AppendLine("rmsCidadeEntrega,");
            //sbr.AppendLine("rmsUFEntrega,");
            //sbr.AppendLine("rmsObservacaoEnderecoEntrega,");
            //sbr.AppendLine("pr.prcDescricaoParentesco [rmsParentescoRecebedor],");
            //sbr.AppendLine("mv.mtvDescricao[rmsMotivo],");
            //sbr.AppendLine("rmsObservacaoEntrega,");
            //sbr.AppendLine("rmsDataBaixa");
            //sbr.AppendLine("FROM Remessas rms");
            //sbr.AppendLine("LEFT JOIN Parentesco pr ON prcId  = rmsParentescoRecebedor");
            //sbr.AppendLine("LEFT JOIN Motivos mv ON mtvId = rmsMotivo");
            //sbr.AppendLine(string.Format("WHERE rmsMotorista = '{0}'", this.motorista.mtCpf));
            //sbr.AppendLine("GROUP BY ");
            //sbr.AppendLine("rmsNotaFiscal,");
            //sbr.AppendLine("rmsTransportadora,");
            //sbr.AppendLine("rmsMotorista,");
            //sbr.AppendLine("rmsPedido,");
            //sbr.AppendLine("rmsCepEntrega,");
            //sbr.AppendLine("rmsDestinatarioEntrega,");
            //sbr.AppendLine("rmsEnderecoEntrega,");
            //sbr.AppendLine("rmsCidadeEntrega,");
            //sbr.AppendLine("rmsUFEntrega,");
            //sbr.AppendLine("rmsObservacaoEnderecoEntrega,");
            //sbr.AppendLine("pr.prcDescricaoParentesco,");
            //sbr.AppendLine("mv.mtvDescricao,");
            //sbr.AppendLine("rmsObservacaoEntrega,");
            //sbr.AppendLine("rmsDataBaixa");
            //sbr.AppendLine("ORDER BY rmsCepEntrega,rmsEnderecoEntrega,rmsNotaFiscal");
            //DataTable dtTable = conexao.ExecutarComandoDataTable(sbr.ToString());
            //if (conexao.TemDados(dtTable))
            //{
            //    foreach (DataRow dtRow in dtTable.Rows)
            //        itens.Add(new Remessa(dtRow));
            //}
        }

        public Remessas()
        {
            itens = new List<Remessa>();
        }
    }
}
