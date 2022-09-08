using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgramNumeroUno
{

    class Program
    {
        static void currList(List<dynamic> lista)
        {
            Console.WriteLine("Obecna lista: ");
            foreach(string elem in lista)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine(); 
        }
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Kuba\\source\\repos\\ToDoApp\\lista.txt";

            string text = File.ReadAllText(path);
            List<dynamic> lista = new List<dynamic>();
            string[] listaText = text.Split("\n");

            foreach(string line in listaText)
            {
                lista.Add(line);
            }
            currList(lista);

            bool addElement;
            do
            {
                addElement = false;
                Console.WriteLine("Czy chcesz dodać element do listy? Tak/Nie");
                if (Console.ReadLine() == "Tak")
                {
                    addElement = true;
                    Console.WriteLine("Podaj co chcesz dodać:");
                    lista.Add(Console.ReadLine());
                }
            } while (addElement);
            currList(lista);

            Console.WriteLine("Czy chcesz zresetować listę? Tak/Nie");
            if (Console.ReadLine()=="Tak")
            {
                lista.Clear();
                Console.WriteLine("Lista została zresetowana!");
            }
            else
            {
                Console.WriteLine("Lista nie została zresetowana");
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

            Console.WriteLine(textFin);
            File.WriteAllText(path,textFin);
        }
    }
}
