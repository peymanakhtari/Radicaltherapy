#pragma checksum "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83aa01517c268610ee0ab8370d94b5c7a6547d39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reserve_Index), @"mvc.1.0.view", @"/Views/Reserve/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\_ViewImports.cshtml"
using RadicalTherapy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\_ViewImports.cshtml"
using RadicalTherapy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
using RadicalTherapy.Data.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
using RadicalTherapy.Utility.Convertor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83aa01517c268610ee0ab8370d94b5c7a6547d39", @"/Views/Reserve/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff49281639dda514ac4512511195c403d412d181", @"/Views/_ViewImports.cshtml")]
    public class Views_Reserve_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Reserve_index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    List<DateTime> ReservesDate = new List<DateTime>();
    using (UnitOfWork db = new UnitOfWork())
    {
        DateTime date = DateTime.Now.AddDays(15);
        var Reserves = db.ReserveRepository.Get(c => c.Datetime >= DateTime.Now && c.Datetime <= date);

        foreach (var item in Reserves)
        {
            ReservesDate.Add(item.Datetime);
        }

    }



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n");
#nullable restore
#line 26 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
Write(Html.ActionLink("بازگشت", "Index", "Home", null, new { @class = "return", @style = "  font-family:bkoodakbold;float:right;margin:15px 20px 0px 0 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n<br />\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral(@"<div id=""video-reserve"">
    <p style=""font-family:Shabnam-bold "" class=""text-center px-4"">لطفاً قبل از جلسه پیش مشاوره رایگان، ویدئوی زیر را ببینید تا در مورد رادیکال تراپی اطلاعات تون کامل باشه</p>
 
    <div class=""col-10 col-md-7 mx-auto pb-5"">
        <iframe id=""youtube-resarvation-video"" style=""width:100%;"" src=""https://www.youtube.com/embed/Cgj_dL9SSj0"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>
    </div>
</div>

<div id=""reserveInfo"" style=""display:none;margin-top:10px"" class=""col-9 col-sm-8 col-lg-6 col form reserve-info "">
    <p>رزرو ثبت شده شما</p>

    <label id=""dateinfo"" class=""datelable"" style=""font-size:16px""");
            BeginWriteAttribute("for", " for=\"", 1673, "\"", 1679, 0);
            EndWriteAttribute();
            WriteLiteral("></label>\r\n    <label id=\"number\" dir=\"ltr\" style=\"font-size:16px;display:inline-block\"");
            BeginWriteAttribute("for", " for=\"", 1767, "\"", 1773, 0);
            EndWriteAttribute();
            WriteLiteral("></label>\r\n    <label dir=\"ltr\" style=\"font-size:16px;display:inline-block\"");
            BeginWriteAttribute("for", " for=\"", 1849, "\"", 1855, 0);
            EndWriteAttribute();
            WriteLiteral(">: واتسآپ</label>\r\n    <br />\r\n    <label id=\"name\" dir=\"ltr\" style=\"font-size:16px;display:inline-block\"");
            BeginWriteAttribute("for", " for=\"", 1961, "\"", 1967, 0);
            EndWriteAttribute();
            WriteLiteral("> </label>\r\n    <label dir=\"ltr\" style=\"font-size:16px;display:inline-block\"");
            BeginWriteAttribute("for", " for=\"", 2044, "\"", 2050, 0);
            EndWriteAttribute();
            WriteLiteral(@"> : نام شما</label>

    <div style=""width:100%;text-align:center"" class=""deletereserve"">
        <button id=""deleteReserve"" class=""btndelete"">حذف &nbsp;&nbsp;رزرو</button>
    </div>

</div>


<p id=""reserveDeleted"" class=""reserve-message""></p>
<p id=""select-reserve"" class=""reserve-message "">یکی از تایم های زیر را انتخاب کنید <b>.</b> <br style=""display:none"" /> تایم های با رنگ <span style=""color:red"">قرمز </span> اشغال شده اند </p>



<div id=""messageChooseOtherTime"" class=""col-9 col-sm-8 message1"" col-md-7 style=""display:none;text-align:center;margin:8px auto ;padding-top:16px;border-radius:5px;height:107px;background-color:#424242;color:white;font-family:'bkoodakbold';font-size:17px"">
    شما درحال حاضر تایمی را انتخاب نموده اید .میتوانید آن را حذف و تایم دیگری را انتخاب کنید
</div>


<div dir=""rtl"">
    <div class=""reserve-container"" style=""text-align: center; width: 100%;"">

");
#nullable restore
#line 74 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
         for (int i = 0; i < 14; i++)
        {
            DateTime DATE = DateTime.Now.AddDays(i+1);

            string dayofweek = DateTool.Dayofweek(DATE);

            if (i == 0)
            {
                dayofweek = "فردا";
            }

            string monthofyear = DateTool.DayOfMounth(DATE.ToShamsi1());

            string date = DATE.ToShamsi1().Day.ToString() + " - "
       + monthofyear;
            List<DateTime> hours = new List<DateTime>();
            hours.Add(new DateTime(DATE.Year, DATE.Month, DATE.Day, 14, 0, 0));
            hours.Add(new DateTime(DATE.Year, DATE.Month, DATE.Day, 14, 30, 0));
            hours.Add(new DateTime(DATE.Year, DATE.Month, DATE.Day, 15, 0, 0));
            hours.Add(new DateTime(DATE.Year, DATE.Month, DATE.Day, 15, 30, 0));



#line default
#line hidden
#nullable disable
            WriteLiteral("            <div dir=\"ltr\" class=\"reserve-box col-9 col-sm-5 col-lg-3\">\r\n                <p> ");
#nullable restore
#line 97 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
               Write(dayofweek);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp&nbsp ");
#nullable restore
#line 97 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                                     Write(date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 98 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                 foreach (var item in hours)
                {

                    if (ReservesDate.Any(c => c == item) || item < DateTime.Now)
                    {
                        if (item.Minute == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"hour-fulled\"><span>");
#nullable restore
#line 105 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                                                    Write(item.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </a>\r\n");
#nullable restore
#line 106 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a dir=\"ltr\" class=\"hour-fulled\"><span>");
#nullable restore
#line 109 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                                                              Write(item.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 109 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                                                                           Write(item.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </a>\r\n");
#nullable restore
#line 110 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                        }

                    }
                    else
                    {
                        if (item.Minute == 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                       Write(Html.ActionLink($"{item.Hour}", "Submit", new { datetime = item }, new { @class = "hour" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                                                                                                                        
                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                       Write(Html.ActionLink($"{item.Hour} : {item.Minute}", "Submit", new { datetime = item }, new { @class = "hour", @dir = "ltr" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"
                                                                                                                                                      
                        }
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 127 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Reserve\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83aa01517c268610ee0ab8370d94b5c7a6547d3913172", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n<br />\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
