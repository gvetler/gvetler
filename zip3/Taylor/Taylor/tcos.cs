using System;
using System.Globalization;

namespace Taylor
{
    class tcos
    {
        NumberFormatInfo setPrecision = new CultureInfo("cs-CZ", false).NumberFormat;

        public string tc(double x)
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

                answer += (Math.Pow(-1, k) / Factorial(2 * k)) * Math.Pow(x, 2 * k);

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

            double funct = Math.Cos(x);
            // Write directly to the console here to avoid global variable
            Console.WriteLine("Answer calculated in " + k.ToString() + " iterations.");

            Console.WriteLine("COS FUNC: " + funct.ToString("N", setPrecision));

            var solution = answer.ToString("N", setPrecision);

            // Return solution to caller
            return solution;

        }
        public string tc(double x, int a)
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

                answer += (Math.Pow(-1, k) / Factorial(2 * k)) * Math.Pow(x, 2 * k);

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

            double funct = Math.Cos(x);
            // Write directly to the console here to avoid global variable
            Console.WriteLine("Answer calculated in " + k.ToString() + " iterations.");

            Console.WriteLine("COS FUNC: " + funct.ToString("N", setPrecision));

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
