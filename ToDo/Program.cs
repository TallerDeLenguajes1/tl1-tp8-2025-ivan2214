/* 1. Deberás convertir la estructura Tarea de C a una clase en C#.
public class Tarea {
 public int TareaID { get; set; }
 public string Descripcion { get; set; }
 public int Duracion { get; set; } // Validar que esté entre
10 y 100
 // Puedes añadir un constructor y métodos auxiliares si
lo consideras necesario
}
2. Cree aleatoriamente N tareas y guardelas en una lista dedicada a tareas
pendientes (por ejemplo, List<Tarea> tareasPendientes).
3. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
La lista de tareas realizadas (por ejemplo, List<Tarea> tareasRealizadas)
inicialmente estará vacía.
4. Desarrolle una funcion para buscar tareas pendientes por descripcion y
mostrarla por consola.
5. Mostrar un listado de todas las tareas (pendientes y realizadas)
6. Diseña un menú principal que permita al usuario acceder a cada una de las
funcionalidades descritas.
La interaccion debe ser intuitiva (ej. "Presione 1 para...", "Ingrese el ID de la
tarea:", etc.). */

// Punto 1
public class Tarea
{

    public int TareaID { get; set; }
    public string Descripcion { get; set; }
    public int Duracion { get; set; }


    // constrcutro


    public Tarea(int tareaID, string descripcion, int duracion)
    {
        this.TareaID = tareaID;
        this.Descripcion = descripcion;
        this.Duracion = duracion;

    }

    /* metodos */

    public void MostrarTarea()
    {
        Console.WriteLine($"Tarea {TareaID}: {Descripcion} ({Duracion} minutos)");
    }




}

namespace ToDo
{
    internal class Program
    {
        static void Main()
        {
            // Punto 2 
            List<Tarea> tareasPendientes = new List<Tarea>();
            List<Tarea> tareasRealizadas = new List<Tarea>();


            int randomTareas = new Random().Next(1, 40);
            string[] descripciones = { "Estudiar", "Comer", "Dormir", "Ejercicio", "Trabajar", "Jugar", "Leer", "Cocinar", "Comprar" };
            for (int i = 0; i < randomTareas; i++)
            {

                int duracion = new Random().Next(10, 100);
                Tarea nuevaTarea = new Tarea(i, descripciones[new Random().Next(0, descripciones.Length - 1)], duracion);
                tareasPendientes.Add(nuevaTarea);

            }

            // Punto 3
            int opcion;
            do
            {
                Console.WriteLine("1. Mover tareas pendientes a realizadas");
                Console.WriteLine("2. Buscar tareas pendientes por descripcion");
                Console.WriteLine("3. Mostrar listado de todas las tareas (pendientes y realizadas)");
                Console.WriteLine("4. Salir");

                Console.Write("Ingrese una opcion: ");
                string input = Console.ReadLine() ?? "";
                opcion = int.TryParse(input, out opcion) ? opcion : 0;

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Mover tareas pendientes a realizadas");

                        foreach (Tarea tarea in tareasPendientes)
                        {
                            tareasRealizadas.Add(tarea);
                            tareasPendientes.Remove(tarea);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Buscar tareas pendientes por descripcion");

                        Console.Write("Ingrese la descripcion de la tarea: ");
                        string descripcionBuscada = Console.ReadLine() ?? "";

                        foreach (Tarea tarea in tareasPendientes)
                        {
                            if (tarea.Descripcion == descripcionBuscada)
                            {
                                tarea.MostrarTarea();
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine("Mostrar listado de todas las tareas (pendientes y realizadas)");

                        Console.WriteLine("Tareas pendientes:");
                        foreach (Tarea tarea in tareasPendientes)
                        {
                            tarea.MostrarTarea();
                        }

                        Console.WriteLine("Tareas realizadas:");
                        foreach (Tarea tarea in tareasRealizadas)
                        {
                            tarea.MostrarTarea();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Salir");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

            } while (opcion != 4);



        }
    }
}
