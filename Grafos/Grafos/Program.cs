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
            int inicio = 2;
            int final = 0;
            int distancia = 0;
            int n, m = 0;
            int cantNodos = 7;
            string dato;
            int nodo = 0;

            Grafo grafo = new Grafo(cantNodos);
            grafo.AdiccionarArista(0, 1);
            grafo.AdiccionarArista(0, 3);
            grafo.AdiccionarArista(1, 3);
            grafo.AdiccionarArista(1, 4);
            grafo.AdiccionarArista(2, 0);
            grafo.AdiccionarArista(2, 5);
            grafo.AdiccionarArista(3, 2);
            grafo.AdiccionarArista(3, 4);
            grafo.AdiccionarArista(3, 5);
            grafo.AdiccionarArista(3, 6);
            grafo.AdiccionarArista(4, 6);
            grafo.AdiccionarArista(6, 5);

            grafo.MuestraAdyacencia();

            Console.WriteLine("Dame el indice del nodo inicio");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Dame el indice del nodo final");
            dato = Console.ReadLine();
            final = Convert.ToInt32(dato);

            //creamos tabla
            //0 - visitado
            //1 - Distancia
            //2 - previo
            int[,] tabla = new int[cantNodos, 3];

            //inicializar tanbla

            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[m, 1] = int.MaxValue;
                tabla[n, 2] = 0;
            }
            tabla[inicio, 1] = 0;

            MostrarTabla(tabla);

            for (distancia = 0; distancia < cantNodos; distancia++)
            {
                for (n = 0; n < cantNodos; n++)
                {
                    if ((tabla[n, 0] == 0) && (tabla[n, 1] == distancia))
                    {
                        tabla[n, 0] = 1;
                        for (m = 0; m < cantNodos; m++)
                        {
                            //verificar que el nodo sea adyasente
                            if (grafo.ObtenerAdyacencia(n, m) == 1)
                            {
                                if (tabla[m, 1] == int.MaxValue)
                                {
                                    tabla[m, 1] = distancia + 1;
                                    tabla[m, 2] = n;
                                }
                            }
                        }
                    }
                }
            }

            MostrarTabla(tabla);

            List<int> ruta = new List<int>();
            int nodo1 = final;

            while (nodo1 != inicio)
            {
                ruta.Add(nodo1);
                nodo1 = tabla[nodo1, 2];
            }
            ruta.Add(inicio);

            ruta.Reverse();

            foreach (int posicion in ruta)
            {
                Console.Write("{0}->", posicion);

            }
            Console.WriteLine();


            //TODO:esto comentado aqui abajo por lo que vi solo se uso en el video 43 o 44 si no me equivoco
            //pero lo deje por si es necesario para los muchachos


            //grafo.Calcularindegree();
            //grafo.MostrarIndegree();

            //Console.ForegroundColor = ConsoleColor.Cyan;
            //do
            //{
            //    //encontramos el nodo con el indegree 0
            //    nodo = grafo.EncuentraI0();

            //    if (nodo != -1)
            //    {
            //        //imprime nodo
            //        Console.Write("{0}-> ", nodo);
            //        //decrementamos indegrees
            //        grafo.DecrementarIndigree(nodo);
            //    }
            //} while (nodo != -1);




            Console.ReadKey();
        }

        private static void MostrarTabla(int[,] ptabla)
        {
            throw new NotImplementedException("Trabajar Leonardo");
        }
    }
}
