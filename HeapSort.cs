using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class HeapSort
    {
        public static int[] Heapify(int[] nums, int n, int i)
        {
            //смена если правый потомок меньше и обновление его потомков
            if (2 * i + 2 < n)
                if (nums[2 * i + 2] > nums[i])
                {
                    (nums[2 * i + 2], nums[i]) = (nums[i], nums[2 * i + 2]);
                    Heapify(nums, n, 2 * i + 2);
                }
            //смена если левый потомок меньше и обновление его потомков
            if (2 * i + 1 < n)
                if (nums[2 * i + 1] > nums[i])
                {
                    (nums[2 * i + 1], nums[i]) = (nums[i], nums[2 * i + 1]);
                    Heapify(nums, n, 2 * i + 1);
                }
            return nums;
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
    }
}
