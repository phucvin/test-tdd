using System;

namespace TestTdd
{
    internal class SimpleService
    {
        public void Add(int a, int b, Action<bool, int> handler)
        {
            handler(true, a + b);
        }

        public void WhatTimeIsIt(Action<bool, long> handler)
        {
            handler(true, 123);
        }
    }
}