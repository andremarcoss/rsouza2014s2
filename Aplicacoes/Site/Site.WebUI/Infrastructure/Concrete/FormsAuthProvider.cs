using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Site.WebUI.Infrastructure.Abstract;
using Site.Domain.Abstract;
using Site.Domain.Concrete;
using Site.Domain.Entities;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private IMotoristaRepository repository;

        public FormsAuthProvider(IMotoristaRepository repository)
        {
            this.repository = repository;
        }

        public bool Authenticate(string usuario, string senha)
        {
            bool retorno = Autenticar(usuario, senha);
            if (retorno)
                FormsAuthentication.SetAuthCookie(usuario, false);
            return retorno;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        public bool Autenticar(string usurio, string senha)
        {
            bool retorno = false;
            var motorista = repository.Motoristas
                .Where(m => m.mtCpf.Equals(usurio) && m.mtSenha.Equals(senha)).SingleOrDefault();
            if (((Motorista)motorista) != null)
                retorno = true;
            return retorno;
        }
    }
}