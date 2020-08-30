using System;
using Xunit;

namespace WMS.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a=2;
            int b=6;
            int suma = a + b;
            Assert.Equal(8, suma);
        }
    }
}
