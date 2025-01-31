﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathFirstSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listOfLinks = new string[]
            {
                "28 36",
                "0 2",
                "3 34",
                "29 21",
                "37 35",
                "28 32",
                "0 10",
                "37 2",
                "4 5",
                "13 14",
                "34 35",
                "27 19",
                "28 34",
                "30 31",
                "18 26",
                "0 9",
                "7 8",
                "18 24",
                "18 23",
                "0 5",
                "16 17",
                "29 30",
                "10 11",
                "0 12",
                "15 16",
                "0 11",
                "0 17",
                "18 22",
                "23 24",
                "0 7",
                "35 23",
                "22 23",
                "1 2",
                "0 13",
                "18 27",
                "25 26",
                "32 33",
                "28 31",
                "24 25",
                "28 35",
                "21 22",
                "4 33",
                "28 29",
                "36 22",
                "18 25",
                "37 23",
                "18 21",
                "5 6",
                "19 20",
                "0 14",
                "35 36",
                "9 10",
                "0 6",
                "20 21",
                "0 3",
                "33 34",
                "14 15",
                "28 33",
                "11 12",
                "12 13",
                "17 1",
                "18 19",
                "36 29",
                "0 4",
                "0 15",
                "0 1",
                "18 20",
                "2 3",
                "0 16",
                "8 9",
                "0 8",
                "26 27",
                "28 30",
                "3 4",
                "31 32",
                "6 7",
                "37 1",
                "37 24",
                "35 2"
            };

            int[] gateWays = new int[] { 0, 18, 28 };
            int N = 38;
            int[] agentPosition = new int[] {  };

            string[] result = DeathFirstSearchLogic.DeathFirstSearchManager.Execute(listOfLinks, gateWays, N, agentPosition).ToArray();
        
        }
    }
}
