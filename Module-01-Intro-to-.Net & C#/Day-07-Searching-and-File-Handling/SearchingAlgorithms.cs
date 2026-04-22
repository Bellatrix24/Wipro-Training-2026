using System;

// This script demonstrates the two most common searching algorithms: Linear and Binary Search.
class SearchingAlgorithms
{
    static void Main()
    {
        Console.WriteLine("--- Searching Algorithms Demo ---");

        // 1. Get Array Size from User
        Console.Write("Enter the number of elements in the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        // 2. Input Elements
        Console.WriteLine($"Enter {n} elements (Note: For Binary Search, please enter them in sorted order):");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        // 3. Target to search
        Console.Write("\nEnter the number to search: ");
        int target = int.Parse(Console.ReadLine());

        // --- Linear Search ---
        int linearResult = LinearSearch(arr, target);
        if (linearResult != -1)
            Console.WriteLine($"[Linear Search] Element found at index: {linearResult}");
        else
            Console.WriteLine("[Linear Search] Element not found.");

        // --- Binary Search ---
        int binaryResult = BinarySearch(arr, target);
        if (binaryResult != -1)
            Console.WriteLine($"[Binary Search] Element found at index: {binaryResult}");
        else
            Console.WriteLine("[Binary Search] Element not found.");
    }

    // Linear Search: Checks every element one by one (O(n))
    static int LinearSearch(int[] array, int key)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == key)
            {
                return i; // Return index if found
            }
        }
        return -1; // Not found
    }

    // Binary Search: Repeatedly divides the search interval in half (O(log n))
    static int BinarySearch(int[] array, int key)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            // overflow fix: using (left + right) / 2 can cause overflow if sum is too large
            int mid = left + (right - left) / 2;

            if (array[mid] == key)
                return mid; // Found

            if (array[mid] < key)
                left = mid + 1; // Look in the right half
            else
                right = mid - 1; // Look in the left half
        }
        return -1; // Not found
    }
}
