using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AlgProgramlama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        long index, adım;

        #region Lineer Search
        public bool LineerSearch(int[] numberArray, int wantedNumber)
        {
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] == wantedNumber)
                {
                    adım = i;
                    index = i;
                    return true;
                }
                adım = i;
            }
            return false;
        }
        #endregion

        #region Binary Search
        public bool BinarySearch(int[] numberArray, int wantedNumber)
        {
            BubbleSort(numberArray);
            int first = 0, last = numberArray.Length - 1;
            int middle = (last / 2) + 1;
            int max = 0;
            while (first < last)
            {
                index = middle;
                adım = max + 1;
                if (numberArray[middle] == wantedNumber)
                {
                    return true;
                }
                if (numberArray[middle] < wantedNumber)
                {
                    first = middle;
                    middle = (middle + last) / 2;
                }
                else
                {
                    last = middle;
                    middle = (first + middle) / 2;
                }
                max++;
                if (max == 5000)
                    break;
            }
            return false;
        }
        #endregion

        #region BubbleSort
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        #endregion

        #region Insertion Sort
        public int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                        adım++;
                    }
                }
            }
            return inputArray;
        }
        #endregion

        #region Merge Sort
        void merge(int[] arr, int l, int m, int r)
        {
            adım++;
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        void MergeSort(int[] arr, int l, int r)
        {
            adım++;
            if (l < r)
            {
                int m = (l + r) / 2;

                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);

                merge(arr, l, m, r);
            }
        }

        #endregion

        #region heapSort
        private void heapSort<T>(T[] array) where T : IComparable<T>
        {
            adım++;
            int heapSize = array.Length;

            buildMaxHeap(array);

            for (int i = heapSize - 1; i >= 1; i--)
            {
                swap(array, i, 0);
                heapSize--;
                sink(array, heapSize, 0);
            }
        }

        private void buildMaxHeap<T>(T[] array) where T : IComparable<T>
        {
            adım++;
            int heapSize = array.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                sink(array, heapSize, i);
            }
        }

        private void sink<T>(T[] array, int heapSize, int toSinkPos) where T : IComparable<T>
        {
            adım++;
            if (getLeftKidPos(toSinkPos) >= heapSize)
            {
                // No left kid => no kid at all
                return;
            }


            int largestKidPos;
            bool leftIsLargest;

            if (getRightKidPos(toSinkPos) >= heapSize || array[getRightKidPos(toSinkPos)].CompareTo(array[getLeftKidPos(toSinkPos)]) < 0)
            {
                largestKidPos = getLeftKidPos(toSinkPos);
                leftIsLargest = true;
            }
            else
            {
                largestKidPos = getRightKidPos(toSinkPos);
                leftIsLargest = false;
            }



            if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
            {
                swap(array, toSinkPos, largestKidPos);

                if (leftIsLargest)
                {
                    sink(array, heapSize, getLeftKidPos(toSinkPos));

                }
                else
                {
                    sink(array, heapSize, getRightKidPos(toSinkPos));
                }
            }

        }

        private static void swap<T>(T[] array, int pos0, int pos1)
        {
            T tmpVal = array[pos0];
            array[pos0] = array[pos1];
            array[pos1] = tmpVal;
        }

        private static int getLeftKidPos(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        private static int getRightKidPos(int parentPos)
        {
            return 2 * (parentPos + 1);
        }
        #endregion

        #region QuickSort
        private void Quick_Sort(int[] arr, int left, int right)
        {
            adım++;
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private int Partition(int[] arr, int left, int right)
        {
            adım++;
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
        #endregion

        #region RadixSort
        public int getMax(int[] arr, int n)
        {
            adım++;
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        public void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int i;
            int[] count = new int[10];

            for (i = 0; i < 10; i++)
            {
                adım++;
                count[i] = 0;
            }

            for (i = 0; i < n; i++)
            {
                adım++;
                count[(arr[i] / exp) % 10]++;
            }

            for (i = 1; i < 10; i++)
            {
                adım++;
                count[i] += count[i - 1];
            }

            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
                adım++;
            }

            for (i = 0; i < n; i++)
            {
                adım++;
                arr[i] = output[i];
            }
        }

        public void radixsort(int[] arr, int n)
        {
            adım++;
            int m = getMax(arr, n);

            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
        #endregion

        #region BucketSort
        public void SortBucket(int[] input)
        {
            int minValue = input[0];
            int maxValue = input[0];
            int k = 0;

            for (int i = input.Length - 1; i >= 1; i--)
            {
                if (input[i] > maxValue) maxValue = input[i];
                if (input[i] < minValue) minValue = input[i];
                adım++;
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = bucket.Length - 1; i >= 0; i--)
            {
                bucket[i] = new List<int>();
                adım++;
            }

            foreach (int i in input)
            {
                bucket[i - minValue].Add(i);
                adım++;
            }

            foreach (List<int> b in bucket)
            {
                if (b.Count > 0)
                {
                    foreach (int t in b)
                    {
                        input[k] = t;
                        k++;
                        adım++;
                    }
                }
            }
        }
        #endregion

        #region CountingSort
        public int[] CountingSort(int[] array)
        {
            int[] sortedArray = new int[array.Length];

            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                adım++;
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            int[] counts = new int[maxVal - minVal + 1];

            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
                adım++;
            }

            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
                adım++;
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
                adım++;
            }

            return sortedArray;
        }
        #endregion
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ara_Click(object sender, EventArgs e) // lineer search
        {
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox1.Text)];
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Dizi.Text = Sıralanmış.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            if (LineerSearch(Rnums, int.Parse(Aranacak.Text)))
            {
                stopWatch1.Stop();
                Sonuç.Text = "aranan sayı dizinin içinde bulunuyor";
                textBox3.Text = string.Join(", ", index);
                textBox4.Text = string.Join(", ", adım + 1);
                textBox5.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
            }
            else
            {
                stopWatch1.Stop();
                Sonuç.Text = "aranan sayı dizinin içinde bulunmuyor";
                textBox3.Text = "";
                textBox4.Text = string.Join(", ", adım + 1);
                textBox5.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
            }
        }

        private void button1_Click(object sender, EventArgs e) // binary search
        {
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox1.Text)];
            for (int i = 0; i < int.Parse(textBox1.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Dizi.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            if (BinarySearch(Rnums, int.Parse(Aranacak.Text)))
            {
                stopWatch1.Stop();
                Sonuç.Text = "aranan sayı dizinin içinde bulunuyor";
                textBox3.Text = string.Join(", ", index);
                textBox4.Text = string.Join(", ", adım+1);
                textBox5.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
            }
            else
            {
                stopWatch1.Stop();
                Sonuç.Text = "aranan sayı dizinin içinde bulunmuyor";
                textBox3.Text = "";
                textBox4.Text = string.Join(", ", adım+1);
                textBox5.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // insertion sort
        {
            adım = 0;
            var random = new Random();
            Stopwatch stopWatch1 = new Stopwatch();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            InsertionSort(Rnums);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", Rnums);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }

        private void button3_Click(object sender, EventArgs e) // merge sort
        {
            adım = 0;
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            MergeSort(Rnums, 0, Rnums.Length - 1);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", Rnums);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }

        private void button4_Click(object sender, EventArgs e) // heap sort
        {
            adım = 0;
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            heapSort(Rnums);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", Rnums);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }

        private void button5_Click(object sender, EventArgs e) // quick sort
        {
            adım = 0;
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            Quick_Sort(Rnums, 0, Rnums.Length - 1);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", Rnums);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }

        private void button6_Click(object sender, EventArgs e) // radix sort
        {
            adım = 0;
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            radixsort(Rnums, Rnums.Length);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", Rnums);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }

        private void button7_Click(object sender, EventArgs e) // bucket sort
        {
            adım = 0;
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            SortBucket(Rnums);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", Rnums);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }

        private void button8_Click(object sender, EventArgs e) // counting sort
        {
            adım = 0;
            Stopwatch stopWatch1 = new Stopwatch();
            var random = new Random();
            int[] Rnums = new int[int.Parse(textBox2.Text)];
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                Rnums[i] = random.Next(0, 100000);
            }
            Sıralanacak.Text = string.Join(", ", Rnums);
            stopWatch1.Start();
            var sortedArray = CountingSort(Rnums);
            stopWatch1.Stop();
            Sıralanmış.Text = string.Join(" ", sortedArray);
            textBox6.Text = string.Join(" ", adım);
            textBox7.Text = string.Join(", ", stopWatch1.ElapsedMilliseconds);
        }
    }
}
