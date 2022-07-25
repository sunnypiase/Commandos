using Commandos.Models.Products.CementProduct;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.MeatProduct;
using Commandos.User;
using System.Collections;
using System.Runtime.Serialization;

namespace Commandos.Models.Carts
{
    [KnownType(typeof(CementProductModel))]
    [KnownType(typeof(DairyProductModel))]
    [KnownType(typeof(MeatProductModel))]
    [KnownType(typeof(Cart))]
    [CollectionDataContract]
    public class CartsRepository : IList<Cart>
    {
        #region Props
        [DataMember(Name = "Carts")]
        private List<Cart> carts;
        private static CartsRepository instance;
        #endregion
        #region Ctors
        private CartsRepository()
        {
            carts = new();
        }
        #endregion
        #region Ilist
        public Cart this[int index]
        {
            get => carts[index];
            set => carts[index] = value;
        }
        public int Count => carts.Count;
        public bool IsReadOnly => false;
        public void Add(Cart item)
        {
            if (carts.Contains(item))
            {
                carts[carts.IndexOf(item)] = item;
            }
            else
            {
                carts.Add(item);
            }
        }
        public void AddRange(List<Cart> carts)
        {
            foreach (Cart item in carts)
            {
                Add(item);
            }
        }
        public void Clear()
        {
            carts.Clear();
        }
        public bool Contains(Cart item)
        {
            return carts.Contains(item);
        }
        public void CopyTo(Cart[] array, int arrayIndex)
        {
            carts.CopyTo(array, arrayIndex);
        }
        public IEnumerator<Cart> GetEnumerator()
        {
            return carts.GetEnumerator();
        }
        public int IndexOf(Cart item)
        {
            return carts.IndexOf(item);
        }
        public void Insert(int index, Cart item)
        {
            carts.Insert(index, item);
        }
        public bool Remove(Cart item)
        {
            return carts.Remove(item);
        }
        public void RemoveAt(int index)
        {
            carts.RemoveAt(index);
        }
        #endregion
        #region Methods
        public static CartsRepository GetInstance(CartsRepository carts = null)
        {
            if (instance == null)
            {
                instance = carts ?? new();
            }
            return instance;
        }
        public Cart GetCart(IUser user)
        {
            if (carts.Any(c => c.Id == user.Guid))
            {
                return carts.Find(c => c.Id == user.Guid);
            }

            Cart? tmpCart = new Cart(user);
            Add(tmpCart);
            return tmpCart;
        }
        #endregion
        #region ObjectOverrides
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
