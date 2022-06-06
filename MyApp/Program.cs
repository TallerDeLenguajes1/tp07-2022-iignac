using Ejercicio1;

List<Tarea> listaPendientes = new List<Tarea>();
List<Tarea> listaRealizadas = new List<Tarea>();
List<Tarea> listaAuxPendientes = new List<Tarea>();
Tarea nuevaTarea;
string[] arrayDescripcion = {"sacar fotocopias", "cargar documentos", "ordenar agenda", "realizar llamadas"};
var random = new Random();

Console.Write("Ingrese la cantidad de tareas a realizar: ");
int cantidadTareas = Convert.ToInt32(Console.ReadLine());

// cargo la lista de tareas pendientes
for (int i = 0; i < cantidadTareas; i++)
{
    nuevaTarea = new Tarea(i+1, arrayDescripcion[random.Next(0,4)], random.Next(10,101));
    listaPendientes.Add(nuevaTarea);
}

Console.WriteLine("\n==> Lista de tareas pendientes:\n");
mostrarLista(listaPendientes);

// mover tareas pendientes a realizadas
moverTareas(listaPendientes);

// muestro las listas pendientes y realizadas
Console.WriteLine("\n==> Lista de tareas pendientes:\n");
mostrarLista(listaAuxPendientes);
Console.WriteLine("\n==> Lista de tareas realizadas:\n");
mostrarLista(listaRealizadas);

// buscar una tarea
buscarTareaPendiente(listaAuxPendientes);

// sumario de horas trabajadas
horasTrabajadas(listaPendientes);


void mostrarLista(List<Tarea> listaTareas)
{
    foreach (Tarea unaTarea in listaTareas)
    {
        unaTarea.mostrarUnaTarea(unaTarea);
        Console.WriteLine("----"); 
    }
}

void moverTareas(List<Tarea> listaTareas)
{
    Console.WriteLine("\n==> Determinar estado de las tareas:\n");
    int opcion;
    for (int i = 0; i < cantidadTareas; i++)
    {
        listaPendientes[i].mostrarUnaTarea(listaPendientes[i]);
        Console.WriteLine("** La tarea fué realizada? (1: si / 0: no)");
        opcion = Convert.ToInt32(Console.ReadLine());
        nuevaTarea = new Tarea(listaPendientes[i].TareaID, listaPendientes[i].Descripcion, listaPendientes[i].Duracion);
        if (opcion == 1)
        {
            listaRealizadas.Add(nuevaTarea);
        }
        else
        {
            listaAuxPendientes.Add(nuevaTarea);
        }
    }
    // Except: elimina de listaPendientes todas las tareas que se encuentran en listaRealizadas
    // listaPendientes = listaPendientes.Except(listaRealizadas).ToList();
}

void buscarTareaPendiente(List<Tarea> listaTareas)
{
    Console.WriteLine("\n==> Ingrese la descripción de la tarea pendiente a buscar:");
    string descripcionAux = (Console.ReadLine()!).ToLower(); // uso ToLower porque Contains distingue entre mayusc y minusc
    int bandera=0;
    for (int i = 0; i < listaAuxPendientes.Count; i++)
    {
        if (listaAuxPendientes[i].Descripcion.Contains(descripcionAux))
        {
            Console.WriteLine("Tarea buscada:");
            listaAuxPendientes[i].mostrarUnaTarea(listaAuxPendientes[i]);
            i = listaAuxPendientes.Count;
            bandera = 1;
        }
    }
    if (bandera == 0)
    {
        Console.WriteLine("La tarea no se encuentra en ésta lista");
    }
}

void horasTrabajadas(List<Tarea> listaTareas)
{
    float totalMinutos=0;
    Console.WriteLine("\n==> Sumario de las horas trabajadas por el empleado:\n");
    foreach (var item in listaTareas)
    {   
        Console.WriteLine($"Tarea {item.TareaID}: {item.Duracion} minutos");
        totalMinutos += item.Duracion; 
    } 
    Console.WriteLine("Horas total trabajadas: "  + Math.Round(totalMinutos/60, 2));
}