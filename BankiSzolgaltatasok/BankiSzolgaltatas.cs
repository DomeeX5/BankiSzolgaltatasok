﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
	internal abstract class BankiSzolgaltatas
	{
		Tulajdonos tulajdonos;

		protected BankiSzolgaltatas(Tulajdonos tulajdonos)
		{
			this.tulajdonos = tulajdonos;
		}

		internal Tulajdonos Tulajdonos { get => tulajdonos; }
	}
}
