using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionCount
{
    public class Solution
    {
        public int BottomUpInversions(int[] A)
        {
            int count = 0;
            int partitions = A.Length;

            // initialize array B
            int[][] B = A.Select(x => new[] {x}).ToArray();
            while (partitions > 1)
            {
                int newPartitions = (int) Math.Ceiling((double)partitions / 2);
                int[][] temp = new int[newPartitions][];
                for (int i = 0; i < newPartitions; i++)
                {
                    var a = B[2 * i];
                    var b = 2 * i + 1 >= partitions ? null : B[2 * i + 1];
                    temp[i] = MergeTwoArraysAndCount(a, b, ref count);
                }
                partitions = newPartitions;
                B = temp;

            }
            return count;
        }

        public int TopDownInversions(int[] A, int start, int end)
        {
            if (start == end)
                return 0;

            int count = 0;
            int mid = (start + end) / 2;

            count += TopDownInversions(A, start, mid) + TopDownInversions(A, mid + 1, end);
            count += MergeTwoArraysAndCount(ref A, start, mid, end);

            return count;
        }

        public int[] MergeTwoArrays(int[] a, int[] b)
        {
            int len = a.Length + b.Length;
            int[] merged = new int[len];

            int i = 0;
            int j = 0;
            int k = 0;
            while (k < len)
            {
                merged[k++] = a[i] > b[j] ? b[j++] : a[i++];
                if(i >= a.Length)
                    while (j < b.Length)
                    {
                        merged[k++] = b[j++];
                    }
                if(j >= b.Length)
                    while (i < a.Length)
                    {
                        merged[k++] = a[i++];
                    }
            }

            return merged;
        }

        public int[] MergeTwoArraysAndCount(int[] a, int[] b, ref int count)
        {
            if (a == null) return b;
            if (b == null) return a;
            
            int len = a.Length + b.Length;
            int[] merged = new int[len];

            int i = 0;
            int j = 0;
            int k = 0;
            
            while (k < len)
            {
                if (a[i] > b[j])
                {
                    merged[k++] = b[j++];
                    count += a.Length - i;
                }
                else
                {
                    merged[k++] = a[i++];
                }
                if (i >= a.Length)
                    while (j < b.Length)
                    {
                        merged[k++] = b[j++];
                    }
                if (j >= b.Length)
                    while (i < a.Length)
                    {
                        merged[k++] = a[i++];
                    }
            }

            return merged;
        }

        public int MergeTwoArraysAndCount(ref int[] a, int start, int mid, int end)
        {
            int count = 0;
            int i = start;
            int j = mid + 1;
            int k = 0;
            int[] b = new int[end - start + 1];

            while (k < b.Length)
            {
                if (a[i] > a[j])
                {
                    b[k++] = a[j++];
                    count += mid - i + 1;
                }
                else
                {
                    b[k++] = a[i++];
                }

                if(i > mid)
                    while (j <= end)
                    {
                        b[k++] = a[j++];
                    }
                if(j > end)
                    while (i <= mid)
                    {
                        b[k++] = a[i++];
                    }
            }

            Array.Copy(b, 0, a, start, b.Length);
            return count;
        }
    }
}
