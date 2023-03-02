using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mission9_agraviet.Models;

namespace mission9_agraviet.Components
{
	public class CategoriesViewComponent : ViewComponent
	{
		private IBookstoreRepository repo { get; set; }

		public CategoriesViewComponent (IBookstoreRepository temp)
		{
			repo = temp;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			var categories = repo.Books
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);
			return View(categories);
		}
	}
}

