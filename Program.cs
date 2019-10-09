using System;
using System.Drawing;
using System.IO;
using System.Collections;

namespace LexitSort
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                int numCase = 0;
                //Console.WriteLine("Enter Number of Total Cases");
                //get number of cases from user
                numCase = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < numCase; i++)
                {
                    int[] numPerCase = new int[5000];
                    string[] caseStrings = new string[5000];
                    int counter = 0;
                    int temp3 = (i + 1);
                    //Console.WriteLine("Enter Number of strings for case: " + temp3);
                    //get number of strings for current case
                    numPerCase[i] = Convert.ToInt32(Console.ReadLine());
                    //read in the amount of strings per 
                    for (int x = 0; x < numPerCase[i]; x++)
                    {
                        int temp = (x + 1);
                        int temp2 = (i + 1);
                        //Console.WriteLine("Enter string number: " + temp + " for test case " + temp2);
                        //get strings for each case
                        caseStrings[counter] = Console.ReadLine();
                        counter++;
                    }
                    //call mergeStart to sort each case
                    string[] mergedArray = mergeStart(caseStrings, 0, caseStrings.Length - 1);
                    //print sorted array
                    for (int y = 0; y < mergedArray.Length; y++)
                    {
                        if (mergedArray[y] != "" && mergedArray[y] != null)
                            Console.WriteLine(mergedArray[y]);
                    }
                }
                return;
            }
            catch(Exception)
            {
                return;
            }
            }
        public static string[] mergeStart(string[] array, int start, int end)
        {
            if (start < end)
            {
                //create left, right, and merged array
                int mid = (end + start) / 2;
                string[] leftArray = mergeStart(array, start, mid);
                string[] rightArray = mergeStart(array, mid + 1, end);
                string[] mergedArray = combineArray(leftArray, rightArray);
                return mergedArray;
            }
            return new string[] { array[start] };
        }
        public static string[] combineArray(string[] leftArray, string[] rightArray)
        {
            //create new mergedArray, with total legth of the left and right array
            string[] mergedArray = new string[leftArray.Length + rightArray.Length];

            //indexed for use with left, right, and merged arrays
            int left = 0;
            int right = 0;
            int merged = 0;
            //go through both arrays and store lowest character in merged array
            while (left < leftArray.Length && right < rightArray.Length)
            {
                if (string.CompareOrdinal(leftArray[left], rightArray[right]) < 0)
                {
                    mergedArray[merged++] = leftArray[left++];
                }
                else
                {
                    mergedArray[merged++] = rightArray[right++];
                }
            }
            //if any lefover, merge to merged array
            while (left < leftArray.Length)
            {
                mergedArray[merged++] = leftArray[left++];
            }

            while (right < rightArray.Length)
            {
                mergedArray[merged++] = rightArray[right++];
            }
            return mergedArray;
        }
    }
}
