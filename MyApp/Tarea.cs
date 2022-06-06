namespace Ejercicio1
{
    public class Tarea
    {   
        // campos o variables
        private int tareaID;
        private string descripcion;
        private int duracion;

        // constructor (método)
        public Tarea(int tareaID, string descripcion, int duracion)
        {
            this.tareaID = tareaID;
            this.descripcion = descripcion;
            this.duracion = duracion;
        }

        // propiedades
        public int TareaID { get => tareaID; }
        public string Descripcion { get => descripcion; }
        public int Duracion { get => duracion; }

        // método
        public void mostrarUnaTarea(Tarea unaTarea)
        {
            Console.WriteLine("TareaID: " + unaTarea.tareaID);
            Console.WriteLine("Descripción: " + unaTarea.descripcion);
            Console.WriteLine("Duración: " + unaTarea.duracion + " minutos");
        }
    } 
}