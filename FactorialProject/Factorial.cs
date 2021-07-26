using System;
using System.Linq;
using System.Numerics;

namespace FactorialProject
{
    /// <summary>
    /// A store for Factorial methods.
    /// </summary>
    public class Factorial
    {
        /// <summary>
        /// It is a naive implementation of Factorial by the Linq (tale recursion is here, I think).
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public BigInteger NaiveRecursionLinq(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            var result = Enumerable
                .Range(1, n)
                .Select(el => (BigInteger)el)
                .Aggregate((aggregate, el) => aggregate * el);

            return result;
        }

        /// <summary>
        /// One of faster approaches.
        /// I like the calculation by a tree (other algorithms are kinda verbose).
        /// The idea is that multiplying of roughly the same values is much more efficient.
        /// This algorithm should be twice as faster than the <see cref="NaiveRecursionLinq"/>.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public BigInteger TreeCalculation(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }

            Func<int, int, BigInteger> treeMultiplier = null;
            treeMultiplier = (left, right) =>
            {
                if (left > right)
                {
                    return 1;
                }
                if (left == right)
                {
                    return left;
                }
                if (right - left == 1)
                {
                    return (BigInteger)left * right;
                }

                var median = (left + right) / 2;

                var result = treeMultiplier(left, median)
                    * treeMultiplier(median + 1, right);

                return result;
            };

            return treeMultiplier(2, n);
        }
    }
}
