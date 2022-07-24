using System.Collections;
using System.Reflection;
using System.Text;

namespace Commandos.TxtSerialize
{
    internal class TxtSerializer : ISerializer<TXTSerializedParameters>
    {

        #region Props
        #endregion

        #region Ctors
        public TxtSerializer()
        { }
        #endregion

        #region Methods
        public TXTSerializedParameters Serialize<T>(in T obj)
            where T : class
        {
            TXTSerializedParameters txtSerializedParameters = new TXTSerializedParameters
            {
                { "Type", obj.GetType().Name }
            };
            foreach (PropertyInfo property in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType.GetInterfaces().Contains(typeof(ICollection)))
                {
                    StringBuilder value = new();
                    foreach (object item in (IEnumerable)property.GetValue(obj))
                    {
                        value.Append(item);
                    }
                    txtSerializedParameters.Add(property.Name, $"{{{value}}}");
                }
                else
                {
                    txtSerializedParameters.Add(property.Name, property.GetValue(obj).ToString());
                }
            }
            return txtSerializedParameters;
        }
        #endregion

        #region ObjectOverrides
        #endregion
    }
}
