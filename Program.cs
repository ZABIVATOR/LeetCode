namespace LeetCode
{
    class Test : Solutions
    {
        static void Main()
        {
            int[] nums = { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            nums = HeapSort.Sort(nums);
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.Write(nums[i]);
                }
            
        }
    }
}
