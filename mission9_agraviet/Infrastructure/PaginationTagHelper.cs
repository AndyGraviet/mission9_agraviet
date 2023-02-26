using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using mission9_agraviet.Models.ViewModels;

namespace mission9_agraviet.Controllers
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PaginationTagHelper : TagHelper
	{
		//dynamically create the page links for us
		private IUrlHelperFactory uhf;

		public PaginationTagHelper(IUrlHelperFactory temp)
		{
			uhf = temp;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext vc { get; set; }

		//different then view context
		public PageInfo PageModel { get; set; }
		public string PageAction { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
			IUrlHelper uh = uhf.GetUrlHelper(vc);

			TagBuilder final = new TagBuilder("div");

			for (int i = 1; i <= PageModel.TotalPages; i++)
			{
				TagBuilder tb = new TagBuilder("a");

				tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
				tb.InnerHtml.Append(i.ToString());
				tb.AddCssClass("ml-4");

				final.InnerHtml.AppendHtml(tb);
			}

			tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}

