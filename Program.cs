namespace LeetCode
{
    
    class Test : Solutions
    {
        static void Main()
        {
            int[] nums = {0, 1, 0, 3, 2, 3};
            Console.WriteLine( "массив");
            foreach (int x in nums) { Console.Write(x + " "); }
            Console.WriteLine();
            nums = LengthOfLIS_dynamic(nums);
            foreach(int x in nums) { Console.Write(x+" "); }
        }
    }
}
