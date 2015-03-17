using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Data;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace WebService
{
    /// <summary>
    /// Summary description for wsTcc2014
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsRemessas : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld(string mensagem)
        //{
        //    return mensagem;
        //}


        [WebMethod(Description = "Utilizado para fazer o envio de remessas ao sistema de gerenciamento de entregas, remessa a remessa")]
        public string EnviarRemessa(string transportadoraCnpj, string chave, string motoristaCpf, string motoristaNome, string romaneio, string destinatarioEntrega,
                string identificador, string notaFiscal, string pedido, string totalVolumes, string enderecoEntrega, string cidadeEntrega, string cepEntrega, string ufEntrega, string observacaoEnderecoEntrega
            )
        {
            string retorno = string.Empty;
            envio remessaEnvio = new envio();
            retornoEnvio retEnvio = new retornoEnvio();
            if (!ValidarTransportadora(transportadoraCnpj, chave))
            {
                retEnvio.retornoOperacao.Add(new retornoEnvioRetornoOperacao { mensagem = "Chave de acesso e/ou CNPJ inválidos".ToUpper(), status = "3" });
            }
            else
            {
                remessaEnvio.chave = chave;
                remessaEnvio.transportadoraCnpj = transportadoraCnpj;

                envioRemessa remessa = new envioRemessa();
                remessa.identificador = identificador;
                remessa.notaFiscal = notaFiscal;
                remessa.pedido = pedido;
                remessa.totalVolumes = totalVolumes;
                remessa.romaneio = romaneio;
                remessa.motoristaCpf = motoristaCpf;
                remessa.motoristaNome = motoristaNome;
                remessa.enderecoEntrega = enderecoEntrega;
                remessa.cepEntrega = cepEntrega;
                remessa.cidadeEntrega = cidadeEntrega;
                remessa.ufEntrega = ufEntrega;
                remessa.observacaoEnderecoEntrega = observacaoEnderecoEntrega;
                remessa.destinatarioEntrega = destinatarioEntrega;

                retEnvio.retornoOperacao.Add(remessa.GravarRemessa(transportadoraCnpj));
            }

            retorno = new Serializer().XML(retEnvio);

            return retorno;
        }

        [WebMethod(Description = "Utilizado para fazer o envio de remessas ao sistema de gerenciamento de entregas, através de um arquivo XML")]
        public string EnviarRemessas(string xmlEnvio)
        {
            string retorno = string.Empty;

            envio remessasEnvio = null;
            retornoEnvio retEnvio = new retornoEnvio();
            Serializer xmlSerializer = new Serializer();

            remessasEnvio = xmlSerializer.Classe<envio>(xmlEnvio);

            if (remessasEnvio != null)
            {
                if (!ValidarTransportadora(remessasEnvio.transportadoraCnpj, remessasEnvio.chave))
                {
                    retEnvio.retornoOperacao.Add(new retornoEnvioRetornoOperacao { mensagem = "Chave de acesso e/ou CNPJ inválidos".ToUpper(), status = "3" });
                }
                else
                    foreach (envioRemessa rem in remessasEnvio.remessas)
                        retEnvio.retornoOperacao.Add(rem.GravarRemessa(remessasEnvio.transportadoraCnpj));
            }
            else
            {
                retEnvio.retornoOperacao.Add(new retornoEnvioRetornoOperacao { mensagem = "Erro ao processar o XML de entrada".ToUpper(), status = "5" });
            }
            retorno = xmlSerializer.XML(retEnvio);
            return retorno;
        }

        [WebMethod(Description = "Utilizado para consultar as tentativas de entrega das remessas")]
        public string TentativasFinalizadas(string transportadoraCnpj, string chave, string romaneio, string motoristaCpf)
        {
            string retorno = string.Empty;
            Conexao conexao = new Conexao();

            retornoConsulta retConsulta = new retornoConsulta();
            if (!ValidarTransportadora(transportadoraCnpj, chave))
            {
                retConsulta.status = "3";
                retConsulta.mensagem = "Chave de acesso e/ou CNPJ inválidos".ToUpper();
                retConsulta.total = "0";
            }
            else
            {
                StringBuilder sbr = new StringBuilder();
                sbr.AppendLine("SELECT");
                sbr.AppendLine("rmsMotorista[motoristaCpf],");
                sbr.AppendLine("rmsRomaneio[romaneio],");
                sbr.AppendLine("rmsIdentificador[identificador],");
                sbr.AppendLine("rmsNotaFiscal[notaFiscal],");
                sbr.AppendLine("rmsPedido[pedido],");
                sbr.AppendLine("rmsDataBaixa[dataEntrega],");
                sbr.AppendLine("rmsMotivo[idOcorrencia],");
                sbr.AppendLine("mtvDescricao[ocorrencia],");
                sbr.AppendLine("prcDescricaoParentesco[parentesco],");
                sbr.AppendLine("rmsObservacaoEntrega[observacao],");
                sbr.AppendLine("rmsChave[protocolo]");
                sbr.AppendLine("FROM Remessa");
                sbr.AppendLine("JOIN Transportadora ON tpsCnpj = rmsTransportadora");
                sbr.AppendLine("JOIN Motivo ON rmsMotivo = mtvId");
                sbr.AppendLine("LEFT JOIN Parentesco ON rmsParentescoRecebedor = prcId");
                sbr.AppendLine("WHERE rmsMotivo IS NOT NULL");
                sbr.AppendLine("AND rmsDataBaixa IS NOT NULL");
                sbr.AppendLine("AND ISNULL(rmsIntegrado,0) = 0");
                sbr.AppendLine(string.Format("AND tpsChaveAcesso = '{0}'", chave));
                sbr.AppendLine(string.Format("AND tpsCnpj = '{0}'", transportadoraCnpj));

                //Opcionais
                if (!string.IsNullOrEmpty(romaneio))
                    sbr.AppendLine(string.Format("AND rmsRomaneio = '{0}'", romaneio));
                if (!string.IsNullOrEmpty(motoristaCpf))
                    sbr.AppendLine(string.Format("AND rmsMotorista = '{0}'", motoristaCpf));

                DataTable dtTable;
                try
                {
                    dtTable = conexao.ExecutarComandoDataTable(sbr.ToString());
                    if (conexao.TemDados(dtTable))
                    {

                        retConsulta.status = "6";
                        retConsulta.mensagem = "CONSULTA FINALIZADA COM SUCESSO";
                        retConsulta.total = dtTable.Rows.Count.ToString();
                        foreach (DataRow dtRow in dtTable.Rows)
                        {
                            retornoConsultaRemessa remessa = new retornoConsultaRemessa();
                            remessa.motoristaCpf = dtRow["motoristaCpf"].ToString().Trim();
                            remessa.romaneio = dtRow["romaneio"].ToString().Trim();
                            remessa.identificador = dtRow["identificador"].ToString().Trim();
                            remessa.notaFiscal = dtRow["notaFiscal"].ToString().Trim();
                            remessa.pedido = dtRow["pedido"].ToString().Trim();
                            remessa.dataEntrega = DateTime.Parse(dtRow["dataEntrega"].ToString().Trim());
                            remessa.ocorrencia = dtRow["ocorrencia"].ToString().Trim();
                            remessa.idOcorrencia = dtRow["idOcorrencia"].ToString().Trim();
                            remessa.parentesco = dtRow["parentesco"].ToString().Trim();
                            remessa.observacao = dtRow["observacao"].ToString().Trim();
                            remessa.protocolo = dtRow["protocolo"].ToString().Trim();

                            retConsulta.remessas.Add(remessa);
                        }
                    }
                    else
                    {
                        retConsulta.status = "7";
                        retConsulta.mensagem = "NÃO FORAM ENCONTRADAS REMESSAS FINALIZADAS";
                    }
                }
                catch { }
            }
            retorno = new Serializer().XML(retConsulta);
            return retorno;
        }

        [WebMethod(Description = "Utilizado para confirmar o recebimento da informação referente a tentativa de entrega da remessa")]
        public string MarcarRemessaRecebida(string protocolo)
        {
            string retorno = string.Empty;
            retornoMarcarRemessaRecebida marcarRemessa = new retornoMarcarRemessaRecebida();
            Conexao conexao = new Conexao();
            StringBuilder sbr = new StringBuilder();
            sbr.AppendLine("SELECT COUNT(0)[TOTAL] FROM Remessa (NOLOCK)");
            sbr.AppendLine("WHERE ISNULL(rmsIntegrado,0) = 0");
            sbr.AppendLine(string.Format("AND rmsChave = '{0}'", protocolo));
            DataRow dtRow = conexao.ExecutarComandoDataRow(sbr.ToString());
            if (conexao.TemDados(dtRow))
            {
                if (dtRow["TOTAL"].ToString().Equals("0"))
                {
                    sbr.Clear();
                    sbr.AppendLine("SELECT COUNT(0)[TOTAL] FROM Remessa (NOLOCK)");
                    sbr.AppendLine(string.Format("WHERE rmsChave = '{0}'", protocolo));
                    dtRow = conexao.ExecutarComandoDataRow(sbr.ToString());
                    if (conexao.TemDados(dtRow))
                    {
                        if (dtRow["TOTAL"].ToString().Equals("0"))
                        {
                            marcarRemessa.status = "11";
                            marcarRemessa.mensagem = "PROTOCOLO NÃO EXISTE";
                        }
                        else
                        {
                            marcarRemessa.status = "12";
                            marcarRemessa.mensagem = "REMESSA JÁ FOI MARCADA COMO RECEBIDA";
                        }
                    }
                }
                else
                {
                    sbr.Clear();
                    sbr.AppendLine(string.Format("UPDATE Remessa SET rmsIntegrado = 1 WHERE rmsChave = '{0}'", protocolo));
                    conexao.ExecutarComandoDataRow(sbr.ToString());
                    marcarRemessa.status = "10";
                    marcarRemessa.mensagem = "REMESSA MARCADA COMO RECEBIDA";
                }

            }

            retorno = new Serializer().XML(marcarRemessa);
            return retorno;
        }

        private bool ValidarTransportadora(string transportadoraCnpj, string chave)
        {
            bool retorno = false;
            Conexao conexao = new Conexao();

            StringBuilder sbr = new StringBuilder();
            sbr.AppendLine("SELECT COUNT(0) [TOTAL] FROM Transportadora");
            sbr.AppendLine(string.Format("WHERE tpsCnpj = '{0}'", transportadoraCnpj));
            sbr.AppendLine(string.Format("AND tpsChaveAcesso = '{0}'", chave));
            sbr.AppendLine("AND tpsAtivo = 1");
            DataRow dtRow = conexao.ExecutarComandoDataRow(sbr.ToString());

            if (conexao.TemDados(dtRow))
                retorno = (dtRow["TOTAL"].ToString().Equals("1")) ? true : false;

            return retorno;
        }
    }
}
