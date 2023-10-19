using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public class Bank
	{
		private List<Szamla> szamlaLista;

		public long OsszHitelkeret { 
			get
			{
				return szamlaLista.Count;
			}
		}

		public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
		{
			Szamla szamla;
			if (hitelKeret < 0)
			{
				throw new Exception("Nem lehet negatív a hitelkeret");
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
			int maxEgyenleg = 0;
			Szamla szamlaMax;
			for (int i = 0; i < szamlaLista.Count; i++)
			{
				maxEgyenleg = szamlaLista[0].AktualisEgyenleg;
				if (maxEgyenleg > szamlaLista[i].AktualisEgyenleg && tulajdonos == szamlaLista[i].Tulajdonos)
				{
					maxEgyenleg = szamlaLista[i].AktualisEgyenleg;
					
				}
			}
			maxEgyenleg = szamlaLista.Where(e => e.Tulajdonos == tulajdonos).Max((x => x.AktualisEgyenleg));
			szamlaMax = szamlaLista.FirstOrDefault(x => x.Equals(maxEgyenleg));
			return szamlaMax;
		}

		
	}
}
