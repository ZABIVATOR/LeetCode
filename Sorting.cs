using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    internal interface ISorting
    {
        static int[] Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                (arr[largest], arr[i]) = (arr[i], arr[largest]);

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                arr = Heapify(arr, n, largest);
            }
            return arr;
        }
        public static int[] Sort(int[] arr)
        {
            int n = arr.Length;
            // Построение кучи (перегруппируем массив)
            for (int i = n / 2 - 1; i >= 0; i--)
                arr = Heapify(arr, n, i);
            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                (arr[i], arr[0]) = (arr[0], arr[i]);
                // вызываем процедуру heapify на уменьшенной куче
                arr = Heapify(arr, i, 0);
            }
            return arr;
        }

        static public int[] Task75_SortColors(int[] nums)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            foreach (int i in nums)
            {
                switch (i)
                {
                    case 0:
                        red++;
                        break;
                    case 1:
                        green++;
                        break;
                    case 2:
                        blue++;
                        break;
                }
            }
            for (int i = 0; i < red; i++)
            {
                nums[i] = 0;
            }
            for (int i = red; i < red + green; i++)
            {
                nums[i] = 1;
            }
            for (int i = red + green; i < red + green + blue; i++)
            {
                nums[i] = 2;
            }
            return nums;
        }

        static public IList<IList<int>> Task1200_MinimumAbsoluteDifference_brootforce(int[] arr)//straight
        {
            Array.Sort(arr);
            IList<IList<int>> res = new List<IList<int>>();
            int n = arr.Length;
            int minimalminimaldifference = int.MaxValue;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) < minimalminimaldifference)
                    {
                        minimalminimaldifference = Math.Abs(arr[i] - arr[j]);
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) == minimalminimaldifference)
                    {
                        res.Add(new int[] { arr[i], arr[j] });
                    }
                }
            }

            return res;
        }

        static public IList<IList<int>> Task1200_MinimumAbsoluteDifference(int[] arr)//sort optimized
        {
            Array.Sort(arr);
            IList<IList<int>> result = new List<IList<int>>();
            int minDiff = int.MaxValue;
            for (int i = 1; i < arr.Length; i++)
            {
                int currentDiff = arr[i] - arr[i - 1];
                if (currentDiff < minDiff)
                {
                    minDiff = currentDiff;
                    result.Clear();
                    result.Add(new List<int> { arr[i - 1], arr[i] });
                }
                else if (currentDiff == minDiff)
                {
                    result.Add(new List<int> { arr[i - 1], arr[i] });
                }
            }
            return result;
        }

        static public int[] Task2343SmallestTrimmedNumbers(string[] nums, int[][] queries)//2343. Query Kth Smallest Trimmed Number
        {
            List<int> res = new();
            foreach (int[] q in queries)
            {
                int min = Task2343Countonequerry(nums, q[0], q[1]);
                // res.Add(int.Parse(nums[min]));
                res.Add(min);
            }
            return res.ToArray();
        }

        static int Task2343Countonequerry(string[] nums, int k, int trim)
        {
            int eachNumlenght = nums[0].Length;
            List<(string, int)> values = new();
            for (int i = 0; i < nums.Length; i++)
            {
                values.Add((nums[i].Substring(eachNumlenght - trim), i));
            }
            values.Sort((a, b) => a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2));
            return values.Skip(k - 1).ToList()[0].Item2;
        }

        //347. Top K Frequent Elements
        public int[] Task347_TopKFrequent(int[] nums, int k)
        {
            int[] res = new int[k];
            Dictionary<int,int> keyValuePairs = new();
            foreach (int elem in nums)
            {
                if (keyValuePairs.ContainsKey(elem)) 
                    keyValuePairs[elem]++;
                else 
                    keyValuePairs.Add(elem,1);
            }
            keyValuePairs = keyValuePairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            for (int i = 0;i < k;i++)
            {
                res[i]=keyValuePairs.ElementAt(keyValuePairs.Count-i-1).Key;
            }
            return res;
        }


        public void CountingSort(int[] arr)
        {
            // Sorts an array of integers where minimum value is 0 and maximum value is K
            int K = arr.Max();
            int[] counts = new int[K + 1];
            foreach (int elem in arr)
            {
                counts[elem] += 1;
            }
            // we now overwrite our original counts with the starting index
            // of each element in the final sorted array
            int startingIndex = 0;
            for (int i = 0; i < K + 1; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[arr.Length];
            foreach (int elem in arr)
            {
                sortedArray[counts[elem]] = elem;
                // since we have placed an item in index counts[elem], we need to
                // increment counts[elem] index by 1 so the next duplicate element
                // is placed in appropriate index
                counts[elem] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedArray[i];
            }
        }

        protected private static int NUM_DIGITS = 10;

        public void CountingSort(int[] arr, int placeVal)
        {
            // Sorts an array of integers where minimum value is 0 and maximum value is NUM_DIGITS
            int[] counts = new int[NUM_DIGITS];

            foreach (int elem in arr)
            {
                int current = elem / placeVal;
                counts[current % NUM_DIGITS] += 1;
            }

            // we now overwrite our original counts with the starting index
            // of each digit in our group of digits
            int startingIndex = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[arr.Length];
            foreach (int elem in arr)
            {
                int current = elem / placeVal;
                sortedArray[counts[current % NUM_DIGITS]] = elem;
                // since we have placed an item in index counts[current % NUM_DIGITS],
                // we need to increment counts[current % NUM_DIGITS] index by 1 so the
                // next duplicate digit is placed in appropriate index
                counts[current % NUM_DIGITS] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedArray[i];
            }
        }

        public void RadixSort(ref int[] arr)
        {
            int maxElem = int.MinValue;
            foreach (int elem in arr)
            {
                if (elem > maxElem)
                {
                    maxElem = elem;
                }
            }

            int placeVal = 1;
            while (maxElem / placeVal > 0)
            {
                CountingSort(arr, placeVal);
                placeVal *= 10;
            }
        }

        public int Task164_MaximumGap_outofmemory(int[] nums)//counting not working
        {
            int max = 0;
            if (nums.Length < 2)
            {
                return max;
            }
            int K = nums.Max();
            int[] counts = new int[K + 1];
            int lastnotzeroelement = 0;
            foreach (int elem in nums)
            {
                counts[elem] += 1;

            }

            for (int i = 0; i < K + 1; i++)
            {
                if (counts[i] != 0)
                {
                    lastnotzeroelement = i;
                    break;
                }
            }

            for (int i = 0; i < K + 1; i++)
            {
                if (counts[i] != 0)
                {
                    if (Math.Abs(i - lastnotzeroelement) > max)
                    {
                        max = i - lastnotzeroelement;
                    }
                    lastnotzeroelement = i;
                }
            }

            return max;
        }

        public int Task164_MaximumGap(int[] nums)
        {
            Array.Sort(nums);
            int max = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (Math.Abs(nums[i] - nums[i - 1]) > max)
                {
                    max = nums[i] - nums[i - 1];
                }
            }
            return max;
        }
    }
}
