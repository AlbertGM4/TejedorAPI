using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.Repository.Interfaces;

public interface IProductRepository
{
    public IEnumerable<Product> GetProducts();
}
