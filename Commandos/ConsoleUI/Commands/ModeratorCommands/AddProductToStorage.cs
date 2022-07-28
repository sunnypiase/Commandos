using Commandos.Models.Products.General;
using Commandos.Services;
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
        private AddProductService addProductService;

        public AddProductToStorage(string title)
        {
            _title = title;
            tmpProps = new();
            tmpInputResults = new();
            addProductService = new();
        }

        public override object Clone()
        {
            return new AddProductToStorage(_title);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            IProduct buildProduct;

            if (!ReadFactoryProperties())
            {
                return EndingAddCommand(elements);
            }
            if (!addProductService.CheckFactoryProperties(out string? checkingResult, tmpInputResults))
            {
                return EndingAddCommand(elements, $"abbort product has not been added:\nincorrect input parameter {checkingResult}");
            }
            if (!addProductService.BuildProduct(commandType, tmpInputResults, out buildProduct))
            {
                return EndingAddCommand(elements, $"abbort product has not been added:\nincorrect saving input parameters {checkingResult}");
            }
            if (buildProduct == null)
            {
                return EndingAddCommand(elements, $"abbort buildind product: System error creating {checkingResult}");
            }

            ProductStorage<IProduct>.GetInstance().Add(buildProduct, GetCountProduct(buildProduct)); 

            return EndingAddCommand(elements, "succesful product has been added");
        }


        private bool ReadFactoryProperties()
        {
            object res = addProductService.GetConcreteFactoryInstance(commandType);
            string output = "";
            int index = default;

            List<PropertyInfo> tmpPropss = new();
            tmpPropss.AddRange(res.GetType().BaseType.GetProperties());
            tmpPropss.AddRange(res.GetType().GetProperties(BindingFlags.Public
                                                            | BindingFlags.Instance
                                                            | BindingFlags.DeclaredOnly));

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
                    string inputed = input.Read($"input >1< if you want date now\ninput >2< if you want enother date", drawer);
                    int.TryParse(inputed, out int exit);
                    if (exit == 0) return false;
                    else if (exit == 1) tmpInputResults.Add((DateTime.Now, prop.PropertyType));
                    else
                    {
                        bool operation = false;
                        while (!operation)
                        {
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
                            if (Convert.ChangeType(inputed, (prop.PropertyType), CultureInfo.InvariantCulture) != null)
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

        public int GetCountProduct(IProduct product, string InfoText = "input number count this product", int defaultCount = 1)
        {
            while (true)
            {
                string inputed = input.Read(InfoText, drawer);

                if (int.TryParse(inputed, out int inputCountResult) && inputCountResult > 0)
                {
                    return inputCountResult;
                }
            }

            return defaultCount;
        }

        private static ICollection<IMenuElement> EndingAddCommand(List<IMenuElement> elements, string msg = "abbort adding")
        {
            elements.Add(new InfoElement(msg));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }

    }
}

