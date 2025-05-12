using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Utils
{
    public class Graph<T>
    {
        private Dictionary<T, List<T>> _adjacencyList = new Dictionary<T, List<T>>();

        public void AddVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
                _adjacencyList[vertex] = new List<T>();
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            if (!_adjacencyList.ContainsKey(vertex1))
                AddVertex(vertex1);
            if (!_adjacencyList.ContainsKey(vertex2))
                AddVertex(vertex2);

            _adjacencyList[vertex1].Add(vertex2);
            _adjacencyList[vertex2].Add(vertex1); // Assuming undirected graph
        }

        public List<T> GetNeighbors(T vertex)
        {
            return _adjacencyList.ContainsKey(vertex) ? _adjacencyList[vertex] : new List<T>();
        }

        public bool ContainsVertex(T vertex)
        {
            return _adjacencyList.ContainsKey(vertex);
        }
    }
}
