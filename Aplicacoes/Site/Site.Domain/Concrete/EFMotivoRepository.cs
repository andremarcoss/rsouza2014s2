using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.Domain.Entities;
using Site.Domain.Abstract;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.Domain.Concrete
{
    public class EFMotivoRepository : IMotivoRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Motivo> Motivos
        {
            get
            {
                return context.Motivos;
            }
        }

        public void SalvarMotivo(Motivo motivo)
        { }

        public void DeletarMotivo(Motivo motivo)
        { }
    }
}