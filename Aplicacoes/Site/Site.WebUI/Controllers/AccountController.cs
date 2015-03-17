using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Site.WebUI.Infrastructure.Abstract;
using Site.Domain.Abstract;
using Site.WebUI.Models;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        IMotoristaRepository motoristaRepository;
        //
        // GET: /Account/

        public AccountController(IAuthProvider auth, IMotoristaRepository motoristaRepository)
        {
            this.authProvider = auth;
            this.motoristaRepository = motoristaRepository;
        }

        [HttpGet]
        public ViewResult Login(bool? id)
        {
            authProvider.LogOut();
            if ((id != null) && (!id.Value))
                ModelState.AddModelError("", "Senha ou usuário incorretos");
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Usuario, model.Senha))
                {
                    Session["Login"] = model;
                    return RedirectToAction("List", "Remessa", new { id = model.Usuario });
                }
                else
                {
                    { return RedirectToAction("Login", "Account", new { id = false }); }
                }
            }
            else
            { return RedirectToAction("Login", "Account", new { id = false }); }
        }

        [HttpGet]
        public ViewResult AlterarSenha()
        {
            LoginViewModel login = (LoginViewModel)Session["Login"];
            AlterarSenhaViewModel viewModel = new AlterarSenhaViewModel();
            viewModel.motorista = motoristaRepository.Motoristas
                .Where(m => m.mtCpf.Equals(login.Usuario))
               .SingleOrDefault();
            return View(viewModel);
        }

        [HttpPost]
        public ViewResult AlterarSenha(AlterarSenhaViewModel model)
        {
            LoginViewModel login = (LoginViewModel)Session["Login"];
            model.motorista = motoristaRepository.Motoristas
                    .Where(m => m.mtCpf.Equals(login.Usuario))
                   .SingleOrDefault();

            if (ModelState.IsValid)
            {
                if (!model.novaSenha.Equals(model.confirmacaoSenha))
                {
                    ModelState.AddModelError("", "As senhas informadas são diferentes");
                    return View(model);
                }
                model.motorista.mtSenha = model.novaSenha;
                motoristaRepository.SalvarMotorista(model.motorista);
                ModelState.AddModelError("", "Senha alterada com sucesso!");
                return View(model);
            }
            else
            {
                return View(model);
            }
        }
    }
}
