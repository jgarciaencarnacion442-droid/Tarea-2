using System.Collections;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;
int NumberSelect = 0;
bool Error = false;
bool Continue = true;
Error = false;
int id = 0;
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> Marca = new Dictionary<int, string>();
Dictionary<int, string> Categoria = new Dictionary<int, string>();
Dictionary<int, decimal> precio = new Dictionary<int, decimal>();


while (Continue)
{
        Console.WriteLine("--Bienvenido Usuario--");
        Console.WriteLine("Estas son las operaciones que puede realizar");
        Console.WriteLine("1.Registrar Productos");
        Console.WriteLine("2.Lista de Productos");
        Console.WriteLine("3.Modificar Producto");
        Console.WriteLine("4.Buscar Producto");
        Console.WriteLine("5.Eliminar Producto");
        Console.WriteLine("6.Salir del Programa");
    int Count = 0;

    do

    {
        Error = false;
        try
        {
            Console.WriteLine("Digite el numero de la opcion que desea:");
            NumberSelect = Convert.ToInt32(Console.ReadLine());

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("-- Elige un numero que este entre las opciones asignadas --");

            Error = true;
        }
    }while(Error == true);

    switch (NumberSelect)
    {
        case 1:
            do
            {
                Error = false;
                try
                {
                    if (Count > 0)
                    {
                        Console.WriteLine("¿Quieres seguir registrando un producto?");
                        Console.WriteLine("1.Si");
                        Console.WriteLine("2.No");

                        int TempQuest = Convert.ToInt32(Console.ReadLine());
                        if (TempQuest == 2)
                        {
                            break;
                        }
                    }
                    id = id + 1;
                    Console.WriteLine("Digite el Nombre del Producto:");
                    names.Add(id, Console.ReadLine());

                    Console.WriteLine("Digite La Marca del Producto:");
                    Marca.Add(id, Console.ReadLine());

                    Console.WriteLine("Digite la Categoria del Producto:");
                    Categoria.Add(id, Console.ReadLine());

                    Console.WriteLine("Digite el precio del Producto:");
                    decimal preciotemp = Convert.ToDecimal(Console.ReadLine());
                    precio.Add(id, preciotemp);

                    Console.WriteLine();
                    Console.WriteLine("Producto agregado...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("-- Por favor llenar correctamente cada campo --");
                    names.Remove(id);
                    Categoria.Remove(id);
                    Marca.Remove(id);
                    id = id - 1;
                    Error = true;
                    Count++;
                }
            }while (Error == true);

            break;
            case 2:
                if (names.Count == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    break;
                }

                Console.WriteLine("--Lista de Productos--");
                Console.WriteLine("|ID|  NOMBRE| MARCA|  CATEGORIA|  PRECIO|");

            foreach (var item in names)
            {
                int idtemp = item.Key;

                Console.WriteLine();
                    Console.WriteLine("_________________________________________________________________________________________________________________");
                    Console.WriteLine($"|{idtemp}| {names[idtemp]}| {Marca[idtemp]}| {Categoria[idtemp]}| {precio[idtemp]}|");
                    Console.WriteLine("_________________________________________________________________________________________________________________");
                }
                break;
            case 3:
            do
            {
                Error = false;
                try
                {
                    if(Count > 0)
                    {
                        Console.WriteLine("¿Desea continuar con la busqueda?");
                        Console.WriteLine("1.Si");
                        Console.WriteLine("2.No");

                        int TempQuest = Convert.ToInt32(Console.ReadLine());
                        if (TempQuest == 2)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Coloque el ID del producto que desea modificar:");
                    int TempID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite el nuevo Nombre del Producto:");
                    names[TempID] = (Console.ReadLine());

                    Console.WriteLine("Digite La Marca del Producto:");
                    Marca[TempID] = (Console.ReadLine());

                    Console.WriteLine("Digite la Categoria del Producto:");
                    Categoria[TempID] = (Console.ReadLine());

                    Console.WriteLine("Digite el precio del Producto:");
                    precio[TempID] = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("-- Hubo un error al ejecutar la modificacion, ");
                    Console.WriteLine("Por favor asegurese de que el ID del producto exista o que la informacion de los campos sea correcta. --");
                    Error = true;
                    Count++;
                }
            } while (Error == true);


            break;
            case 4:
                try
                {

                    Console.WriteLine("Coloque el ID del producto que desea Buscar:");
                    int TempID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"El Id del producto es: {TempID}");
                    Console.WriteLine($"El nombre del producto es: {names[TempID]}");
                    Console.WriteLine($"La Marca del producto es: {Marca[TempID]}");
                    Console.WriteLine($"La Categoria del producto es: {Categoria[TempID]}");
                    Console.WriteLine($"El precio del producto es: {precio[TempID]}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("-- Hubo un error al ejecutar la busqueda, ");
                    Console.WriteLine("Por favor asegurese de que el ID del producto exista--");
                    Console.WriteLine();
                break;
                }
            break;
            case 5:
            try
            {

                Console.WriteLine("Coloque el ID del producto que desea Eliminar:");
                int TempID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"--El producto {names[TempID]} sera eliminado.--");
                Console.WriteLine("¿Desea continuar con la Eliminacion?");
                Console.WriteLine("1.Si");
                Console.WriteLine("2.No");
                int TempQuest = Convert.ToInt32(Console.ReadLine());
                if (TempQuest == 1)
                {
                    names.Remove(TempID);
                    Categoria.Remove(TempID);
                    Marca.Remove(TempID);
                    precio.Remove(TempID);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("-- Hubo un error al ejecutar la busqueda, ");
                Console.WriteLine("Por favor asegurese de que el ID del producto exista--");
                Console.WriteLine();

            }
                break;
            case 6:
                Continue = false;
                Console.WriteLine("Cerrando Programa...");
                break;
        }
}
