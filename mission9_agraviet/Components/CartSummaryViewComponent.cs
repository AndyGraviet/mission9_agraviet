using System;
using Microsoft.AspNetCore.Mvc;
using mission9_agraviet.Models;

namespace mission9_agraviet.Components
{
	public class CartSummaryViewComponent : ViewComponent 
	{
		private Basket cart;
		public CartSummaryViewComponent (Basket cartService)
		{
			cart = cartService;
		}
		public IViewComponentResult Invoke()
		{
			return View(cart);
		}
	}
}

