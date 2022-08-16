using System;
using System.Collections.Generic;

namespace Number_of_Operations_to_Make_Network_Connected
{
  class Program
  {
    static void Main(string[] args)
    {
      int n = 6;
      var connections = new int[7][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 3, 2 }, new int[] { 5, 4 } };
      Solution s = new Solution();
      var answer = s.MakeConnected(n, connections);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int MakeConnected(int n, int[][] connections)
    {
      if (connections.Length < n - 1) return -1;

      Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
      foreach (var connection in connections)
      {
        int s = connection[0];
        int d = connection[1];

        if (!adj.ContainsKey(s))
          adj.Add(s, new List<int>());

        if (!adj.ContainsKey(d))
          adj.Add(d, new List<int>());

        adj[s].Add(d);
        adj[d].Add(s);
      }

      bool[] visited = new bool[n];
      int component = 0;
      for (int i = 0; i < n; i++)
      {
        if (!visited[i])
        {
          component++;
          Dfs(i, adj, visited);
        }
      }

      return component - 1;
    }

    private void Dfs(int src, Dictionary<int, List<int>> adj, bool[] visited)
    {
      visited[src] = true;
      if (adj.ContainsKey(src))
      {
        foreach (var n in adj[src])
        {
          if (!visited[n])
            Dfs(n, adj, visited);
        }
      }
    }
  }
}
