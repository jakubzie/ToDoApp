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
            string path = "C:\\Users\\Kuba\\source\\repos\\ToDoApp\\lista.txt";

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
                Console.WriteLine("Czy chcesz dodać element do listy? Tak/Nie/X aby wyjść");
                string add = Console.ReadLine();
                if (add == "Tak")
                {
                    addElement = true;
                    Console.Write("Podaj co chcesz dodać: ");
                    lista.Add(Console.ReadLine());
                }
                else if (add == "X")
                {
                    goto LoopEnd;
                }
                Console.WriteLine("Czy chcesz usunąć element z listy? Tak/Nie/X aby wyjść");
                string del = Console.ReadLine();
                if (del == "Tak")
                {
                    delElement = true;
                    Console.Write("Którą pozycję chcesz usunąć?: ");
                    lista.RemoveAt(Convert.ToInt32(Console.ReadLine())-1);
                }
                else if(del == "X")
                {
                    goto LoopEnd;
                }
            } while (addElement || delElement);
            LoopEnd:
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
