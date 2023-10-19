using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class Bank
	{
		private List<Szamla> szamlaLista = new List<Szamla>();

		public long OsszHitelkeret 
		{ 
			get
			{
				long osszHitel = 0;
				foreach (var szamla in szamlaLista)
				{
					if (szamla is HitelSzamla hitelSzamla)
					{
						osszHitel += hitelSzamla.HitelKeret;
					}
				}
				return osszHitel;
			}
		}

		public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
		{
			Szamla szamla;
			if (hitelKeret < 0)
			{
				throw new ArgumentException("Nem lehet negatív a hitelkeret");
			}
			if (hitelKeret == 0)
			{
				szamla = new MegtakaritasiSzamla(tulajdonos);
			}
			else
			{
				szamla = new HitelSzamla(tulajdonos, hitelKeret);
			}
			szamlaLista.Add(szamla);
			return szamla;
		}

		public long GetOsszEgyenleg(Tulajdonos tulajdonos)
		{
			long osszEgyenleg = 0;
			foreach (var szamla in szamlaLista)
			{
				if (szamla.Tulajdonos == tulajdonos)
				{
					osszEgyenleg+= szamla.AktualisEgyenleg;
				}
				
			}
			return osszEgyenleg;
		}

		public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
		{
			long maxEgyenleg = 0;
			Szamla szamlaMax = null;

			foreach (var szamla in szamlaLista.Where(e => e.Tulajdonos == tulajdonos))
			{
				if (szamla.AktualisEgyenleg > maxEgyenleg)
				{
					maxEgyenleg = szamla.AktualisEgyenleg;
					szamlaMax = szamla;
				}
			}
			return szamlaMax;

		}

		
	}
}
