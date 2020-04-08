using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// https://codeforces.com/problemset/problem/1292/A
/// </summary>
namespace Learning
{
    class Nekos_Maze
    {
        public Nekos_Maze()
        {
            var n = 7;
            var maze = new int[2, n];

            var q = new List<List<int>>()
            {
                new List<int>{ 0,n-1},
                new List<int>{ 0,3},
                new List<int>{ 1,4},


            };


            var res = Solve(maze, q);

            for (int i = 0; i < q.Count; i++)
            {
                Console.WriteLine(res[i]);
            }
            Console.ReadKey();
        }

        private List<bool> Solve(int[,] maze, List<List<int>> q)
        {
            var qRes = new List<bool>(q.Count);
            var tempQ = new List<List<int>>();
            var lastTempLength = tempQ.Count;
            var listComparer = new ListComparer();
            for (int i = 0; i < q.Count; i++)
            {
                var tempRes = true;
                if (tempQ.Contains(q[i], listComparer))
                {
                    var tt = tempQ.First(x => listComparer.Equals(x, q[i]));
                    tempQ.Remove(tt);
                }
                else
                {
                    tempQ.Add(q[i]);
                }

                if (i > 0 && !qRes[i - 1] && tempQ.Count > lastTempLength)
                {
                    qRes.Add(false);
                    lastTempLength = tempQ.Count;

                    continue;
                }
                else
                {
                    for (int j = 0; j < tempQ.Count; j++)
                    {
                        if (tempQ[j][0] == 0)
                        {
                            var currentPair = tempQ[j];
                            var corners = new List<List<int>>()
                            {
                                new List<int>{ currentPair[0] + 1, currentPair[1]+1},
                                new List<int>{ currentPair[0] + 1, currentPair[1]-1},
                                new List<int>{ currentPair[0] + 1, currentPair[1]},
                            };
                            if (corners.Any(x => tempQ.Contains(x, listComparer)))
                            {
                                lastTempLength = tempQ.Count;

                                tempRes = false;

                                break;
                            }
                        }
                        else if (tempQ[j][0] == 1)
                        {
                            var currentPair = tempQ[j];
                            var corners = new List<List<int>>()
                            {
                                new List<int>{ currentPair[0] - 1, currentPair[1]+1},
                                new List<int>{ currentPair[0] - 1, currentPair[1]-1},
                                new List<int>{ currentPair[0] - 1, currentPair[1]},
                            };
                            if (corners.Any(x => tempQ.Contains(x, listComparer)))
                            {
                                lastTempLength = tempQ.Count;

                                tempRes = false;
                                break;
                            }
                        }
                    }

                    lastTempLength = tempQ.Count;

                    qRes.Add(tempRes);

                    for (int i1 = 0; i1 < 2; i1++)
                    {
                        for (int j1 = 0; j1 < maze.GetLength(1); j1++)
                        {
                            var tt = false;
                            foreach (var item in tempQ)
                            {
                                if(item[0] == i1 && item[1] == j1)
                                {
                                    Console.Write('X');
                                    tt = true;
                                    break;
                                }
                            }
                            if(!tt)
                                Console.Write('_');
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                }


            }

            return qRes;
        }

        public class ListComparer : EqualityComparer<List<int>>
        {
            public override bool Equals(List<int> r1, List<int> r2)
            {
                if (r1[0] == r2[0] && r1[1] == r2[1])
                    return true;
                return false;
            }

            public override int GetHashCode(List<int> r1)
            {
                var hash = 0;

                foreach (var item in r1)
                {
                    hash += item;
                }

                return hash;
            }

        }
    }
}
