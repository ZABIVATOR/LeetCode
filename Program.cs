namespace LeetCode
{

    class Test : IDailySolutions
    {
        static void Main()
        {
            /*
            string[] nums = { "24", "37", "96", "04" };
            int[][] q = [[2, 1], [2, 2]];
            Console.WriteLine("массив");
            foreach (var x in nums) { Console.Write(x + " "); }
            Console.WriteLine();
            var temp = IDailySolutions.Task2343SmallestTrimmedNumbers(nums,q);
            foreach (var x in temp) { Console.Write(x + " "); }
            */
            int[] startTime = [43, 13, 36, 31, 40, 5, 47, 13, 28, 16, 2, 11];
            int[] endTime = [44, 22, 41, 41, 47, 13, 48, 35, 48, 26, 21, 39];
            int[] profit = [8, 20, 3, 19, 16, 8, 11, 13, 2, 15, 1, 1];

            for (int i = 0; i < startTime.Length; i++)
            {
                Console.WriteLine("["+startTime[i]+", " + endTime[i]+", " + profit[i] +"]");
            }

            Console.WriteLine(IDailySolutions.Task1235_JobScheduling(startTime, endTime, profit));
        }
    }
}
