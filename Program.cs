namespace LeetCode
{

    class Test : IDailySolutions, ISorting
    {
        static void Main()
        {
            string[] nums = { "24", "37", "96", "04" };
            int[][] q = [[2, 1], [2, 2]];
            Console.WriteLine("массив");
            foreach (var x in nums) { Console.Write(x + " "); }
            Console.WriteLine();
            var temp = IDailySolutions.Task2343SmallestTrimmedNumbers(nums,q);
            foreach (var x in temp) { Console.Write(x + " "); }
        }
    }
}
