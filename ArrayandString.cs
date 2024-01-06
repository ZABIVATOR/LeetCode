using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal interface IArrayandString
    {

        static void AddDirectionToList(ref IList<int> list,ref int[][] matrix,ref string direction, 
            ref int minline,ref int mincolumn, ref int maxline, ref int maxcolumn , ref int actualline, ref int actualcolumn)
        {
            switch (direction)
            {
                case "right":
                    //fixed line
                    for (int column = actualcolumn; column < maxcolumn; column++)
                    {
                        list.Add(matrix[actualline][column]);
                    }
                    actualline++;
                    actualcolumn = maxcolumn - 1;

                    minline++;
                    direction = "down";
                    break;

                case "down":
                    //fixed column
                    for (int line = actualline; line < maxline; line++)
                    {
                        list.Add(matrix[line][actualcolumn]);
                    }
                    actualcolumn --;
                    actualline=maxline-1;

                    maxcolumn--;
                    direction = "left";
                    break;

                case "left":
                    //fixed line
                    for (int column = actualcolumn; column >=mincolumn; column--)
                    {
                        list.Add(matrix[actualline][column]);
                    }
                    actualline--;
                    actualcolumn = mincolumn;


                    maxline--;
                    direction = "up";
                    break;

                case "up":
                    //fixed column
                    for (int line = actualline; line >=minline; line--)
                    {
                        list.Add(matrix[line][actualcolumn]);
                    }
                    actualcolumn++;
                    actualline = minline;

                    mincolumn++;
                    direction = "right";
                    break;

            }

        }
        static public IList<int> Task54_SpiralOrder(int[][] matrix)//54. Spiral Matrix
        {
            int minline = 0;//количество строк
            int mincolumn = 0;//количество столбцов
            int maxline = matrix.Length;//количество строк
            int maxcolumn = matrix[0].Length;//количество столбцов
            IList<int> result = new List<int>();

            
            int actualline = 0;
            int actualcolumn = 0;
            string direction = "right";

            while (maxline>minline && maxcolumn > mincolumn)
            {
                AddDirectionToList(ref result,ref matrix,ref direction,ref minline,ref mincolumn, ref maxline, ref maxcolumn, ref actualline, ref actualcolumn);

            }
            return result;
        }


        static void AdddiagonaltoList(ref List<int> result, ref int[][] mat, int count, bool up)
        {
            if (up)
            {
                for (int i = 0; i < count + 1; i++)
                {
                    if (i < mat.Length && count - i < mat[0].Length)
                    {
                        result.Add(mat[i][count - i]);
                    }
                }
            }
            else
            {
                for (int i = count; i >= 0; i--)
                {
                    if (i < mat.Length && count - i < mat[0].Length)
                    {
                        result.Add(mat[i][count - i]);
                    }
                }
            }

        }
        static public int[] Task498_FindDiagonalOrder(int[][] mat)//498. Diagonal Traverse
        {
            List<int> result = new List<int>();
            int countdiag = mat.Length + mat[0].Length + 1;
            bool up = true;
            result.Add(mat[0][0]);

            for (int i = 1; i < countdiag; i++)
            {
                AdddiagonaltoList(ref result, ref mat, i, up);
                up = !up;
            }
            return result.ToArray();
        }

        static int[] CaseNines(int[] arr1)
        {
            int[] res = new int[arr1.Length + 1];
            res[0] = 1;
            for (int i = 0; i < arr1.Length; i++)
            {
                res[i + 1] = arr1[i];
            }
            return res;
        }
        static public int[] Task66_PlusOne(int[] digits)//66. Plus One
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                    if (i == 0)
                    {
                        return CaseNines(digits);
                    }

                }
                else
                {
                    digits[i] = digits[i] + 1;
                    break;
                }
            }
            return digits;
        }

        static public int Task747_DominantIndex(int[] nums)//747. Largest Number At Least Twice of Others
        {
            Dictionary<int, int> result = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!result.ContainsKey(nums[i]))
                    result.Add(nums[i], i);
            }

            int max = result.Keys.Max();
            int maxindex = result[max];
            result.Remove(max);
            if (max >= 2 * result.Keys.Max())
            {
                return maxindex;
            }
            else
                return -1;
        }

        static public int Task724_PivotIndex(int[] nums)
        {
            int leftsum = 0;
            int rightsum = nums.Sum() - nums[0];
            if (leftsum == rightsum)
            {
                return 0;
            }


            for (int i = 1; i < nums.Length; i++)
            {
                leftsum += nums[i - 1];
                rightsum -= nums[i];
                if (leftsum == rightsum)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
