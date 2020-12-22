using System;

namespace GrafoTopologico
{
    public class Grafo
    {
       
        int[,] madyacencia;
        int[] indegree;        
        int nodos;

        public Grafo(int pNodos)
        {
            nodos = pNodos;

            madyacencia = new int[nodos, nodos];

            indegree = new int[nodos];
        }
        public void AdiccionarArista(int pNodoInicio, int pNodoFinal)
        {
            madyacencia[pNodoInicio, pNodoFinal] = 1;
        }

        public void MuestraAdyacencia()
        {
            int Fila, Columna = 0;
            Console.ForegroundColor = ConsoleColor.Red;

            for (Fila = 0; Fila < nodos; Fila++)
                Console.Write("\t{0}", Fila);

            Console.WriteLine();

            for (Fila = 0; Fila < nodos; Fila++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Fila);
                for (Columna = 0; Columna < nodos; Columna++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t{0}", madyacencia[Fila, Columna]);
                }
                Console.WriteLine();
            }
        }

        public int ObtenerAdyacencia(int pFila, int pColumna)
        {
            return madyacencia[pFila, pColumna];
        }

        public void Calcularindegree()
        {
            int n, m = 0;
            for (n = 0; n < nodos; n++)
            {
                for (m = 0; m < nodos; m++)
                {
                    if (madyacencia[m, n] == 1)
                        indegree[n]++;
                }
            }
        }

        public void MostrarIndegree()
        {
            int n = 0;
            Console.ForegroundColor = ConsoleColor.White;
            for (n = 0; n < nodos; n++)
            {
                Console.WriteLine("Nodo: {0}, {1}", n, indegree[n]);
            }
        }

        public int EncuentraI0()
        {
            bool encontrado = false;
            int n = 0;

            for (n = 0; n < nodos; n++)
            {
                if (indegree[n] == 0)
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
                return n;
            else
                return -1; //indica que no se a encontrado
        }

        public void DecrementarIndigree(int pNodo)
        {
            indegree[pNodo] = 1;
            for (int n = 0; n < nodos; n++)
            {
                if (madyacencia[pNodo, n] == 1)
                    indegree[n]--;
            }
        }

        public void AddArista(int nInicial, int nFinal)
        {
            madyacencia[nInicial, nFinal] = 1;

        }
        public void AddArista(int nInicial, int nFinal, int peso)
        {
            madyacencia[nInicial, nFinal] = peso;
        }
        public void Show()
        {
            int col = 0;
            int fil = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            for (col = 0; col < nodos; col++)
            {
                Console.Write($"\t     {col}");
            }
            Console.WriteLine();

            for (col = 0; col < nodos; col++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\t{col}");
                for (fil = 0; fil < nodos; fil++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\t{madyacencia[col, fil]}");
                }
                Console.WriteLine();
            }
        }

        public static void MostrarTabla(int[,] pTabla)//metodo para mostrar la tabla de dijkstra
        {

            for (int n = 0; n < pTabla.GetLength(0); n++)
            {
                Console.WriteLine($"{n}-> {pTabla[n, 0]}\t{pTabla[n, 1]}\t{pTabla[n, 2]}");
            }
            Console.WriteLine("----------------");
        }
    }
}
