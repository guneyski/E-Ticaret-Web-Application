﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.WebUI.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='ul-links'>");

            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                stringBuilder.AppendFormat("<li class='li-links {0}'>", i == PageModel.CurrentPage ? "" : "");

                if (string.IsNullOrEmpty(PageModel.CurrentCategory))
                {
                    stringBuilder.AppendFormat("<a class='a-links' href='/products?page={0}'>{0}</a>",i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='a-links' href='/products/{1}?page={0}'>{0}</a>", i, PageModel.CurrentCategory);
                }
                stringBuilder.Append("</li>");
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());


            base.Process(context, output);
        }
    }
}
