namespace DeathFirstSearchTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string[] listOfLinks = new string[]
            {
                "11 6",
                "0 9",
                "1 2",
                "0 1",
                "10 1",
                "11 5",
                "2 3",
                "4 5",
                "8 9",
                "6 7",
                "7 8",
                "0 6",
                "3 4",
                "0 2",
                "11 7",
                "0 8",
                "0 4",
                "9 10",
                "0 5",
                "0 7",
                "0 3",
                "0 10",
                "5 6"
            };

            int[] gateWays = new int[] { 0 };
            int N = 12;
            int[] agentPosition = new int[] { 11, 5, 6 ,7, 8, 9, 10, 1, 2, 3 };


            string[] expected = new string[]
            {
                "0 9",
                "5 0",
                "6 0",
                "7 0",
                "8 0",
                "0 1",
                "10 0",
                "0 2",
                "0 4",
                "3 0"
            };

            string[] result = DeathFirstSearchLogic.DeathFirstSearchManager.Execute(listOfLinks, gateWays, N, agentPosition).ToArray();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test2()
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
            int[] agentPosition = new int[] { 37, 35, 23, 22, 21, 29, 36, 35, 34, 3, 4, 33, 32, 31, 30, 29, 21, 20, 19, 27, 26, 25, 24, 37, 1, 17, 16, 15, 14, 13, 12, 11, 10, 9};

            
            string[] expected = new string[]
            {
                "0 2",
                "35 28",
                "23 18",
                "22 18",
                "21 18",
                "29 28",
                "36 28",
                "0 10",
                "34 28",
                "3 0",
                "4 0",
                "33 28",
                "32 28",
                "31 28",
                "30 28",
                "0 9",
                "0 5",
                "20 18",
                "19 18",
                "27 18",
                "26 18",
                "25 18",
                "24 18",
                "0 12",
                "1 0",
                "17 0",
                "16 0",
                "15 0",
                "14 0",
                "13 0",
                "0 11",
                "0 7",
                "0 6",
                "0 8"

            };

            string[] result = DeathFirstSearchLogic.DeathFirstSearchManager.Execute(listOfLinks, gateWays, N, agentPosition).ToArray();

            Assert.AreEqual(expected, result);
        }
    }
}