﻿using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
    public class Q9_02_Social_Network_Tester : Question
    {
        public static void PrintPeople(LinkedList<Person> path)
        {
            if (path == null)
            {
                Console.WriteLine("No path");
            }
            else
            {
                foreach (Person p in path)
                {
                    Console.WriteLine(p.GetID());
                }
            }
        }

        public static bool IsEqual(LinkedList<Person> path1, LinkedList<Person> path2, bool reverse)
        {
            if (path1 == null || path2 == null)
            {
                return path1 == null && path2 == null;
            }
            if (path1.Count != path2.Count)
            {
                return false;
            }

            for (int i = 0; i < path1.Count; i++)
            {
                int other = reverse ? path2.Count - i - 1 : i;
                if (path1.ElementAt(i) != path2.ElementAt(other))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsEquivalent(LinkedList<Person> path1, LinkedList<Person> path2)
        {
            bool f1 = IsEqual(path1, path2, false);
            bool f2 = IsEqual(path1, path2, true);
            return f1 || f2;
        }

        public override void Run()
        {
            int nPeople = 11;
            Dictionary<int, Person> people = new Dictionary<int, Person>();
            for (int i = 0; i < nPeople; i++)
            {
                Person p = new Person(i);
                people[i] = p;
            }

            int[][] edges = {
                new[]{ 1, 4 },
                new[]{ 1, 2 },
                new[]{ 1, 3 },
                new[]{ 3, 2 },
                new[]{ 4, 6 },
                new[]{ 3, 7 },
                new[]{ 6, 9 },
                new[]{ 9, 10 },
                new[]{ 5, 10 },
                new[]{ 2, 5 },
                new[]{ 3, 7 }
            };
            /*
            int[][] edges = {
                new[] { 1, 4},
                new[] {1, 2},
                new[] {4, 6},
                new[] {6, 9},
                new[] {9, 10},
                new[] {5, 10},
                new[] {2, 5}
            };
            */
            /*
            int[][] edges = { 
                new[] { 1, 2}, 
                new[] {1, 4},
                new[] {2, 3},
                new[] {3, 4},
                new[] {4, 6},
                new[] {5, 6},
                new[] {4, 5}
            }; 
            */
            foreach (int[] edge in edges)
            {
                Person source = people[edge[0]];
                source.AddFriend(edge[1]);

                Person destination = people[edge[1]];
                destination.AddFriend(edge[0]);
            }

            /*int i = 1;
			int j = 10;
			LinkedList<Person> path1 = findPathBFS(people, i, j);
			LinkedList<Person> path2 = findPathBiBFS(people, i, j);
			System.out.println("Path 1");
			printPeople(path1);
			System.out.println("Path 2");
			printPeople(path2);*/


            for (int i = 0; i < nPeople; i++)
            {
                for (int j = 0; j < nPeople; j++)
                {
                    LinkedList<Person> path1 = Q9_02_Social_NetworkA.FindPathBFS(people, i, j);
                    LinkedList<Person> path2 = Q9_02_Social_NetworkB.FindPathBiBFS(people, i, j);
                    if (!IsEquivalent(path1, path2))
                    {
                        Console.WriteLine("Not equal: " + i + " to " + j);
                        Console.WriteLine("Path 1");
                        PrintPeople(path1);
                        Console.WriteLine("Path 2");
                        PrintPeople(path2);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Is equal: " + i + " to " + j);
                    }
                }
            }
        }
    }
}
