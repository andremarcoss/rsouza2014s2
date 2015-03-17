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
    public interface IMotoristaRepository
    {
        IQueryable<Motorista> Motoristas { get; }
        void SalvarMotorista(Motorista motorista);
        void DeletarMotorista(Motorista motorista);
    }
}
