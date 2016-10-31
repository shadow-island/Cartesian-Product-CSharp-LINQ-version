using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public static class Cartesian
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>
            (this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct 
                = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
        }

        static void Main(string[] args)
        {
            int[][] items = {
                    new[] { 1, 2, 3 },
                    new[] { 4, 5 },
                    new[] { 6 }
                };
            var routes = CartesianProduct(items);
            foreach (var route in routes)
                Console.WriteLine(string.Join(", ", route));
        }
    }
}
