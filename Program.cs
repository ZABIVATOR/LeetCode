namespace LeetCode
{

    class Test : IDailySolutions
    {
        static void Main()
        {

            int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];

            var  temp = IDailySolutions.Task54_SpiralOrder(matrix);
            foreach (var x in temp) { Console.Write(x + " "); }
            

        }
    }
}
