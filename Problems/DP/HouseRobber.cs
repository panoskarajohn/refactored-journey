﻿namespace Problems.DP;

public class HouseRobber
{
    public int Rob(int[] houses)
    {
        int n = houses.Length;
        int[] dp = new int[n];

        dp[0] = houses[0];
        dp[1] = Math.Max(houses[0], houses[1]);
        int money = 0;
        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + houses[i]);
        }

        return dp[^1];
    }
}