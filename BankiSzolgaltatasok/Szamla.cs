﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	public abstract class Szamla : BankiSzolgaltatas
	{
		protected int aktualisEgyenleg;

		public Szamla(Tulajdonos tulajdonos) : base(tulajdonos)
		{
			aktualisEgyenleg = 0;
		}

		public int AktualisEgyenleg { get => aktualisEgyenleg; }

		public void Befizet(int osszeg)
		{
			osszeg += aktualisEgyenleg;
		}

		public abstract bool Kivesz(int osszeg);
	}
}
