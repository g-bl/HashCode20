using System;

namespace HashCode20
{
    class Program
    {
        static void Main(string[] args)
        {
            NaiveSolver naiveSolverA = new NaiveSolver("a_example.txt", "a_example.out", ' ');
            NaiveSolver naiveSolverB = new NaiveSolver("b_read_on.txt", "b_read_on.out", ' ');
            NaiveSolver naiveSolverC = new NaiveSolver("c_incunabula.txt", "c_incunabula.out", ' ');
            NaiveSolver naiveSolverD = new NaiveSolver("d_tough_choices.txt", "d_tough_choices.out", ' ');
            NaiveSolver naiveSolverE = new NaiveSolver("e_so_many_books.txt", "e_so_many_books.out", ' ');
            NaiveSolver naiveSolverF = new NaiveSolver("f_libraries_of_the_world.txt", "f_libraries_of_the_world.out", ' ');

            Console.ReadKey();
        }
    }
}
