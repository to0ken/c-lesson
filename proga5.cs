using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // ================================= 1 =====================================
        /*using (StreamReader reader = new StreamReader("test.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line   
            }
        }*/

        /*string[] lines = File.ReadAllLines("test.txt");
        Array.Sort(lines);

        using (StreamWriter writer = new StreamWriter("test1.txt"))
        {
            foreach (string line in lines)
                writer.WriteLine(line);
        }*/

        // =================================== 2 ШИФР ЦЕЗАРЬ =======================================\

        /*string m;
        using (StreamReader reader = new StreamReader("Caesar.txt"))
        {
            m = reader.ReadToEnd();
        }

        int nomer;
        int d;
        string s;
        int j;

        char[] massage = m.ToCharArray();

        char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        // Шифрование: сдвиг на 3 позиции вправо
        for (int i = 0; i < massage.Length; i++)
        {
            for (j = 0; j < alfavit.Length; j++)
            {
                if (massage[i] == alfavit[j])
                {
                    break;
                }
            }

            if (j != 33) // Символ найден в алфавите
            {
                nomer = j;
                d = nomer + 3;

                if (d > 32) // Циклический переход
                {
                    d = d - 33;
                }

                massage[i] = alfavit[d];
            }
        }

        s = new string(massage);


        using (StreamWriter writer = new StreamWriter("Caesar1.txt"))
        {
            writer.Write(s);
        }*/

        // ================================================ 3 ==============================
        /*string folder = "folder";
        string[] file = Directory.GetFiles(folder);
        string[] dirs = Directory.GetDirectories(folder);
        string[] txtfiles = Directory.GetFiles(folder, "*.txt");
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(file[i]);
            Console.WriteLine(dirs[i]);
            Console.Write(txtfiles[i]);
        }*/

        // =================================================== 4 ========================================
        int[] numbers = {1, 2, 3, 5, 7, 8, 10, 11,12};
        var result = numbers
            .Where(n => n > 10)
            .OrderByDescending(n => n) // сортировка по убыванию 
            .Select(n => n * n)
            .ToArray();
        /*var result1 = from n in numbers
                      where n >10
                      orderby n
                      select n*n;*/
        for (int i = 0; i< result.Length; i++)
        {
            Console.WriteLine(result[i]);
        }

    }


}

       
