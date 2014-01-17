using System;
using System.Text;

class Polynomials
{
    static void Main()
    {
        int[] firstPolynom = InputPolynomial("first");
        int[] secondPolynom = InputPolynomial("second");
        
        Console.WriteLine(new string('-',40));
        int[] result = АddPolynoms(firstPolynom, secondPolynom);
        PrintEquation(firstPolynom, secondPolynom, "+", result);

        Console.WriteLine(new string('-',40));
        result = SubstractPolynoms(firstPolynom, secondPolynom);
        PrintEquation(firstPolynom, secondPolynom, "-", result);

        Console.WriteLine(new string('-',40));
        result = MultiplyPolynoms(firstPolynom, secondPolynom);
        PrintEquation(firstPolynom, secondPolynom, "*", result);
    }

    private static void PrintEquation(int[] polynomial, int[] secPolynomial, string str, int[] result)
    {
        PrintPolynom(polynomial);
        Console.WriteLine(str);
        PrintPolynom(secPolynomial);
        Console.WriteLine("=");
        PrintPolynom(result);
    }

    private static void PrintPolynom(int[] result)
    {
        StringBuilder sb = new StringBuilder();
        for ( int curDegree = result.Length - 1; curDegree >= 0; curDegree-- )
        {
            if ( result[curDegree] > 0 && sb.Length > 0 )
                sb.Append('+');

            if ( result[curDegree] == 0 )
                continue;

            if ( curDegree == 0 )
            {
                sb.Append(result[curDegree]);
                continue;
            }
            sb.Append(result[curDegree] == 1 ? "" : result[curDegree].ToString());
            sb.Append(curDegree == 1 ? "x" : "x^" + curDegree);
        }
        if ( sb.Length == 0 )
            sb.Append('0');
        Console.WriteLine(sb);
    }

    private static int[] АddPolynoms(int[] polynomial, int[] secPolynomial)
    {
        int max = Math.Max(polynomial.Length, secPolynomial.Length);
        int[] result = new int[max];
        for ( int curDegree = 0; curDegree < max; curDegree++ )
        {
            int first = curDegree < polynomial.Length ? polynomial[curDegree] : 0;
            int second = curDegree < secPolynomial.Length ? secPolynomial[curDegree] : 0;
            result[curDegree] = first + second;
        }
        return result;
    }

    private static int[] MultiplyPolynoms(int[] polynomial, int[] secPolynomial)
    {
        int[] result = new int[polynomial.Length + secPolynomial.Length - 1];

        for ( int firstDegree = 0; firstDegree < polynomial.Length; firstDegree++ )
        {
            int first = firstDegree < polynomial.Length ? polynomial[firstDegree] : 0;

            for ( int secDegree = 0; secDegree < secPolynomial.Length; secDegree++ )
            {
                int second = secDegree < secPolynomial.Length ? secPolynomial[secDegree] : 0;
                result[firstDegree + secDegree] += first * second;
            }
        }
        return result;
    }

    private static int[] SubstractPolynoms(int[] polynomial, int[] secPolynomial)
    {
        int max = Math.Max(polynomial.Length, secPolynomial.Length);
        int[] result = new int[max];

        for ( int curDegree = 0; curDegree < max; curDegree++ )
        {
            int first = curDegree < polynomial.Length ? polynomial[curDegree] : 0;
            int second = curDegree < secPolynomial.Length ? secPolynomial[curDegree] : 0;
            result[curDegree] = first - second;
        }
        return result;
    }

    private static int[] InputPolynomial(string str)
    {
        int degree = InputValue("Enter degree of " + str + " polynom:");

        int[] polynomial = new int[degree + 1];
        for ( int i = degree; i >= 0; i-- )
        {
            polynomial[i] = InputValue(String.Format("Enter coefficient at x^{0} degree: ", i));
        }
        return polynomial;
    }

    private static int InputValue(string str)
    {
        int degree;
        do
        {
            Console.Write(str);
        }
        while ( !int.TryParse(Console.ReadLine(), out degree) );
        return degree;
    }
}