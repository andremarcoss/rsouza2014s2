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
    public interface IParentescoRepository
    {
        IQueryable<Parentesco> Parentescos { get; }
        void SalvarParentesco(Parentesco parentesco);
        void DeletarParentesco(Parentesco parentesco);
    }
}
