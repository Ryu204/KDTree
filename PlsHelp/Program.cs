using KDTree;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            WikiTest();
            RandomTest(1000);
            RandomTest(1000000);
        }

        static void WikiTest()
        {
            double[][] coords = new double[][]
            {
                new double[] {2, 3 },
                new double[] {5, 4 },
                new double[] {9, 6 },
                new double[] {4, 7 },
                new double[] {8, 1 },
                new double[] {7, 2}
            };

            List<Point<double>> points = new List<Point<double>>();
            for (int i = 0; i < coords.Length; i++)
            {
                points.Add(new Point<double>(coords[i]));
            }
            Tree<double> tree = new Tree<double>(2, points);
            Point<double> nearest = tree.FindNearest(new Point<double>(9, 2));
            Console.WriteLine($"Wiki:\nnearest:{nearest}\ndistance:{tree.Distance()}\nvisited:{tree.Visited()}");
        }

        static Point<double> RandomPoint(Random random)
        {
            return new Point<double>(random.NextDouble(), random.NextDouble(), random.NextDouble());
        }

        static void RandomTest(int pointCount)
        {
            Random random = new();
            List<Point<double>> points = new();
            for (int i = 0; i < pointCount; ++i)
                points.Add(RandomPoint(random));
            Tree<double> tree = new(3, points);
            Point<double> target = RandomPoint(random);
            Point<double> nearest = tree.FindNearest(target);
            Console.WriteLine($"Random data ({pointCount} points):\ntarget:{target}\nnearest:{nearest}\ndistance:{tree.Distance()}\nvisited:{tree.Visited()}");
        }
    }
}