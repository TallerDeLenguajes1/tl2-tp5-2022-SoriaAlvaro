using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IPedidoRepository
    {
        void Save(Pedido pedido, int? id){}
        List<Pedido> GetAll();
    }
}