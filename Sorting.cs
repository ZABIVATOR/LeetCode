using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int n = arr.Length;
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
    }
}
