﻿using System.Security.AccessControl;

namespace Problems.Google.GraphsTrees;

public class CheapestFlightsWithinKStops
{
    private readonly Dictionary<int, List<(int cost, int dest)>> _graph 
        = new Dictionary<int, List<(int cost, int dest)>>();

    /// <summary>
    /// Bellman ford approach
    /// </summary>
    /// <param name="n"></param>
    /// <param name="flights">graph</param>
    /// <param name="src">travel from</param>
    /// <param name="dst">destination</param>
    /// <param name="k">number of stops</param>
    /// <returns>Min cost per k stops</returns>
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        if (src == dst)
            return 0;

        if (flights is null || !flights.Any())
            return 0;
        
        Span<int> prices = stackalloc int[n];
        FillSpan(prices);
        prices[src] = 0;

        for (int i = 0; i < k + 1; i++)
        {
            Span<int> tmpPrices = new int[n];
            prices.CopyTo(tmpPrices);
            foreach (var flight in flights)
            {
                int source = flight[0];
                int destination = flight[1];
                int cost = flight[2];
                
                if (prices[source] == int.MaxValue) continue;
                if (prices[source] + cost < tmpPrices[destination])
                    tmpPrices[destination] = prices[source] + cost;
            }

            tmpPrices.CopyTo(prices);
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];


        return -1;
    }

    void FillSpan(Span<int> span, int valueToFill = int.MaxValue)
    {
        int n = span.Length;
        for (int i = 0; i < n; i++)
        {
            span[i] = valueToFill;
        }
        
    }
}