using System;
namespace simulation
{
    public class Network
    {
        private int[,] _distances;
        private int[,] _next;

        public Network(string[,] map)
        {
            ComputeDistances(map);
        }


        private void ComputeDistances(string[,] map)
        {
            int noStops = map.Length;
            _distances = new int[noStops,noStops];
            _next = new int[noStops, noStops];
            for (int i=0;i<noStops;i++)
            {
                for (int j=0;j<noStops;j++)
                {
                    if(map[i,j] != "-1")
                    {
                        _distances[i, j] = Convert.ToInt32(map[i,j]);
                        _next[i,j] = j;
                    }
                    else
                    {
                        _distances[i, j] = int.MaxValue;
                        _next[i, j] = j;
                    }

                    if (i == j)
                    {
                        _distances[i, j] = 0;
                        _next[i, j] = j;

                    }
                }

            }

            Console.WriteLine($"Total Stops: {noStops}");
        }
    }
}
