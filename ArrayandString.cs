using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal interface IArrayandString:ISorting
    {
        public void Task283_MoveZeroes(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] != 0)
                        {
                            var temp = nums[j];
                            nums[j] = nums[i];
                            nums[i] = temp;
                            break;
                        }
                    }
                }
            }
        }

        public int Task26_RemoveDuplicates(int[] nums)
        {
            int k = 1;
            int previouse = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != previouse)
                {
                    nums[k] = nums[i];
                    k++;
                }
                previouse = nums[i];
            }
            return k;
        }

        public string Task557_ReverseWords(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            for (int i = 0; i < words.Length; i++)
            {
                char[] chArray = words[i].ToCharArray();
                Array.Reverse(chArray);
                words[i] = new string(chArray);
            }
            return string.Join(" ", words);
        }

        public string Task151_ReverseWords(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        public void Task189_Rotate(int[] nums, int k)
        {
            int[] output = new int[nums.Length];
            int length = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                output[(i + k) % length] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = output[i];
            }
        }

        static public int Task209_MinSubArrayLen(int target, int[] nums)
        {
            int start = 0;
            int end = 0;
            int w_sum = nums[0];
            int maxLen = int.MaxValue;
            while (end < nums.Length)
            {
                if (w_sum < target)
                {
                    end++;
                    if (end < nums.Length)
                        w_sum += nums[end];
                }
                else
                {
                    maxLen = Math.Min(maxLen, end - start + 1);
                    w_sum -= nums[start];
                    start++;
                }
            }
            return maxLen == int.MaxValue ? 0 : maxLen;
        }

        public int Task485_FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    count++;
                else
                {
                    if (count > max)
                    {
                        max = count;
                    }
                    count = 0;
                }
            }
            if (count > max)
            {
                max = count;
            }
            return max;
        }

        public int Task27_RemoveElement(int[] nums, int val)
        {
            int count = 0;


            for (int i = 0; i < nums.Length - 1 - count; i++)
            {
                int t = 0;
                for (int j = nums.Length - 1; j > i; j--)
                {
                    if (nums[j] != val)
                    {
                        t = j;
                        break;
                    }
                }


                if (nums[i] == val && t > i)
                {
                    var temp = nums[i];
                    nums[i] = nums[t];
                    nums[t] = temp;
                    count++;
                }
            }
            count = 0;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != val) { count++; }
            return count;
        }

        public int[] Task167_TwoSum(int[] numbers, int target)
        {
            int temp = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] + numbers[j] == target && i!=j)
                    {
                        return ([j+1, i+1]);
                    }

                }
                temp++;
            }
            return ([numbers.Length]);
        }

        public int Task561_ArrayPairSum(int[] nums)
        {
            int sum = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }
            return sum;
        }

        public void Task344_ReverseString(char[] s)
        {
            Array.Reverse(s);
        }

        static public string Task14_LongestCommonPrefix(string[] strs)//14. Longest Common Prefix
        {
            if (strs.Length == 1)
            {
                return strs[0];
            }

            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            if (strs[0].Length == 0)
            {
                return "";
            }
            if (strs.Length == 1)
            {
                return Convert.ToString(strs[0][0]);
            }
            string preprefix = "";
            string prefix = "";
            int minLength = strs.Min(y => y.Length);

            for (int i = 0; i < minLength+1; i++)
            {
                foreach (string str in strs)
                {
                    if (!str.StartsWith(prefix))
                    {
                        return preprefix;
                    }
                }
                preprefix = prefix;
                if (i < minLength)
                    prefix += strs[0][i];
            }
            return prefix;
        }
    
        public int Task28_StrStr(string haystack, string needle)//28. Find the Index of the First Occurrence in a String
        {
            return haystack.IndexOf(needle);
        }

        public static string Task67_AddBinary_KAKOGO_HUYA_MNE_NUZNO_PISAT_BITOVYU_LOGICU(string a, string b)//67. Add Binary
        {
            var first = Convert.ToInt32(a, 2);
            var second = Convert.ToInt32(b, 2);
            var res = first + second;
            string binary = Convert.ToString(res, 2);
            return(binary);
        }

        public IList<IList<int>> Task118_GeneratePascalTri(int numRows)//118. Pascal's Triangle
        {
            IList<IList<int>> triangle = new List<IList<int>>();
            IList<int> firstrow = new List<int>();
            firstrow.Add(1);
            triangle.Add(firstrow); 
            for (int i = 1; i < numRows; i++)
            {
                IList<int> row = new List<int>();
                row.Add(1);
                for(int j = 1; j < i; j++)
                {
                    row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
                row.Add(1);
                triangle.Add(row);
            }
            return triangle;
        }
        public IList<int> Task119_GetRow(int rowIndex)
        {
            return Task118_GeneratePascalTri(rowIndex+1).ElementAt(rowIndex);
        }

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
