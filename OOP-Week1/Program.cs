using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Make a list of random numbers
            int[] randomNumbers = GenerateRandomInteger(100, 1, 1000);

            // Calculate the sum of the random numbers and print it
            int sum = ComputeSum(randomNumbers);
            Console.WriteLine($"Sum of all numbers: {sum}");

            // Get and diplay histogram
            int[] histogram = ComputeHistogram(randomNumbers);
            DispayHistogram(histogram);

            // Make a sorted list and display it
            int[] sorted_list = SimpleSort(randomNumbers);
            DisplaySortedList(sorted_list);


            // Pause the console so the user can see it
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        
        static void DisplaySortedList(int[] sorted_list)
        {
            foreach (int number in sorted_list)
            {
                Console.WriteLine(number);
            }
        }

        static int[] SimpleSort(int[] numbers)
        {
            int[] sorted_list = new int[numbers.Length];
            sorted_list[0] = numbers[0]; // Initialize the first element

            // Outer loop: iterate through each element
            for (int i = 1; i < numbers.Length; i++)
            {
                int key = numbers[i]; // Current element to be inserted
                int j;

                // Inner loop: shift elements greater than key to the right
                for (j = i - 1; j >= 0 && sorted_list[j] > key; j--)
                {
                    sorted_list[j + 1] = sorted_list[j]; // Shift element to the right
                }

                sorted_list[j + 1] = key; // Insert the key in its correct position
            }

            return sorted_list; // Return the sorted array
        }


        static void DispayHistogram(int[] histogram)
        {
            Console.WriteLine("Histogram (Class : Frequency):");
            int binStart = 1;
            int binEnd = 100;

            for (int i = 0; i < histogram.Length; i++)
            {   
                 Console.WriteLine($"{binStart+(100*i)} to {binEnd+(100*i)}: {histogram[i]}");
            }
        }


        static int[] ComputeHistogram(int[] numbers)
        {
            // Define the number of bins (10 bins in this case)
            int binCount = 10;
            int[] histogram = new int[binCount];

            // Define the range of numbers (1 to 1000)
            int minNumber = 1;
            int maxNumber = 1000;

            // Calculate the size of each bin
            int binSize = (maxNumber - minNumber + 1) / binCount;

            // Iterate through the numbers and count frequencies for each bin
            foreach (int number in numbers)
            {
                // Determine which bin the number belongs to
                int binIndex = (number - minNumber) / binSize;

                // Ensure the binIndex is within the valid range (0 to binCount - 1)
                if (binIndex >= binCount)
                {
                    binIndex = binCount - 1; // Place the number in the last bin if it's out of range
                }

                // Increment the count for the corresponding bin
                histogram[binIndex]++;
            }

            return histogram;
        }


        static int ComputeSum(int[] randomNumnbers)
        {
            int sum = 0;
            for (int i = 0; i < randomNumnbers.Length; i++)
            {
                sum += randomNumnbers[i];
            }
            return sum;
        }

        static int[] GenerateRandomInteger(int count, int min, int max)
        {
            Random random = new Random();
            // Array to store random integers
            int[] numbers = new int[count];
            for (int i = 0; i < numbers.Length; i++)
            {
                // Random number between 1 and 1000
                numbers[i] = random.Next(min, max + 1);
                Console.WriteLine($"Number {i + 1}: {numbers[i]}");
            }
            return numbers;
        }
    }
}