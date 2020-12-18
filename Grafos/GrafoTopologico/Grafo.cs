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
            throw new NotImplementedException("Trabajar Leonardo");
        }

        public void MuestraAdyacencia()
        {
            throw new NotImplementedException("Trabajar Starlin");
        }

        public int ObtenerAdyacencia(int pFila, int pColumna)
        {
            //video46 
            throw new NotImplementedException("Trabajar Starlin");
        }
        
        public void Calcularindegree()
        {
            throw new NotImplementedException("Trabajar Leonardo");
        }

        public void MostrarIndegree()
        {
            throw new NotImplementedException("Trabajar Starlin");
        }

        public int EncuentraI0()
        {
            throw new NotImplementedException("Trabajar Leonardo");
        }

        public void DecrementarIndigree(int pNodo)
        {
            throw new NotImplementedException("Trabajar Starlin");
        }
    }
}
