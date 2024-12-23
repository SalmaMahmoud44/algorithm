using System;
//Part (a): Algorithms for Heap-Sort in C#

using System;

class HeapSort
{
    // Heapify function to maintain heap property
    public static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // Left child index
        int right = 2 * i + 2; // Right child index

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != i)
        {
            // Swap
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected subtree
            Heapify(arr, n, largest);
        }
    }

    // Build a max heap
    public static void BuildHeap(int[] arr, int n)
    {
        // Start from the last non-leaf node and heapify each node
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
    }

    // Perform heap sort
    public static void HeapSortArray(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Build a max heap
        BuildHeap(arr, n);

        // Step 2: Extract elements from heap one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Call heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    // Main method to test the algorithm
    public static void Main(string[] args)
    {
        int[] array = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Original array: " + string.Join(", ", array));

        // Sort the array
        HeapSortArray(array);

        Console.WriteLine("Sorted array: " + string.Join(", ", array));
    }
}
