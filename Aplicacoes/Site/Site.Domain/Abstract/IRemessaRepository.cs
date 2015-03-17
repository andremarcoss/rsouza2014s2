using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.Domain.Entities;

//@author Rafael Alves de Sousa
//@date 20/11/2014
//@contact rafaelalvesdesousa1992@gmail.com

namespace Site.Domain.Abstract
{
    public interface IRemessaRepository
    {
        IQueryable<Remessa> Remessas { get; }
        void SalvarRemessa(Remessa remessa);
        void DeletarRemessa(Remessa remessa);
    }
}
