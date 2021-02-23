using System;

class Program
{
    static void Main(string[] args)
    {
        //initialise the array to be sorted
        int[] array = { 9, 3, 0, -3 };
        //calls the function to sort the array
        Sort(array);
        //prints out the sorted array
        Console.Write("Sorted array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.ReadLine();
    }
    //function to sort the array
    static void Sort(int[] array)
    {
        bool sorted = false;
        //loops until sorted
        while (!sorted)
        {
            sorted = true;
            //cycles through the array
            for (int i = 0; i+1 < array.Length; i++)
            {
                //checks if the current cell is higher than the next cell
                if(array[i] > array[i + 1])
                {
                    //swaps the cells
                    array[i] = array[i] + array[i + 1];
                    array[i + 1] = array[i] - array[i + 1];
                    array[i] = array[i] - array[i + 1];
                    sorted = false;
                }
            }
        }
        
    }
}
