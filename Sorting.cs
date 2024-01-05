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
        public static int[] HeapSort(int[] arr)
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


    }
}
