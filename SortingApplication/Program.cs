/*
 * Name: Alyssa Bell
 * Date: 4/01/17
 * Filename: SortingApplication
 * 
 * Purpose/Description: This console application reads in input, stores it into an array, 
 * and then uses 2 different methods to produce the same results - which is to sort the input values from high to low. 
 * The sorted values are then outputted to a file "output.txt"
 * 
 * Error Checking: This program checks for correct input file name. 
 * It also checks that only a valid menu option is selected. And the program validates the datatype that is being
 * inputted and only allows integer values to be processed.
 * 
 * Assumptions: The input file only contains integer values
 * 
 * Summary of Methds:
 * BubbleSort() - this method scans through the input array from L -> R, reading 2 positions at a time, 
 *      and puts the larger value in the first position
 * CyclicalSort() - this method scans through the input array from L -> R, reading 2 positions at a time, 
 *      and puts the larger value in the first position, but then repeats the same process from R -> L 
 *      (the largest value is now at the end of the array), and then the process is repeated again from L ->R
 *      to place the largest value at the beginning of the array and the smallest at the end if it.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortingApplication
{
    class Program
    {
        const int MAX_VALUES = 0;

        static void Main(string[] args)
        {
            string filename = "";

            StreamReader din;
            StreamWriter dout;

            Console.WriteLine("Please enter the name of the file that you would like to have sorted.");
            filename = Console.ReadLine();


            while (!File.Exists(filename))
            {
                Console.WriteLine("Please enter a valid file name.");
                filename = Console.ReadLine();

            }

            Console.WriteLine("\nThank you! Your input file was found.");
           

            // create new streamreader for the input file
            din = new StreamReader(filename);

            // store priming read
            string primingRead = din.ReadLine();

            //store the primingRead into MAX_VALUES int
            int MAX_VALUES = Convert.ToInt32(primingRead);

            // string used to read each line within the file
            string readSingleLine = din.ReadLine();

            // if line read is a float, store here
            float floatLineRead;
            //temporarily stores a float after parsing
            float tempFloat = 0f;

            int[] SortingArray = new int[MAX_VALUES];

            //temp store
            int tempInt;

            // once inside loop, store the line read at the end of iteration into here 
            string tempLineRead = "";
            int i = 0;

            while (readSingleLine != null)
            {
                tempLineRead = readSingleLine;
                // if readSingleLine is an int, it's stored into intLineRead
                bool ifInt = Int32.TryParse(tempLineRead, out tempInt);
                // if readSingleLine is a float, it's stored into floatLineRead
                bool ifFloat = float.TryParse(tempLineRead, out tempFloat);
                // if readSingleLine is a string, store in here
                string stringRead = "";



                if (ifInt)
                {

                    SortingArray[i] = tempInt;
                    //Console.WriteLine(tempInt);
                    //Console.WriteLine("{0} is stored into the array", SortingArray[i]);
                    i++;

                }


                else if (ifFloat)
                {
                    floatLineRead = tempFloat;
                    Console.WriteLine("Incorrect datatype. {0} is a float", floatLineRead);
                }

                else if (!ifInt && !ifFloat)
                {
                    stringRead = tempLineRead;
                   Console.WriteLine("Incorrect datatype. {0} is a string", stringRead);
                }

                // read again for another line in file 
                readSingleLine = din.ReadLine();

            } // ************ End of file reading ***********




            //  * * * * * * * * * * * * * * CALL TO SORTING METHODS HERE * * * * * * * * * * * * * * * *
            dout = new StreamWriter("output.txt");

            char sortSelection;

            Console.WriteLine("\nPlease choose one of the following options:");
            Console.WriteLine("A - Sort input with the Bubble Sort Method");
            Console.WriteLine("B - Sort input with the Cyclical Sort Method");
            sortSelection = Convert.ToChar(Console.ReadLine());

            while (sortSelection != 'A' && sortSelection != 'B' && sortSelection != 'a' && sortSelection != 'b')
            {
               
                Console.WriteLine("Please enter only A or B");
                sortSelection = Convert.ToChar(Console.ReadLine());
            }

            if (sortSelection == 'A' || sortSelection == 'B' || sortSelection == 'a' || sortSelection == 'b')
            {
                switch (sortSelection)
                {
                    case 'a':
                        BubbleSort(SortingArray);
                        for (int m = 0; m < SortingArray.Length; m++)
                        {
                            dout.WriteLine(SortingArray[m]);
                        }
                        Console.WriteLine("You chose the Bubble Sort Method.\n");
                        break;
                    case 'A':
                        BubbleSort(SortingArray);
                        for (int m = 0; m < SortingArray.Length; m++)
                        {
                            dout.WriteLine(SortingArray[m]);
                        }
                        Console.WriteLine("You chose the Bubble Sort Method.\n");
                        break;

                    case 'b':
                        CyclicalSort(SortingArray);
                        for (int n = 0; n < SortingArray.Length; n++)
                        {
                            dout.WriteLine(SortingArray[n]);
                        }
                        Console.WriteLine("You chose the Cyclical Sort Method.\n");
                        break;
                
                    case 'B':
                        CyclicalSort(SortingArray);
                        for (int n = 0; n < SortingArray.Length; n++)
                        {
                            dout.WriteLine(SortingArray[n]);
                        }
                        Console.WriteLine("You chose the Cyclical Sort Method.\n");
                        break;
                }
            }  

                dout.Close();

                Console.WriteLine("Your input file has been processed. Please open output.txt to view your results.");

            //  * * * * * * * * * * * * * * END CALL TO SORTING METHODS * * * * * * * * * * * * * * * *
        } // end of Main



        /* pre: the SortingArray must have values in it
        * post: The SortingArray is ordered from largest value to smallest
        * Purpose: to sort through each element in the array and order it from largest to smallest value
        */
        public static int[] BubbleSort(/* IN & OUT */int[] array)
        {
            

            int tempVal = 0;

            for(int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        tempVal = array[i];
                        array[i] = array[j];
                        array[j] = tempVal;
                    }
                }
            }

            return array;
            
        }


        /* pre: the SortingArray must have values in it
        * post: The SortingArray is ordered from largest value to smallest
        * Purpose: to sort through each element in the array and order it from largest to smallest value
        */
        public static int[] CyclicalSort(/* IN & OUT */int[] array)
        {
            int tempVal = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        tempVal = array[i];
                        array[i] = array[j];
                        array[j] = tempVal;
                    }
                }
            }

            for (int k = array.Length - 1; k >=0; k--)
            {
                for(int l = k-1; l >=0; l--)
                {
                    if(array[l] > array[k])
                    {
                        tempVal = array[k];
                        array[k] = array[l];
                        array[l] = tempVal;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        tempVal = array[i];
                        array[i] = array[j];
                        array[j] = tempVal;
                    }
                }
            }

                return array;
        }


    }
}
