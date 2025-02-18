using System;
using System.Security.Cryptography.X509Certificates;

public class Nodo
{
    public int valor;
    public Nodo siguiente;
    public Nodo(int valor)
    {
        this.valor = valor;
        this.siguiente = null;
    }
}

public class ListaEnlazada
{
    public Nodo cabeza;
    public Nodo tope;

    public ListaEnlazada()
    {
        cabeza = null;
        tope = null;
    }

    // Agregar al inicio de la lista
    public void AgregarAlInicio(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            tope = nuevoNodo;
        }
        else
        {
            nuevoNodo.siguiente = cabeza;  // El nuevo nodo apunta a la cabeza actual
            cabeza = nuevoNodo;  // La cabeza ahora apunta al nuevo nodo
        }
    }

    // Agregar al final de la lista
    public void AgregarAlFinal(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (tope == null)
        {
            cabeza = nuevoNodo;  // Si la lista está vacía, cabeza y tope apuntan al nuevo nodo
            tope = nuevoNodo;
        }
        else
        {
            tope.siguiente = nuevoNodo;  // El nodo actual 'tope' apunta al nuevo nodo
            tope = nuevoNodo;  // El 'tope' ahora apunta al nuevo nodo
        }
    }

    // Eliminar al inicio de la lista
    public void EliminarAlInicio()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        else
        {
            cabeza = cabeza.siguiente;  // La cabeza ahora apunta al siguiente nodo
            if (cabeza == null)  // Si después de eliminar, la lista está vacía
            {
                tope = null;  // También se debe actualizar 'tope'
            }
        }
    }

    // Eliminar al final de la lista
    public void EliminarAlFinal()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        else if (cabeza == tope)  // Si solo hay un nodo
        {
            cabeza = null;
            tope = null;
        }
        else
        {
            Nodo nodoActual = cabeza;
            while (nodoActual.siguiente != tope)  // Llegamos al penúltimo nodo
            {
                nodoActual = nodoActual.siguiente;
            }
            nodoActual.siguiente = null;  // El penúltimo nodo ahora apunta a null
            tope = nodoActual;  // 'tope' ahora apunta al penúltimo nodo
        }
    }

    // Imprimir la lista
    public void Imprimir()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo nodoActual = cabeza;
        while (nodoActual != null)
        {
            Console.Write(nodoActual.valor + " ");
            nodoActual = nodoActual.siguiente;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Menú opciones:");
            Console.WriteLine("1. Agregar al inicio");
            Console.WriteLine("2. Agregar al final");
            Console.WriteLine("3. Eliminar al inicio");
            Console.WriteLine("4. Eliminar al final");
            Console.WriteLine("5. Mostrar lista");
            Console.WriteLine("6. Salir");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el valor a agregar al inicio:");
                    int valorInicio = Convert.ToInt32(Console.ReadLine());
                    lista.AgregarAlInicio(valorInicio);
                    break;

                case 2:
                    Console.WriteLine("Ingrese el valor a agregar al final:");
                    int valorFinal = Convert.ToInt32(Console.ReadLine());
                    lista.AgregarAlFinal(valorFinal);
                    break;

                case 3:
                    Console.WriteLine("Eliminando el primer elemento...");
                    lista.EliminarAlInicio();
                    break;

                case 4:
                    Console.WriteLine("Eliminando el último elemento...");
                    lista.EliminarAlFinal();
                    break;

                case 5:
                    Console.WriteLine("Mostrando la lista:\n");
                    lista.Imprimir();
                    break;

                case 6:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                    break;
            }
        }

    }
}