using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{

    class Program
    {
        static void currList(List<dynamic> lista)
        {
            Console.WriteLine("Current list: ");
            int i = 1;
            foreach(string elem in lista)
            {
                Console.WriteLine(i+". "+elem);
                i++;
            }
            Console.WriteLine(); 
        }
        static void Main(string[] args)
        {
            string oldpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            string path = $"{Path.GetFullPath(Path.Combine(oldpath, @"..\..\..\"))}\\lista.txt";

            string text = File.ReadAllText(path);
            List<dynamic> lista = new List<dynamic>();
            string[] listaText = text.Split("\n");

            foreach(string line in listaText)
            {
                lista.Add(line);
            }

            bool addElement,delElement;
            do
            {
                addElement = delElement = false;
                currList(lista);
                Console.WriteLine("Would you like to add a position to the list? Yes/No/X to quit");
                string add = Console.ReadLine();
                if (add.ToLower() == "yes")
                {
                    addElement = true;
                    Console.Write("What do you want to add?: ");
                    lista.Add(Console.ReadLine());
                }
                else if (add.ToLower() == "x")
                {
                    goto LoopEnd;
                }
                Console.WriteLine("Would you like to remove something from the list? Yes/No/X to quit");
                string del = Console.ReadLine();
                if (del.ToLower() == "yes")
                {
                    delElement = true;
                    Console.Write("Which position would you like to remove?: ");
                    lista.RemoveAt(Convert.ToInt32(Console.ReadLine())-1);
                }
                else if(del.ToLower() == "x")
                {
                    goto LoopEnd;
                }
            } while (addElement || delElement);
            LoopEnd:
                currList(lista);

            Console.WriteLine("Would you like to reset the list? Yes/No");
            if (Console.ReadLine().ToLower()=="yes")
            {
                lista.Clear();
                Console.WriteLine("The list has been reset!");
            }
            else
            {
                Console.WriteLine("The list has not been reset");
            }

            string textFin ="";
            foreach(string line in lista)
            {
                if (textFin == "")
                {
                    textFin = line;
                }
                else
                {
                    textFin = string.Concat(textFin, "\n", line);
                }
            }

            File.WriteAllText(path,textFin);
        }
    }
}
