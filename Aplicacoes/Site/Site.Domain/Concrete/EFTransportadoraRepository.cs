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
    public class EFTransportadoraRepository : ITransportadoraRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Transportadora> Transportadoras
        {
            get
            {
                return context.Transportadoras;
            }
        }

        public void SalvarTransportadora(Transportadora transportadora)
        { }

        public void DeletarTransportadora(Transportadora transportadora)
        { }
    }
}
