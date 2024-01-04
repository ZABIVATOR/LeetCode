using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class HeapSort
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
    }
}
