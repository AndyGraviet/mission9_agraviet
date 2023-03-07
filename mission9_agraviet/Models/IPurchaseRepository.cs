using System;
using System.Linq;

namespace mission9_agraviet.Models
{
	public interface IPurchaseRepository
	{
		IQueryable<Purchase> Purchases { get; }

		void SavePurchase(Purchase purchase);
	}
}

