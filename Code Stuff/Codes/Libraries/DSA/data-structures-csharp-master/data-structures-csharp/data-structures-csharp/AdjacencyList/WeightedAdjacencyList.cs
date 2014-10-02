﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DataStructures.AdjacencyList
{
    [Serializable]
    public class WeightedAdjacencyList<T>
        where T : class
    {
        private readonly Dictionary<T, HashSet<Node<T>>> dict;

        public IList<T> Vertices 
        {
            get { return dict.Keys.ToList(); }
        }

        public int Count 
        {
            get { return dict.Count; }
        }

        public WeightedAdjacencyList() 
        {
            dict = new Dictionary<T, HashSet<Node<T>>>();
        }

        public WeightedAdjacencyList(int capacity)
        {
            Contract.Requires<ArgumentOutOfRangeException>(capacity > 0);
            
            dict = new Dictionary<T, HashSet<Node<T>>>(capacity);
        }

        public void AddVertex(T vertex)
        {
            Contract.Requires<ArgumentNullException>(vertex != null);
            
            if(dict.ContainsKey(vertex))
            {
                return;
            }
            dict[vertex] = new HashSet<Node<T>>();
        }

        public void AddEdge(T vertex1, T vertex2, double weight) 
        {
            Contract.Requires<ArgumentNullException>(vertex1 != null);
            Contract.Requires<ArgumentNullException>(vertex2 != null);
            
            if(!dict.ContainsKey(vertex1))
            {
                dict[vertex1] = new HashSet<Node<T>>();
            }
            if(!dict.ContainsKey(vertex2))
            {
                dict[vertex2] = new HashSet<Node<T>>();
            }
            dict[vertex1].Add(new Node<T>(vertex2, weight));
            dict[vertex2].Add(new Node<T>(vertex1, weight));
        }

        public bool IsNeighbourOf(T vertex, T neighbour) 
        {
            Contract.Requires<ArgumentNullException>(vertex != null);
            Contract.Requires<ArgumentNullException>(neighbour != null);
            
            return dict.ContainsKey(vertex) && dict[vertex].Contains(neighbour);
        }

        public IList<double> GetAllWeights(T vertex) 
        {
            Contract.Requires<ArgumentNullException>(vertex != null);
            return dict.ContainsKey(vertex) ?
                   dict[vertex].Select(n =>n.weight).ToList() :
                   new List<double>();
        }

        public IList<Tuple<T, double>> GetNeighbours(T vertex) 
        {
            Contract.Requires<ArgumentNullException>(vertex != null);

            return dict.ContainsKey(vertex)?
                   dict[vertex].Select(n => new Tuple<T, double>(n.item, n.weight)).ToList() :
                   new List<Tuple<T, double>>();
        }

        private class Node<T>
            where T : class
        {
            public T item;
            public double weight;

            public Node(T item, double weight)
            {
                this.item = item;
                this.weight = weight;
            }

            public bool Equals(T item) 
            {
                return this.item.Equals(item);
            }

            public bool Equals(Node<T> node)
            {
                return this.item.Equals(node.item) &&
                       (weight == node.weight);
            }

            public override bool Equals(object obj)
            {
                if(obj is T)
                {
                    return item.Equals(obj as T);
                }
                if(obj is Node<T>)
                {
                    return Equals(obj as Node<T>);
                }
                return false;
            }

            public override int GetHashCode()
            {
                return item.GetHashCode() ^ weight;
            }
        }
    }
}
