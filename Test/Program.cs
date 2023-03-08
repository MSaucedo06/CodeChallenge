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
}