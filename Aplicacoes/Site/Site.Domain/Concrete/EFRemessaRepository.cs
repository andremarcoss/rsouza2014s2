using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.Domain.Abstract;
using Site.Domain.Entities;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.Domain.Concrete
{
    public class EFRemessaRepository : IRemessaRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Remessa> Remessas
        {
            get
            {
                return context.Remessas;
            }
        }

        public void SalvarRemessa(Remessa remessa)
        {
            Remessa dbEntry = context.Remessas.Find(remessa.rmsChave);
            if (dbEntry != null)
            {
                dbEntry.rmsIdentificador = remessa.rmsIdentificador;
                dbEntry.rmsTotalVolumes = remessa.rmsTotalVolumes;
                dbEntry.rmsNotaFiscal = remessa.rmsNotaFiscal;
                dbEntry.rmsTransportadora = remessa.rmsTransportadora;
                dbEntry.rmsMotorista = remessa.rmsMotorista;
                dbEntry.rmsPedido = remessa.rmsPedido;
                dbEntry.rmsRomaneio = remessa.rmsRomaneio;
                dbEntry.rmsEnderecoEntrega = remessa.rmsEnderecoEntrega;
                dbEntry.rmsCepEntrega = remessa.rmsCepEntrega;
                dbEntry.rmsCidadeEntrega = remessa.rmsCidadeEntrega;
                dbEntry.rmsUFEntrega = remessa.rmsUFEntrega;
                dbEntry.rmsObservacaoEnderecoEntrega = remessa.rmsObservacaoEnderecoEntrega;
                dbEntry.rmsDestinatarioEntrega = remessa.rmsDestinatarioEntrega;
                dbEntry.rmsMotivo = remessa.rmsMotivo;
                dbEntry.rmsParentescoRecebedor = remessa.rmsParentescoRecebedor;
                dbEntry.rmsDataBaixa = remessa.rmsDataBaixa;
                dbEntry.rmsObservacaoEntrega = remessa.rmsObservacaoEntrega;
                dbEntry.rmsDataIntegracao = remessa.rmsDataIntegracao;
                dbEntry.rmsChave = remessa.rmsChave;
                dbEntry.rmsIntegrado = remessa.rmsIntegrado;
            }
            context.SaveChanges();
        }

        public void DeletarRemessa(Remessa remessa)
        { }
    }
}
