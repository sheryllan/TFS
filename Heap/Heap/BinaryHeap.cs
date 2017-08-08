using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class BinaryHeap
    {
        public int[] MaxHeapify(int[] input)
        {
            int[] heap = new int[input.Length];
            Array.Copy(input, heap, input.Length);
            for (int i = 1; i < heap.Length; i++)
            {
                MaxSiftUp(heap, i);
            }
            return heap;
        }

        public int[] MinHeapify(int[] input)
        {
            int[] heap = new int[input.Length];
            Array.Copy(input, heap, input.Length);
            for (int i = 1; i < heap.Length; i++)
            {
                MinSiftUp(heap, i);
            }
            return heap;
        }

        public int[] HeapSort(int[] input)
        {
            int[] sorted = new int[input.Length];
            input = MinHeapify(input);
            for (int i = 0; i < sorted.Length; i++)
            {
                int j = sorted.Length - 1 - i;
                sorted[i] = input[0];
                Swap(ref input[0], ref input[j]);
                MinSiftDown(input, 0, j);
            }
            return sorted;
        }

        private void MinSiftDown(int[] heap, int i, int end)
        {
            int j = i;

            while (heap[i] >= heap[j])
            {
                Swap(ref heap[i], ref heap[j]);
                i = j;
                int left = 2 * (i + 1) - 1;
                int right = 2 * (i + 1);

                if (left >= end)
                    return;
                if (right >= end)
                    j = left;
                else
                {
                    j = heap[left] < heap[right] ? left : right;
                }

            }
        }


        private void MaxSiftUp(int[] heap, int i)
        {
            int j = i;
            while (heap[j] > heap[(j - 1) / 2])
            {
                Swap(ref heap[j], ref heap[(j - 1) / 2]);
                j = (j - 1) / 2;
            }
           
        }

        private void MinSiftUp(int[] heap, int i)
        {
            int j = i;
            while (heap[j] < heap[(j - 1) / 2])
            {
                Swap(ref heap[j], ref heap[(j - 1) / 2]);
                j = (j - 1) / 2;
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
