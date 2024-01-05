namespace LeetCode
{

    class Test : IDaily_Solutions, ISorting
    {
        static void Main()
        {
            int[] nums = { 3, 8, -10, 23, 19, -4, -14, 27 };
            Console.WriteLine("массив");
            foreach (int x in nums) { Console.Write(x + " "); }
            Console.WriteLine();
            var temp = ISorting.Task1200_MinimumAbsoluteDifference(nums);
            foreach (var x in temp) {
                Console.Write("["+x[0] + ", " + x[1]+"] "); 
            }
        }
    }
}
