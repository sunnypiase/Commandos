using Commandos.AbstractMethod;
using Commandos.Models.Products.General;
using Commandos.Storage;
using System.Globalization;
using System.Reflection;
using Commandos.Services;

namespace Commandos.Services
{
    public class AddProductService
    {      

        public bool CheckFactoryProperties(out string? checkingResult, List<(object, Type)> tmpInputResults)
        {
            object example = null;
            foreach ((object, Type) item in tmpInputResults)
            {
                example = null;
                example = Convert.ChangeType(item.Item1, (item.Item2), CultureInfo.InvariantCulture);

                if ((example is null))
                {
                    tmpInputResults = new();
                    checkingResult = item.Item1.ToString();
                    return false;
                }
            }
            checkingResult = "ok";
            return true;
        }

        public object GetConcreteFactoryInstance(Type? commandType)
        {
            IEnumerable<Type>? list = GetTypeFactories();

            foreach (Type? item in list)
            {
                if (item.Name.Equals(commandType.Name))
                {
                    return Activator.CreateInstance(item);
                }
            }

            throw new ArgumentNullException();
        }

        public HashSet<PropertyInfo> GetFactoryProperties(object objectFactory)
        {
            List<PropertyInfo> result = new();
            result.AddRange(objectFactory.GetType().BaseType.GetProperties());
            result.AddRange(objectFactory.GetType().GetProperties(BindingFlags.Public
                                                            | BindingFlags.Instance
                                                            | BindingFlags.DeclaredOnly));

            HashSet<PropertyInfo> tmpProps = new();
            foreach (PropertyInfo? item in result)
            {
                tmpProps.Add(item);
            }
            return tmpProps;
        }

        public IEnumerable<Type> GetTypeFactories()
        {
            Type? typeList = typeof(AbstractFactoryMethod);
            return Assembly.GetAssembly(typeList).GetTypes().Where(type => type.IsSubclassOf(typeList));
        }

        public bool BuildProduct(Type? commandType, List<(object, Type)> tmpInputResults, out IProduct buildProduct)
        {
            try
            {
                ConstructorInfo[]? ctorList = commandType.GetConstructors();
                object[]? parameters = new object[tmpInputResults.Count];
                for (int i = 0; i < tmpInputResults.Count; i++)
                {
                    parameters[i] = tmpInputResults[i].Item1;
                }

                foreach (ConstructorInfo? item in ctorList)
                {
                    if (item.GetParameters().Length == commandType.GetProperties().Length)
                    {
                        object? tempFactory = item.Invoke(parameters);
                        AbstractFactoryMethod FactoryDeveloper = (AbstractFactoryMethod)tempFactory;
                        buildProduct = FactoryDeveloper.CreateProduct();
                        return true;
                    }
                }
            }
            catch
            {
                throw;
            }

            buildProduct = null;
            return false;
        }


    }
}
