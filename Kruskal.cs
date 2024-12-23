using System;
using System.Collections.Generic;

class DisjointSet
{
    private int[] parent;
    private int[] rank;

    public DisjointSet(int n)
    {
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int u)
    {
        if (parent[u] != u)
        {
            parent[u] = Find(parent[u]);  // Path compression
        }
        return parent[u];
    }

    public void Union(int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);

        if (rootU != rootV)
        {
            // Union by rank
            if (rank[rootU] > rank[rootV])
            {
                parent[rootV] = rootU;
            }
            else if (rank[rootU] < rank[rootV])
            {
                parent[rootU] = rootV;
            }
            else
            {
                parent[rootV] = rootU;
                rank[rootU]++;
            }
        }
    }
}

class KruskalAlgorithm
{
    public static List<Tuple<int, int, int>> Kruskal(int n, List<Tuple<int, int, int>> edges)
    {
        // Step 1: Sort edges by weight
        edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));  // Sort by weight

        // Step 2: Initialize disjoint set
        DisjointSet disjointSet = new DisjointSet(n);

        List<Tuple<int, int, int>> mst = new List<Tuple<int, int, int>>();  // Store MST edges
        foreach (var edge in edges)
        {
            int u = edge.Item1;
            int v = edge.Item2;
            int weight = edge.Item3;

            // Step 3: Check if u and v are in different sets
            if (disjointSet.Find(u) != disjointSet.Find(v))
            {
                // Step 4: Include this edge in the MST
                mst.Add(edge);
                disjointSet.Union(u, v);
                if (mst.Count == n - 1)  // Stop when the MST has n-1 edges
                {
                    break;
                }
            }
        }

        return mst;
    }

    public static void Main()
    {
        int n = 4;  // Number of vertices
        var edges = new List<Tuple<int, int, int>>()
        {
            Tuple.Create(0, 1, 10),
            Tuple.Create(0, 2, 6),
            Tuple.Create(0, 3, 5),
            Tuple.Create(1, 3, 15),
            Tuple.Create(2, 3, 4)
        };  // List of edges in the form (u, v, weight)

        var mst = Kruskal(n, edges);

        Console.WriteLine("Minimum Spanning Tree:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"({edge.Item1}, {edge.Item2}) with weight {edge.Item3}");
        }
    }
}

