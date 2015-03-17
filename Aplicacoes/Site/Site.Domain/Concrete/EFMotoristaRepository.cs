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
    public class EFMotoristaRepository : IMotoristaRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Motorista> Motoristas
        {
            get
            {
                return context.Motoristas;
            }
        }

        public void SalvarMotorista(Motorista motorista)
        {
            Motorista dbEntry = context.Motoristas.Find(motorista.mtCpf);
            if (dbEntry != null)
            {
                dbEntry.mtCpf = motorista.mtCpf;
                dbEntry.mtNome = motorista.mtNome;
                dbEntry.mtSenha = motorista.mtSenha;
            }
            context.SaveChanges();
        }

        public void DeletarMotorista(Motorista motorista)
        { }
    }
}