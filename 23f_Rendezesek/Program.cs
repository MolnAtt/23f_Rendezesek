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

		public static void Beszuró_rendezés(List<int> lista)
		{
			for (int i = 1; i < lista.Count; i++)
			{
				Süllyesztés(lista, i);
			}
		}

		public static void Süllyesztés(List<int> lista, int i)
		{
			while (0 < i && lista[i-1] > lista[i])
			{
				Csere(lista, i - 1, i);
				i--;
			}
		}

		public static void Gagyi_Buborékos_rendezés(List<int> lista)
		{
			for (int meddig = lista.Count; 1 < meddig; meddig--)
			{
				Gagyin_Felbugyborékol_eddig(lista, meddig);
				//Console.WriteLine();

			}
		}

		public static void Gagyin_Felbugyborékol_eddig(List<int> lista, int meddig)
		{
			for (int i = 1; i < meddig; i++)
			{
				if (lista[i-1] > lista[i])
				{
					Csere(lista, i - 1, i);
				}
				//Console.WriteLine(Stringbe(lista));

			}
		}


		public static void Buborékos_rendezés(List<int> lista)
		{
			int meddig = lista.Count;
			while (0 < meddig)
			{
				if (Felbugyborékol_eddig(lista, meddig))
					meddig -= 2;
				else
					meddig -= 1;
                Console.WriteLine();
            }
		}

		public static bool Felbugyborékol_eddig(List<int> lista, int meddig)
		{
			for (int i = 1; i < meddig - 1; i++)
			{
				if (lista[i - 1] > lista[i])
				{
					Csere(lista, i - 1, i);
					Console.WriteLine(Stringbe(lista));
				}
			}

			// ez az utolsó csere!
			if (1 < meddig && lista[meddig - 2] > lista[meddig-1])
			{
				Csere(lista, meddig - 1 - 1, meddig - 1);
				Console.WriteLine(Stringbe(lista));
				return false;
			}
			else
				return true;

		}


		static Random r = new Random();
		public static void Keverés(List<int> lista)
		{

		}

		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 6, 9 };
            Console.WriteLine(Stringbe(lista));
			//Minimumkiválasztásos_rendezés(lista);
			//Beszuró_rendezés(lista);
			//Gagyi_Buborékos_rendezés(lista);
			//Buborékos_rendezés(lista);
			Console.WriteLine(Stringbe(lista));

		}
	}
}
