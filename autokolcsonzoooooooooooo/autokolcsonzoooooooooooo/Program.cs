using System;

namespace Kolcsonzo
{
	class Program
	{
		public static void Main(string[] args)
		{

			double egyenleg = 500000.0;

			double uzemanyagAr = 437.0; // Ft/liter

			KolcsonozhetoAuto[] flotta = new KolcsonozhetoAuto[10];

			KolcsonozhetoAuto elsoAuto =
				new KolcsonozhetoAuto("ABC-123", "Suzuki", 2020, 4, 40, 5.7, 'A');

			KolcsonozhetoAuto kettoAuto =
				new KolcsonozhetoAuto("BCD-234", "BMW", 2018, 2, 30, 3.7, 'A');

			KolcsonozhetoAuto haromAuto =
				new KolcsonozhetoAuto("CDE-345", "Toyota", 2021, 5, 36, 4.1, 'A');

			flotta[0] = elsoAuto;
			flotta[1] = kettoAuto;
			flotta[2] = haromAuto;


			flotta[3] = randomUjAuto(1);
			flotta[4] = randomUjAuto(2);

			flotta[5] = randomHasznaltAuto(3);
			flotta[6] = randomHasznaltAuto(4);
			flotta[7] = autobekeres();

           

			for (int i = 0; i <= 7; i++)
			{

				Console.Write(flotta[i].getRendszam() + " ; ");
				Console.Write(flotta[i].getGyarto() + " ; ");
				Console.Write(flotta[i].getGyartasEve() + " ; ");
				Console.Write(flotta[i].getUtasSzam() + " ; ");
				Console.Write(flotta[i].getuzemanyagMennyiseg() + " ; ");
				Console.Write(flotta[i].getFogyasztas() + " ; ");
				Console.Write(flotta[i].getMegtettKm() + " ; ");
				Console.Write(flotta[i].getBerelheto() + " ; ");
				Console.WriteLine(flotta[i].getKategoria());
			}
			

			for (int i = 0; i <= 7; i++)
			{
				flotta[i].kategoriaBeallitas();
			}


			for (int i = 0; i <= 7; i++)
			{

				Console.Write(flotta[i].getRendszam() + " ; ");
				Console.Write(flotta[i].getGyarto() + " ; ");
				Console.Write(flotta[i].getGyartasEve() + " ; ");
				Console.Write(flotta[i].getUtasSzam() + " ; ");
				Console.Write(flotta[i].getuzemanyagMennyiseg() + " ; ");
				Console.Write(flotta[i].getFogyasztas() + " ; ");
				Console.Write(flotta[i].getMegtettKm() + " ; ");
				Console.Write(flotta[i].getBerelheto() + " ; ");
				Console.WriteLine(flotta[i].getKategoria());
			}
		}

		public static KolcsonozhetoAuto randomUjAuto(int seed)
		{

			Random gen = new Random(seed);

			string[] gyartok = {
				"Maserati",
				"Jeep",
				"Ferrari",
				"Suzuki",
				"Volvo",
				"Lada"
			};

			char[] abc = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
							'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
							'X', 'Y', 'Z'};

			string abcS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			string rszam = "";

			for (int i = 0; i < 3; i++)
			{

				rszam += abcS[gen.Next(0, abcS.Length)];
			}

			rszam = rszam + "-";

			for (int i = 0; i < 3; i++)
			{

				rszam += gen.Next(0, 10).ToString();
			}
			string marka = gyartok[gen.Next(0, gyartok.Length)];
			int ev = gen.Next(1995, 2022);
			int utasok = gen.Next(2, 10);
			int tartaly = gen.Next(20, 71);
			double lpkm = 5.5 + (11 * gen.NextDouble());
			char kat = abc[gen.Next(0, 3)];

			KolcsonozhetoAuto auto = new KolcsonozhetoAuto(rszam, marka, ev, utasok, tartaly, lpkm, kat);

			return auto;
		}
		public static KolcsonozhetoAuto randomHasznaltAuto(int seed)
		{
			Random gen = new Random(seed);
			KolcsonozhetoAuto auto = randomUjAuto(seed);

			if (auto.getGyartasEve() == 2021)
			{
				auto.setGyartasiIdo(auto.getGyartasEve() - 4);
			}

			auto.setMegtettKm(362000);

			return auto;
		}

		public static KolcsonozhetoAuto autobekeres()
		{
			string rszam = "";
			string gyarto = "";
			int gyartev = 0;
			int utasokszama = 0;
			int tartalym = 0;
			double lpkm = 0.0;
			char kat;
			bool rsz = false, gyart = false, ev = false, utas = false, tartaly = false, fogy = false;
			Console.ReadLine();
			do
			{
				Console.WriteLine("Adja meg az autónak a rendszámát -kötőjellel- -el elválasztva:");
				rszam = Console.ReadLine();
				if (rszam.Length < 7)
				{
					rsz = false;
					Console.WriteLine("Nem jó a rendszám!");
				}
				else if ((rszam[0] >= 'A' && rszam[0] <= 'Z') && (rszam[1] >= 'A' && rszam[1] <= 'Z') && (rszam[2] >= 'A' && rszam[2] <= 'Z') && rszam[3] == '-' && (rszam[4] >= '0' && rszam[4] <= '9') && (rszam[5] >= '0' && rszam[5] <= '9') && (rszam[6] >= '0' && rszam[6] <= '9'))
				{
					rsz = true;
					Console.WriteLine("Rendszám jó.");
				}
				else
				{
					rsz = false;
					Console.WriteLine("Nem jó a rendszám!");
				}
			}
			while (!rsz);
			do
			{
				Console.WriteLine("Adja meg az autónak a gyártóját:");
				gyarto = Console.ReadLine();
				if (gyarto.Length != 0 && gyarto.Length >= 2)
				{
					gyart = true;
					Console.WriteLine("Gyártó jó.");
				}
				else
				{
					gyart = false;
					Console.WriteLine("Nem jó a gyártó!");
				}
			}
			while (!gyart);
			do
			{
				Console.WriteLine("Adja meg az autó gyártási évét:");
				gyartev = Convert.ToInt32(Console.ReadLine());
				if (gyartev >= 1960 || gyartev <= 2021)
				{
					ev = true;
					Console.WriteLine("Gyártási év jó.");
				}
				else
				{
					ev = false;
					Console.WriteLine("Nem jó gyártási év!");
				}
			}
			while (!ev);
			do
			{
				Console.WriteLine("Adja meg az autó férőhelyének a számát:");
				utasokszama = Convert.ToInt32(Console.ReadLine());
				if (utasokszama >= 1 || utasokszama <= 9)
				{
					utas = true;
					Console.WriteLine("Utasok száma jó.");
				}
				else
				{
					utas = false;
					Console.WriteLine("A férőhelyek 1 től 9 ig legyen!");
				}
			}
			while (!utas);
			do
			{
				Console.WriteLine("Adja meg az autó tartály méretét:");
				tartalym = Convert.ToInt32(Console.ReadLine());
				if (tartalym >= 20 || tartalym <= 100)
				{
					tartaly = true;
					Console.WriteLine("Tartály méret jó.");
				}
				else
				{
					tartaly = false;
					Console.WriteLine("Tartály méret nem jó 20 tól 100 ig adja meg!");
				}
			}
			while (!tartaly);
			do
			{
				Console.WriteLine("Adja meg az autó fogyasztását l/100km:");
				lpkm = Convert.ToDouble(Console.ReadLine());
				if (lpkm >= 4.2 || lpkm <= 10.8)
				{
					fogy = true;
					Console.WriteLine("Fogyasztás jó.");
				}
				else
				{
					fogy = false;
					Console.WriteLine("Fogyasztást helytelenül adta meg 4 től 60 ig adja meg!");
				}
			}
			while (!fogy);
			do
			{
				Console.WriteLine("Adja meg az autó kategoriáját(A vagy B vagy C):");
				kat = Convert.ToChar(Console.ReadLine().ToUpper());

			}
			while (kat != 'A' && kat != 'B' && kat != 'C');

			Console.WriteLine("Autó bekérése megtörtént!");
			KolcsonozhetoAuto auto = new KolcsonozhetoAuto(rszam, gyarto, gyartev, utasokszama, tartalym, lpkm, kat);
			Console.ReadLine();
			return auto;


		}
	}
}