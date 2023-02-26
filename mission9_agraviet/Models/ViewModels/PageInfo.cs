using System;
namespace mission9_agraviet.Models.ViewModels
{
	public class PageInfo
	{
		public int TotalNumBooks { get; set; }
		public int BooksPerPage { get; set; }
		public int CurrentPage { get; set; }


		//figure out how many pages needed
		public int TotalPages => (int)Math.Ceiling((double) TotalNumBooks / BooksPerPage);
	}
}

