using GrafoTopologico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgoritmoDijksra();
            // AlgoritmoAndCreateGrafo();
            Console.ReadKey();
        }


        private static void AlgoritmoAndCreateGrafo()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string linea;


            try
            {
                int tamaño;
                Console.WriteLine("Agregar un GRAFO ");

                do
                {

                    Console.WriteLine("El Numero de NODOS debe ser MAYOR a 1");
                    Console.WriteLine();
                    Console.Write("Ingresa el Numero de NODOS del Grafo: ");



                    linea = Console.ReadLine();
                    tamaño = int.Parse(linea);
                    Console.Clear();
                } while (tamaño <= 1);

                Console.Clear();
                Console.WriteLine("¡Grafo Agregado!");
                Console.WriteLine("Cada Nodo fue Nombrado con la Sucesion de 1 a " + tamaño);
                Console.WriteLine();

                int[,] matrix = new int[tamaño, tamaño];



                string op;
                do
                {
                    menu();
                    op = Console.ReadLine();

                    switch (op)
                    {

                        case "1": //////////////////////////////////////////////////////
                            Console.Clear();
                            Console.WriteLine("Usted Selecciono: Agregar un Arco");
                            Console.WriteLine();
                            for (int i = 0; i < 1; i++)
                            {
                                for (int j = 0; j < 1; j++)
                                {
                                    Console.Write("Nodo de Inicio: ");
                                    linea = Console.ReadLine();
                                    int fila = int.Parse(linea);

                                    Console.Write("Nodo de Destino: ");
                                    linea = Console.ReadLine();
                                    int columna = int.Parse(linea);

                                    Console.Write("Valor del Arco: ");
                                    linea = Console.ReadLine();
                                    int valor = int.Parse(linea);

                                    if (fila <= tamaño && columna <= tamaño)
                                    {
                                        if (valor > 0)
                                        {
                                            matrix[fila - 1, columna - 1] = valor;
                                            Console.WriteLine();
                                            Console.WriteLine("¡Arco Agregado! ");
                                            Console.WriteLine();
                                            Console.WriteLine(" (" + fila + ") -- " + valor + " --> (" + columna + ")");
                                            Console.WriteLine();

                                        }
                                        else
                                        {

                                            Console.WriteLine();
                                            Console.WriteLine("¡ARCO NO AGREGADO! ");
                                            Console.WriteLine("El Valor de la Arco debe ser Mayor a Cero ");
                                            Console.WriteLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("¡ARCO NO AGREGADO! ");
                                        Console.WriteLine("Algunos de los NODOS no Existen ");
                                        Console.WriteLine();
                                    }


                                }
                            }
                            break;


                        case "2"://////////////////////////////////////////////////////////////////
                            Console.Clear();
                            Console.WriteLine("Se muestra la Matriz del Grafo: ");
                            Console.WriteLine();
                            for (int i = 0; i < tamaño; i++)
                            {
                                for (int j = 0; j < tamaño; j++)
                                {
                                    Console.Write(matrix[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                            Console.ReadLine();
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("Usted Selecciono Busqueda Directa");
                            Console.WriteLine();
                            Console.Write("Nodo Origen: ");
                            linea = Console.ReadLine();
                            int fil = int.Parse(linea);
                            Console.Write("Nodo de Destino: ");
                            linea = Console.ReadLine();
                            int col = int.Parse(linea);
                            if (col <= tamaño && fil <= tamaño)
                            {
                                Console.WriteLine();
                                Console.WriteLine("El Valor es: " + matrix[fil - 1, col - 1]);
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("ERROR DE BUSQUEDA");
                                Console.WriteLine("Los Nodos que intruduiste No Exisen");

                                Console.WriteLine();
                            }

                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Usted Selecciono Busqueda Secuencial");
                            Console.WriteLine();
                            Console.Write("Ingresa dato a Buscar: ");
                            linea = Console.ReadLine();
                            int dato = int.Parse(linea);

                            bool bandera = false;
                            for (int i = 0; i < tamaño; i++)
                            {
                                for (int j = 0; j < tamaño; j++)
                                {
                                    if (matrix[i, j] == dato)
                                    {
                                        bandera = true;
                                        int a = i + 1;
                                        int b = j + 1;
                                        Console.WriteLine("La Ubicacion es; " + a + " --> " + b);


                                    }



                                }

                            }
                            if (bandera == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Este dato no Existe");
                            }
                            Console.WriteLine();


                            break;
                        case "5":
                            for (int i = 0; i < tamaño; i++)
                            {
                                for (int j = 0; j < tamaño; j++)
                                {
                                    if (matrix[i, j] > 0)
                                    {
                                        Console.WriteLine(" (" + (i + 1) + ") -- " + matrix[i, j] + " --> (" + (j + 1) + ")");
                                    }
                                }

                            }


                            break;


                    }
                } while (op != "0");

            }
            catch (FormatException)
            {
                Console.WriteLine("¡Ingresa Solo NUMEROS ENTEROS!");
                Console.WriteLine("Presiona Una TECLA para salir");
                Console.ReadKey();
            }
        }
        public static void menu()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("1.- Agregar un Arco ");
            Console.WriteLine("2.- Mostrar Matriz del grafo ");
            Console.WriteLine("3.- Busqueda Directa");
            Console.WriteLine("4.- Busqueda Secuencial");
            Console.WriteLine("5.- Mostrar Grafo");
            Console.WriteLine("*****************************************************");
        }


        

        private static void AlgoritmoDijksra()
        {

            int distancia = 0;//distancia entre los nodos
            int n = 0; //variable de apoyo
            int cantNodos = 7;//cantidad de nodos del grafo
            int actual = 0;// variable de apoyo para marcar el nodo en que se encuentra
            int columna = 0;

            //creacion del grafo
            Grafo grafos = new Grafo(cantNodos);
            grafos.AddArista(0, 1, 2);// primer nodo/ segundo nodo/ peso de la arista
            grafos.AddArista(0, 3, 1);
            grafos.AddArista(1, 3, 3);
            grafos.AddArista(1, 4, 10);
            grafos.AddArista(2, 0, 4);
            grafos.AddArista(2, 5, 5);
            grafos.AddArista(3, 2, 2);
            grafos.AddArista(3, 4, 2);
            grafos.AddArista(3, 5, 8);
            grafos.AddArista(3, 6, 4);
            grafos.AddArista(4, 6, 6);
            grafos.AddArista(6, 5, 1);

            // grafos.Show();//muestra el estado inicial del grafo
            grafos.MuestraAdyacencia();

            Console.Write("Nodo de Inicio: ");
            int inicio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nodo de Destino: ");
            int final = Convert.ToInt32(Console.ReadLine());


            /*a continuacion se crea la tabla
            0 visitado
            1 distancia
            2 previo
                */

            int[,] tabla = new int[cantNodos, 3];

            //inicio de la tabla
            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0;
            }
            tabla[inicio, 1] = 0;//el nodo del que partimos tiene un peso de cero


            Grafo.MostrarTabla(tabla);

            //Dijkstra
            actual = inicio;//actual toma el valor de inicio para empezar a recorrer el grafo

            do
            {
                //marcar el nodo como visitado
                tabla[actual, 0] = 1;
                for (columna = 0; columna < cantNodos; columna++)
                {
                    //a quien se dirige
                    if (grafos.ObtenerAdyacencia(actual, columna) != 0)
                    {
                        //distancia 
                        distancia = grafos.ObtenerAdyacencia(actual, columna) + tabla[actual, 1];
                        if (distancia < tabla[columna, 1])
                        {
                            tabla[columna, 1] = distancia;

                            //colocamos la informacion de origen padre
                            tabla[columna, 2] = actual;
                        }
                    }
                }

                //el nuevo nuevo actual es el metodo con la menor distancia que no ha sido visitado
                int indiceMenor = -1;
                int distanciamenor = int.MaxValue;

                for (int x = 0; x < cantNodos; x++)
                {
                    if (tabla[x, 1] < distanciamenor && tabla[x, 0] == 0)
                    {
                        indiceMenor = x;
                        distanciamenor = tabla[x, 1];
                    }
                }
                actual = indiceMenor;
            } while (actual != -1);

            Grafo.MostrarTabla(tabla);

            //Ruta mas corta
            List<int> ruta = new List<int>();
            int nodo = final;
            while (nodo != inicio)
            {
                ruta.Add(nodo);
                nodo = tabla[nodo, 2];
            }
            ruta.Add(inicio);

            ruta.Reverse();
            Console.WriteLine("\nRuta mas corta es: ");
            foreach (int posicion in ruta)
                Console.Write($"{posicion}->");

       
        }

        //private static void AlgoritmoOther()
        //{
        //    int inicio = 2;
        //    int final = 0;
        //    int distancia = 0;
        //    int n, m = 0;
        //    int cantNodos = 7;
        //    string dato;
        //    int nodo = 0;

        //    Grafo grafo = new Grafo(cantNodos);
        //    grafo.AdiccionarArista(0, 1);
        //    grafo.AdiccionarArista(0, 3);
        //    grafo.AdiccionarArista(1, 3);
        //    grafo.AdiccionarArista(1, 4);
        //    grafo.AdiccionarArista(2, 0);
        //    grafo.AdiccionarArista(2, 5);
        //    grafo.AdiccionarArista(3, 2);
        //    grafo.AdiccionarArista(3, 4);
        //    grafo.AdiccionarArista(3, 5);
        //    grafo.AdiccionarArista(3, 6);
        //    grafo.AdiccionarArista(4, 6);
        //    grafo.AdiccionarArista(6, 5);

        //    grafo.MuestraAdyacencia();

        //    Console.WriteLine("Dame el indice del nodo inicio");
        //    dato = Console.ReadLine();
        //    inicio = Convert.ToInt32(dato);

        //    Console.WriteLine("Dame el indice del nodo final");
        //    dato = Console.ReadLine();
        //    final = Convert.ToInt32(dato);

        //    //creamos tabla
        //    //0 - visitado
        //    //1 - Distancia
        //    //2 - previo
        //    int[,] tabla = new int[cantNodos, 3];

        //    //inicializar tanbla

        //    for (n = 0; n < cantNodos; n++)
        //    {
        //        tabla[n, 0] = 0;
        //        tabla[m, 1] = int.MaxValue;
        //        tabla[n, 2] = 0;
        //    }
        //    tabla[inicio, 1] = 0;

        //    MostrarTabla(tabla);

        //    for (distancia = 0; distancia < cantNodos; distancia++)
        //    {
        //        for (n = 0; n < cantNodos; n++)
        //        {
        //            if ((tabla[n, 0] == 0) && (tabla[n, 1] == distancia))
        //            {
        //                tabla[n, 0] = 1;
        //                for (m = 0; m < cantNodos; m++)
        //                {
        //                    //verificar que el nodo sea adyasente
        //                    if (grafo.ObtenerAdyacencia(n, m) == 1)
        //                    {
        //                        if (tabla[m, 1] == int.MaxValue)
        //                        {
        //                            tabla[m, 1] = distancia + 1;
        //                            tabla[m, 2] = n;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    MostrarTabla(tabla);

        //    List<int> ruta = new List<int>();
        //    int nodo1 = final;

        //    while (nodo1 != inicio)
        //    {
        //        ruta.Add(nodo1);
        //        nodo1 = tabla[nodo1, 2];
        //    }
        //    ruta.Add(inicio);

        //    ruta.Reverse();

        //    foreach (int posicion in ruta)
        //    {
        //        Console.Write("{0}->", posicion);

        //    }
        //    Console.WriteLine();


        //    //TODO:esto comentado aqui abajo por lo que vi solo se uso en el video 43 o 44 si no me equivoco
        //    //pero lo deje por si es necesario para los muchachos


        //    //grafo.Calcularindegree();
        //    //grafo.MostrarIndegree();

        //    //Console.ForegroundColor = ConsoleColor.Cyan;
        //    //do
        //    //{
        //    //    //encontramos el nodo con el indegree 0
        //    //    nodo = grafo.EncuentraI0();

        //    //    if (nodo != -1)
        //    //    {
        //    //        //imprime nodo
        //    //        Console.Write("{0}-> ", nodo);
        //    //        //decrementamos indegrees
        //    //        grafo.DecrementarIndigree(nodo);
        //    //    }
        //    //} while (nodo != -1);
        //}
    }
}
