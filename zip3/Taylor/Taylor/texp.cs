using System;
using System.Globalization;

namespace Taylor
{
    class texp
    {
        NumberFormatInfo setPrecision = new CultureInfo("cs-CZ", false).NumberFormat; // nastavení přesnosti (default 2)

        public string te(double x)
        {
            // Holds and returns final answer
            double answer = 0;

            // Holds previous answer and is used to stop Taylor Expansion
            double oldanswer = 0;

            // Summation index variable
            double k = 0;


            // Refine the solution by adding more terms to the Taylor Expansion.
            // Stop when the answer doesn't change.
            while (true)
            {

                answer += Math.Pow(x, k) / Factorial(k);

                if (answer == oldanswer)
                {
                    break;
                }
                else
                {
                    oldanswer = answer;
                    k++;
                }

            }
            setPrecision.NumberDecimalDigits = 2;

            double funct = Math.Exp(x);
            // Write directly to the console here to avoid global variable
            Console.WriteLine("Answer calculated in " + k.ToString() + " iterations.");

            Console.WriteLine("EXP FUNC: " + funct.ToString("N", setPrecision));

            var solution = answer.ToString("N", setPrecision);

            // Return solution to caller
            return solution;

        }

        public string te(double x, int a)
        {
            // Holds and returns final answer
            double answer = 0;

            // Holds previous answer and is used to stop Taylor Expansion
            double oldanswer = 0;

            // Summation index variable
            double k = 0;


            // Refine the solution by adding more terms to the Taylor Expansion.
            // Stop when the answer doesn't change.
            while (true)
            {

                answer += Math.Pow(x, k) / Factorial(k);

                if (answer == oldanswer)
                {
                    break;
                }
                else
                {
                    oldanswer = answer;
                    k++;
                }

            }
            setPrecision.NumberDecimalDigits = a;

            double funct = Math.Exp(x);
            // Write directly to the console here to avoid global variable
            Console.WriteLine("Answer calculated in " + k.ToString() + " iterations.");

            Console.WriteLine("EXP FUNC: " + funct.ToString("N", setPrecision));

            var solution = answer.ToString("N", setPrecision);

            // Return solution to caller
            return solution;

        }

        static double Factorial(double x)
        {

            double answer = 1;
            double counter = 1;

            while (counter <= x)
            {
                answer = answer * counter;
                counter++;

            }

            return answer;
        }

    }
}
