using eStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace eStore.Infrastructure;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper(IUrlHelperFactory helperFactory) : TagHelper
{
    private IUrlHelperFactory urlHelperFactory = helperFactory;

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }
    public PagingInfo? PageModel { get; set; }
    public string? PageAction { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageModel != null)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("ul");
            result.AddCssClass("pagination");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("li");
                tag.AddCssClass("page-item");

                TagBuilder link = new TagBuilder("a");
                link.AddCssClass("page-link");
                link.Attributes["href"] = "#";
                link.Attributes["data-page"] = i.ToString();
                link.InnerHtml.Append(i.ToString());

                tag.InnerHtml.AppendHtml(link);
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result);
        }
    }

}
