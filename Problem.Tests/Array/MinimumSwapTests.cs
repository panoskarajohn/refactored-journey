﻿using FluentAssertions;
using Problems.Array;
using Xunit;

namespace Problem.Tests.Array;

public class MinimumSwapTests
{
    [Theory]
    [InlineData(new int[] {7, 1, 3, 2, 4, 5, 6}, 5)]
    [InlineData(new int[] {2, 3, 4, 1, 5}, 3)]
    [InlineData(new int[] {1, 3, 5, 2, 4, 6, 7}, 3)]
    public void Minimum_Swap_Tests(int[] array, int expectedSwaps)
    {
        var result =  MinimumSwaps.Get(array);
        result.Should().Be(expectedSwaps);
    }
}
