using Commandos.AbstractMethod;
using Commandos.Models.Products.General;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;
using System.Globalization;
using System.Reflection;

namespace ConsoleUI.Commands.ModeratorCommands
{
    public class AddProductToStorage : CommandOn<Type>
    {

        private string _title;
        private HashSet<PropertyInfo> tmpProps;
        private List<(object, Type)> tmpInputResults;
        private List<IMenuElement> elements;

        public AddProductToStorage(string title)
        {
            _title = title;
            tmpProps = new();
            tmpInputResults = new();
        }

        public override object Clone()
        {
            return new AddProductToStorage(_title);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();

            if (!FactoryChoiser())
            {
                elements.Add(new InfoElement("abbort adding"));
                elements.Add(new SelectableElement("continue", "0", new BackToHome()));
                return elements;
            }
            if (!CheckParams(out string? checkingResult))
            {
                elements.Add(new InfoElement($"abbort product has not been added:\nincorrect input parameter {checkingResult}"));
                return elements;
            }
            if (!FactorySaver())
            {
                elements.Add(new InfoElement($"abbort product has not been added:\nincorrect saving input parameters {checkingResult}"));
                return elements;
            }

            elements.Add(new InfoElement("succesful product has been added"));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }

        private bool FactoryChoiser()
        {
            object res = GetInstance();
            string output = "";
            int index = default;

            /// изменить порядок добавления пропов
            List<PropertyInfo> tmpPropss = new();
            tmpPropss.AddRange(res.GetType().BaseType.GetProperties());
            tmpPropss.AddRange(res.GetType().GetProperties(BindingFlags.Public
                                                            | BindingFlags.Instance
                                                            | BindingFlags.DeclaredOnly)
                                                        );

            foreach (PropertyInfo? item in tmpPropss)
            {
                tmpProps.Add(item);
            }

            foreach (PropertyInfo? prop in tmpProps)
            {
                if (prop.PropertyType.IsEnum)
                {
                    output += $"choise need type: \n";
                    foreach (object? item in Enum.GetValues(prop.PropertyType))
                    {
                        output += $"{++index} > if you want create [{item}]\n";
                    }
                    index = 0;

                    string inputedEnum = "";
                    bool operation = false;
                    while (!operation)
                    {
                        inputedEnum = input.Read($"{output}input number - [{prop.PropertyType.Name}]", drawer);

                        if ((int.TryParse(inputedEnum, out int result)) && result > 0 && result <= Enum.GetValues(prop.PropertyType).Length)
                        {
                            operation = true;
                        }
                    }

                    int i = 0;
                    foreach (object? item in Enum.GetValues(prop.PropertyType))
                    {
                        if (int.Parse(inputedEnum) == (++i))
                        {
                            tmpInputResults.Add((item, prop.PropertyType));
                        }
                    }
                    i = 0;
                    output = "";
                    continue;
                }
                if (prop.PropertyType == typeof(DateTime))
                {
                    string inputed = input.Read($"input >1< if you want date now]\ninput >2< if you want enother date", drawer);
                    int.TryParse(inputed, out int exit);
                    if (exit == 0)
                    {
                        return false;
                    }
                    else if (exit == 1)
                    {
                        tmpInputResults.Add((DateTime.Now, prop.PropertyType));
                    }
                    else
                    {
                        //do stuff like prop.SetValue(t, DateTime.Now, null);
                        bool operation = false;
                        while (!operation)
                        {
                            int def = default;
                            DateTime example = new DateTime(
                                CheckDateParams(prop.PropertyType, DateTime.MinValue.Year, DateTime.MaxValue.Year),
                                CheckDateParams(prop.PropertyType, DateTime.MinValue.Month, DateTime.MaxValue.Month),
                                CheckDateParams(prop.PropertyType, DateTime.MinValue.Day, DateTime.MaxValue.Day));
                            tmpInputResults.Add((example, prop.PropertyType));
                            operation = true;
                        }
                    }
                }
                else
                {
                    bool operation = false;
                    while (!operation)
                    {
                        try
                        {

                            string inputed = input.Read($"input {prop.Name} - [{prop.PropertyType.Name}]", drawer);
                            if (int.TryParse(inputed, out int exit))
                            {
                                if (exit == 0)
                                {
                                    return false;
                                }
                            }

                            object? example = Convert.ChangeType(inputed, (prop.PropertyType), CultureInfo.InvariantCulture);
                            if (example != null)
                            {
                                tmpInputResults.Add((example, prop.PropertyType));
                                operation = true;
                            }

                        }
                        catch
                        {
                            operation = false;
                        }

                    }
                }
            }

            return true;
        }

        private int CheckDateParams(Type typeDate, int DiapasonMin, int DiapasonMax)
        {
            bool operation = false;
            int resultDate = default;

            while (!operation)
            {
                string inputed = input.Read($"input {typeDate} - [{DiapasonMin} - {DiapasonMax}]", drawer);

                if ((int.TryParse(inputed, out int result)) && DiapasonMin > 0 && result <= DiapasonMax)
                {
                    operation = true;
                    return result;
                }
            }

            return DiapasonMin;
        }

        private bool FactorySaver()
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
                    AbstractMethod FactoryDeveloper = (AbstractMethod)tempFactory;
                    IProduct? resultProduct = FactoryDeveloper.CreateProduct();
                    string inputed = "";
                    bool operation = false;
                    while (!operation)
                    {
                        inputed = input.Read($"input number count this product", drawer);

                        if ((int.TryParse(inputed, out int inputCountResult)) && inputCountResult > 0)
                        {
                            operation = true;
                            ProductStorage<IProduct>.GetInstance().Add(resultProduct, inputCountResult);
                        }
                    }

                }
            }
            return true;
        }

        private bool CheckParams(out string? checkingResult)
        {
            object example = null;
            foreach ((object, Type) item in tmpInputResults)
            {
                example = null;
                // example = Convert.ChangeType(item.Item1, item.Item2);
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

        protected object GetInstance()
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

        protected IEnumerable<Type> GetTypeFactories()
        {
            Type? typeList = typeof(AbstractMethod);
            return Assembly.GetAssembly(typeList).GetTypes().Where(type => type.IsSubclassOf(typeList));
        }

    }//TODO do
}

