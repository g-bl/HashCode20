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
    public class Book
    {
        public int Id;
        public int Score;
    }

    public class Library
    {
        // Input-values
        public int Id;
        public int N;
        public int T;
        public int M;
        public List<int> BookIndexes;

        // Solver-values
        public List<int> SentBooksIndexes;
    }

    // SOLVER

    class NaiveSolver
    {
        public NaiveSolver(string inputFileName, string outputFileName, char delimiter)
        {
            // Model initializations

            int B = 0; // nb of different books
            int L = 0; // nb of libraries
            int D = 0; // nb of days

            List<Book> books = new List<Book>();
            List<Library> libraries = new List<Library>();

            /**************************************************************************************
             *  Input loading
             **************************************************************************************/

            Console.WriteLine("Input loading... " + inputFileName);

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string[] lines = File.ReadAllLines(inputFilePath);

            // Metadata parsing
            string[] line0 = lines[0].Split(delimiter);
            B = int.Parse(line0[0]);
            L = int.Parse(line0[1]);
            D = int.Parse(line0[2]);

            // Books parsing
            string[] line1 = lines[1].Split(delimiter);
            for (int i = 0; i < B; i++)
            {
                books.Add(new Book()
                {
                    Id = i,
                    Score = int.Parse(line1[i])
                });
            }

            // Libraries parsing
            for(int i = 2; i < (2*L + 2); i+=2)
            {
                string[] lineA = lines[i].Split(delimiter);
                string[] lineB = lines[i+1].Split(delimiter);

                int N = int.Parse(lineA[0]);
                int T = int.Parse(lineA[1]);
                int M = int.Parse(lineA[2]);

                List<int> bIndexes = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    bIndexes.Add(int.Parse(lineB[j]));
                }

                libraries.Add(new Library()
                {
                    Id = (i-2)/2,
                    N = N,
                    T = T,
                    M = M,
                    BookIndexes = bIndexes
                });
            }

            /**************************************************************************************
             *  Solver
             **************************************************************************************/

            libraries[1].SentBooksIndexes = new List<int>() { 5, 2, 3 };
            libraries[0].SentBooksIndexes = new List<int>() { 0, 1, 2, 3, 4 };

            List<Library> signedUpLibraries = new List<Library>()
            {
                libraries[1],
                libraries[0]
            };

            /**************************************************************************************
             *  Output
             **************************************************************************************/

            Console.WriteLine("Output to file...");

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), outputFileName)))
            {
                outputFile.WriteLine(signedUpLibraries.Count);

                foreach (Library l in signedUpLibraries)
                {
                    outputFile.WriteLine(l.Id + " " + l.SentBooksIndexes.Count);
                    outputFile.WriteLine(String.Join(' ', l.SentBooksIndexes));
                }
            }

            Console.WriteLine("Done...");
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), outputFileName));
        }
    }
}