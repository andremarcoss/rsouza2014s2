using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Domain.Abstract;
using Site.Domain.Entities;
using Site.WebUI.Models;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.WebUI.Controllers
{
    [Authorize]
    public class RemessaController : Controller
    {
        private IRemessaRepository remessaRepository;
        private IMotivoRepository motivoRepository;
        private IParentescoRepository parentescoRepository;

        public RemessaController(IParentescoRepository parentescoRepository, IMotivoRepository motivoRepository, IRemessaRepository remessaRepository)
        {
            this.parentescoRepository = parentescoRepository;
            this.motivoRepository = motivoRepository;
            this.remessaRepository = remessaRepository;
        }

        [HttpGet]
        public ViewResult List(string id)
        {
            RemessaListViewModel viewModel;
            viewModel = new RemessaListViewModel
            {
                Remessas = remessaRepository.Remessas
                .Where(rms => rms.rmsMotorista.Equals(id) && rms.rmsDataBaixa == null)
                .OrderBy(rms => rms.rmsCepEntrega + rms.rmsEnderecoEntrega + rms.rmsNotaFiscal)
                .Distinct()
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Detail(string id)
        {
            RemesssaViewModel viewModel;
            viewModel = new RemesssaViewModel
            {
                //Dados da remessa
                remessa = remessaRepository.Remessas
                .Where(r => r.rmsChave.Equals(id)
                    && r.rmsDataBaixa == null)
                .SingleOrDefault()
            };

            ViewBag.RemessaId = id;

            var motivos = motivoRepository.Motivos
                .Where(m => m.mtvId != null)
                .Distinct()
                .OrderBy(m => m.mtvDescricao);
            ViewBag.Motivos = new SelectList(motivos, "mtvId", "mtvDescricao");

            var parentescos = parentescoRepository.Parentescos
                .Where(p => p.prcId != null)
                .Distinct()
                .OrderBy(p => p.prcDescricaoParentesco);
            ViewBag.Parentescos = new SelectList(parentescos, "prcId", "prcDescricaoParentesco");

            return View(viewModel);
        }

        [HttpPost]
        public RedirectToRouteResult Detail(RemesssaViewModel model, string id, string motorista)
        {
            if (ModelState.IsValid)
            {
                var remessa = remessaRepository.Remessas
                    .Where(rm => rm.rmsChave.Equals(id))
                    .SingleOrDefault();

                remessa.rmsDataBaixa = DateTime.Now;
                remessa.rmsMotivo = model.motivoId;
                remessa.rmsParentescoRecebedor = model.parentescoId;
                remessa.rmsObservacaoEntrega = model.observacao;

                remessaRepository.SalvarRemessa(remessa);

                return RedirectToAction("List", new { id = motorista });
            }
            else
            {
                return RedirectToAction("List", new { id = motorista });
            }
        }
    }
}
