using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode20
{
    // MODEL
    public class RENAME_ME_CLASS
    {
        public string VALUE_A;
        public bool VALUE_B;

        public override string ToString()
        {
            return VALUE_A;
        }
    }

    // SOLVER

    class NaiveSolver
    {
        public NaiveSolver(string inputFileName, string outputFileName, char delimiter)
        {
            // Model initializations

            List<RENAME_ME_CLASS> theList = new List<RENAME_ME_CLASS>();

            /**************************************************************************************
             *  Input loading
             **************************************************************************************/

            Console.WriteLine("Input loading... " + inputFileName);

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);

            int RENAME_ME_COUNT = int.Parse(lines[0]);

            //Content
            for (int i = 0; i < RENAME_ME_COUNT; i++)
            {
                string[] splittedLine = lines[i + 1].Split(delimiter);

                RENAME_ME_CLASS theObject = new RENAME_ME_CLASS();

                theObject.VALUE_A = i.ToString();
                theObject.VALUE_B = splittedLine[0] == "Y"; // Change this!

                theList.Add(theObject);
            }

            /**************************************************************************************
             *  Solver
             **************************************************************************************/

            Console.WriteLine("Solving...");

            List<RENAME_ME_CLASS> newList = theList;

            /**************************************************************************************
             *  Output
             **************************************************************************************/

            Console.WriteLine("Output to file...");

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), outputFileName)))
            {
                outputFile.WriteLine(newList.Count);

                foreach (RENAME_ME_CLASS listElement in newList)
                {
                    outputFile.WriteLine(listElement.ToString());
                }
            }

            Console.WriteLine("Done. :" + newList.Count);
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), outputFileName));
        }
    }
}