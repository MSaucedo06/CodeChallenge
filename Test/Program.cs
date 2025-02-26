using System.Text.RegularExpressions;

namespace Test;
class Program
{
    static async Task Main(string[] args)
    {
        var students = new List<Student>
            {
                new Student { Name = "Alice", GPA = 3.6 },
                new Student { Name = "Bob", GPA = 3.2 },
                new Student { Name = "Charlie", GPA = 3.8 }
            };

        string url = "https://jsonplaceholder.typicode.com/todos/1";
        string path = @"C:\Users\Mike\source\repos\Test\archivo_descargado.txt";
        string pathFile = @"C:\Users\Mike\source\repos\Test\numbers.txt";


        revert();
        repeat();
        hamming();
        wordCount();
        countNumbers();
        var filteredStudents = FilterAndSort(students);
        filteredStudents.ForEach(Console.WriteLine);
        var sum = ReadFileAndSumNumbers(pathFile);
        Console.WriteLine(sum);
        var resutl = await DownloadFileAsync(url, path);

        Console.ReadLine();

    }    

    //1.- Invertir Cadena
    static void revert()
    {
        string text = "Mantequilla";
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
        int cnt1 = 0;

        for(int i= 0; i < text.Length; i++)
        {
            if (text[i] == character)
            {
                cnt1++;
            }
        }

        //foreach(var c in text)
        //{
        //    if (c == character)
        //        cnt++;
        //}

        cnt = text.Where(c => c == character).Count();

        Console.WriteLine($"El caracter {character} se repite {cnt} veces. {cnt1}");
    }

    //3.- Distancia de Hamming
    static void hamming()
    {
        string text1 = "flaca";
        string text2 = "flaco";

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

    //4.- Contador de Palabras
    static void wordCount()
    {
        string text = "  señor    mantequilla    de  mani  ";
        int n = 0;
        text = Regex.Replace(text, @"\s+", " ").Trim();

        var words = text.Split(' ');
        n = words.Length;

        Console.WriteLine("Numero de palabras: " + n);
    }

    //5.- Contar numero en una cadena
    static void countNumbers()
    {
        string text = "ssjdkfhsd9f789786/(&sd9f8769s8u)(&/()&8huh3j";
        string pattern = @"[0-9]";

        var regex = new Regex(pattern);
        int n = regex.Matches(text).Count();

        Console.WriteLine("Numeros en la cadena: " + n);
    }

    //6.- Filtrar con Linq
    public static List<string> FilterAndSort(List<Student> students)
    {
        return students
            .Where(student => student.GPA > 3.5)
            .OrderByDescending(student => student.GPA)
            .Select(student => student.Name)
            .ToList();
    }

    //7.- Leer archivo linea por linea
    public static int ReadFileAndSumNumbers(string filePath)
    {
        int sum = 0;

        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (int.TryParse(line, out int number))
                {
                    sum += number;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

        }
        return sum;
    }

    //8.- Leer API y guardar en archivo
    public static async Task<long> DownloadFileAsync(string url, string path)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await response.Content.CopyToAsync(fileStream);
                return fileStream.Length;
            }
        }
    }
}