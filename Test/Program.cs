using System.Text.RegularExpressions;

namespace Test;
class Program
{
    static void Main(string[] args)
    {
        revert();
        repeat();
        hamming();
        wordCount();
        countNumbers();
        basicQueriesLINQ();
        Console.WriteLine(codere(6, 11, 2));
        Bubble();
    }    

    //1.- Invertir Cadena
    static void revert()
    {
        string text = "pato";
        string textResult = "";

        char[] chars = text.ToCharArray();
        Array.Reverse(chars);

        string arrayResult = new string(chars);

        for(int i = text.Length - 1; i >= 0; i--)
        {
            textResult += text[i];
        }

        Console.WriteLine(textResult);
        Console.WriteLine(arrayResult);

    }

    //2.- Cuantas veces se repite un caracter
    static void repeat()
    {
        string text = "ksdjhfo348899eru89oiedjh9wejdkjfwe0009i";
        char character = 'e';
        int cnt = 0;

        //foreach(var c in text)
        //{
        //    if (c == character)
        //        cnt++;
        //}

        cnt = text.Where(c => c == character).Count();

        Console.WriteLine($"El caracter {character} se repite {cnt} veces.");
    }

    //3.- DIstancia de Hamming
    static void hamming()
    {
        string text1 = "patitosw";
        string text2 = "paratosa";

        int distance = 0;

        if (text1.Length != text2.Length)
            throw new Exception("Longitudes distintas");

        for(int i = 0; i < text1.Length; i++)
        {
            if (text1[i] != text2[i])
                distance++;
        }

        Console.WriteLine("La distancia es de: " + distance);
    }

    //4.- COntador de Palabras
    static void wordCount()
    {
        string text = "  body    lover    rules    ";
        int n = 0;
        text = Regex.Replace(text, @"\s+", " ").Trim();

        var words = text.Split(' ');
        n = words.Length;

        Console.WriteLine("Numero de palabras: " + n);
    }

    //5.- COntar numero en una cadena
    static void countNumbers()
    {
        string text = "ssjdkfhsd9f789786/(&sd9f8769s8u)(&/()&8huh3j";
        string pattern = @"[0-9]";

        var regex = new Regex(pattern);
        int n = regex.Matches(text).Count();

        Console.WriteLine("Numeros en la cadena: " + n);
    }

    static void basicQueriesLINQ()
    {
        int[] numbers = {1,2,3,4,5,6,7,8,9,0};

        var numQuery = from num in numbers
                       where num > 0 && (num % 2) == 0
                       orderby num descending
                       select num;
        foreach(int num in numQuery)
        {
            Console.WriteLine("{0,1} ", num);
        }
    }

    static int codere(int A, int B, int  K)
    {
        if (A % K == 0)
        {
            return (B - A); // K + 1
        }
        if (A % K > 0)
        {
            return (B - (A - A % K)); // K
        }
        else
            return 0;
    }

    static void Bubble()
    {
        int[] array = { 4, 1, 3, 9, 7 };

        var result = from num in array
                     orderby num ascending
                     select num;

        foreach (int num in result)
        {
            Console.WriteLine("{0,1} ", num);
        }
    }
}