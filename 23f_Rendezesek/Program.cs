using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23f_Rendezesek
{
	internal class Program
	{
		static string Stringbe<T>(List<T> t, string separator = " ", string start = "[ ", string end = " ]")
		{
			if (t.Count == 0)
			{
				return start + end;
			}
			string result = start;
			for (int i = 0; i < t.Count - 1; i++)
			{
				result += $"{t[i]}" + separator;
			}
			result += $"{t[t.Count - 1]}";
			return result + end;
		}

		/// <summary>
		/// Megkeresi a legkisebb elem indexét a listában egy adott indextől kezdve
		/// </summary>
		/// <returns></returns>
		static int Minimum_indexe_innentől(List<int> lista, int innentol)
		{
			int bestindex = innentol;
			for (int i = innentol+1; i < lista.Count; i++)
			{
				if (lista[i] < lista[bestindex])
				{
					bestindex = i;
				}
			}
			return bestindex;
		}

		static void Minimumkiválasztásos_rendezés(List<int> lista)
		{
			for (int i = 0; i < lista.Count - 1; i++)
			{
				int min_index = Minimum_indexe_innentől(lista, i);
				Csere(lista, i, min_index);
			}
		}
		
		static void Csere(List<int> lista, int i, int j)
		{
			int temp = lista[i];
			lista[i] = lista[j];
			lista[j] = temp;
        }

		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
            Console.WriteLine(Stringbe(lista));
            Minimumkiválasztásos_rendezés(lista);
			Console.WriteLine(Stringbe(lista));

		}
	}
}
