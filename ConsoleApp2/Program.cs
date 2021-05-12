using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Author: David Piatt
 * Date: 5/11/21
 * 
 * This is my solution to our google hangouts coding challenge.
 * 
 * Prompt:
 * Given numRows, generate the first numRows of Pascal’s triangle.
 * Pascal’s triangle : To generate A[C] in row R, sum up A’[C] and A’[C-1] from previous row R - 1.
 * Given numRows = 5,
 * Return
[
     [1],
     [1,1],
     [1,2,1],
     [1,3,3,1],
     [1,4,6,4,1]
]
*
* Note:
* The prompt suggests an array of arrays and that is how I conceptualized this problem.
* I may have made this more complicated than it needs to be, but it does work.
* I wanted to demonstrate that I can get my interpretation of the prompt to work successfully.
* I realize that there are several ways to solve this problem, but this is
* what makes most sense to me, and I'm proud of it. 
* Thank you.
 */

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask user to input number of rows
            Console.WriteLine("Please enter the number of rows to generate pascal's triangle: ");
            //parse int rows from input
            int rows = Convert.ToInt32(Console.ReadLine());

            //print out a line so it's easier to read
            Console.WriteLine();
            
            //Call pascal function
            pascal(rows);
            Console.ReadLine();
        }
        
        //function pascal that takes in a number of rows
        //and prints out pascal's triangle
        public static void pascal(int numRows)
        {
            List<List<int>> pascal = new List<List<int>>();

            //add case for row 1
            pascal.Add(new List<int>() { 1 });


            //iterate over each row, we start at one because row zero is already initialized
            for(int i=1; i<numRows; i++)
            {
                //This is a temporary list of type integer. We will add to it to build out each row
                List<int> tmp = new List<int>();

                //iterate over each column
                for(int j=0; j<i+1; j++)
                {
                    int cprime;
                    int cprimeminus1;

                    //try to find c prime minus one. If it doesn't exist we leave it as zero. 
                    //we're using a try catch block to keep from throwing an exception
                    try
                    {
                        cprimeminus1 = pascal[i - 1][j - 1];
                    }
                    catch
                    {
                        cprimeminus1 = 0;
                    }

                    //try to find c prime
                    try
                    {
                        cprime = pascal[i - 1][j];
                    }
                    catch
                    {
                        cprime = 0;
                    }

                    //This was for debugging
                    //Console.WriteLine("row: " + i + " col: " + j + " cprime: " + cprime + " cprimeminus1: " + cprimeminus1 + " addition: " + (cprimeminus1+cprime));
                    
                    tmp.Add(cprimeminus1 + cprime);
                }
                //We are adding a copy of tmp. 
                //We want a new list because we will be clearing tmp
                //and don't want to clear the values added to pascal.
                //Therefore, we want what we add to pascal to have a new reference so it isn't written over.
                
                pascal.Add(new List<int>(tmp));
                
                tmp.Clear();
            }
            
            //now print it out
            for (int i = 0; i < pascal.Count; i++)
            {
                for (int j = 0; j < pascal[i].Count; j++)
                {
                    Console.Write(pascal[i][j]);
                    Console.Write(" ");
                }
                //write out a new row to begin on
                Console.WriteLine();
            }
            
        }
    }
}

