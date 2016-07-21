using System.Numerics;

namespace FactorialProject
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {

            var factorial = new Factorial();

            // ReSharper disable TooWideLocalVariableScope
            BigInteger naive;
            BigInteger tree;

            // Some code-test to throw ((
            for (int i = 0; i < 1000; i++)
            {
                naive = factorial.NaiveRecursionLinq(i);

                tree = factorial.TreeCalculation(i);

                if (naive != tree)
                {
                    // Something goes wrong. Possibly it is an overflow.
                }
                if (naive < 0)
                {
                    // The case of overflow.
                }
                if (tree < 0)
                {
                    // The case of overflow.
                }

            }

            factorial.NaiveRecursionLinq(100000);
            // To feel it here how it faster.
            factorial.TreeCalculation(100000);

        }


    }
}
