using Commandos.Models.Products.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    public interface ICart : IEnumerable<KeyValuePair<IProduct, int>>
    {
        Guid Id { get; }
        Dictionary<IProduct, int> CartProducts { get; }
        int GetAmount(IProduct product);
        void AddProduct(IProduct product, int count);
        void DeleteProduct(IProduct product, int count);
        void ClearCart();
        double Sum();
    }
}
