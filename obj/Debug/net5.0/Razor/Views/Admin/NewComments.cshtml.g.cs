#pragma checksum "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8822ebefab0dc3e3e647ddf1599d45a4baca664"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_NewComments), @"mvc.1.0.view", @"/Views/Admin/NewComments.cshtml")]
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
#line 1 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\_ViewImports.cshtml"
using RadicalTherapy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
using RadicalTherapy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
using RadicalTherapy.Utility.Convertor;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8822ebefab0dc3e3e647ddf1599d45a4baca664", @"/Views/Admin/NewComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff49281639dda514ac4512511195c403d412d181", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_NewComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
  
    Layout = null;


#line default
#line hidden
#nullable disable
            WriteLiteral("<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>\r\n\r\n<br />\r\n<br />\r\n<a style=\"font-size:26px\"");
            BeginWriteAttribute("href", " href=\"", 250, "\"", 277, 1);
#nullable restore
#line 12 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
WriteAttributeValue("", 257, Url.Action("Index"), 257, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">صفحه اصلی</a>\r\n<br />\r\n<br />\r\n<div dir=\"ltr\" style=\"text-align:right;margin-right:50px\">\r\n\r\n");
#nullable restore
#line 17 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
     foreach (var cmt in Model.SubList)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div dir=\"ltr\" style=\"display:block;border:1px solid black;padding:10px;font-size:26px;width:92%;margin:auto\">\r\n            <p style=\"background-color:sandybrown\">");
#nullable restore
#line 20 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                                              Write(Subjects.GetNamebyType(cmt));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 21 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
              
                List<CommentModel> _comments = Model.Comments;
                var Comments = _comments.Where(c => c.Type == cmt);
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
             foreach (var item in Comments)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <input");
            BeginWriteAttribute("value", " value=\"", 873, "\"", 891, 1);
#nullable restore
#line 28 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
WriteAttributeValue("", 881, item.Type, 881, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 892, "\"", 910, 2);
            WriteAttributeValue("", 897, "type-", 897, 5, true);
#nullable restore
#line 28 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
WriteAttributeValue("", 902, item.Id, 902, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden />\r\n                <p style=\"background-color:lightcyan\">نام: &nbsp;");
#nullable restore
#line 29 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                                                            Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 30 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"


                for (int i = 1; i <= item.Text.Length; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>");
#nullable restore
#line 34 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                    Write(item.Text[i - 1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 35 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                    if (i < item.Text.Length)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div>");
#nullable restore
#line 37 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                        Write(item.Answer[i - 1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 38 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <br />\r\n");
#nullable restore
#line 40 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
                }


#line default
#line hidden
#nullable disable
            WriteLiteral("                <textarea style=\"width:100%;height:100px;border :1px solid green;text-align:right;font-size:24px\" type=\"text\" rows=\"2\"");
            BeginWriteAttribute("id", " id=\"", 1474, "\"", 1493, 2);
            WriteAttributeValue("", 1479, "reply-", 1479, 6, true);
#nullable restore
#line 42 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
WriteAttributeValue("", 1485, item.Id, 1485, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></textarea>\r\n                <input style=\"background-color:pink;color:white;padding:6px 20px;font-size:24px\" value=\"بستن\" type=\"button\" onclick=\"Checked(this.id)\"");
            BeginWriteAttribute("id", " id=\"", 1658, "\"", 1682, 2);
            WriteAttributeValue("", 1663, "btnChecked-", 1663, 11, true);
#nullable restore
#line 43 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
WriteAttributeValue("", 1674, item.Id, 1674, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input style=\"background-color:green;color:white;padding:6px 20px;font-size:24px\" value=\"ثبت\" type=\"button\" onclick=\"Reply(this.id)\"");
            BeginWriteAttribute("id", " id=\"", 1836, "\"", 1858, 2);
            WriteAttributeValue("", 1841, "btnReply-", 1841, 9, true);
#nullable restore
#line 44 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
WriteAttributeValue("", 1850, item.Id, 1850, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <br />\r\n                <br />\r\n");
#nullable restore
#line 47 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 49 "G:\radicaltherapy\radicaltherapy-v2-7\RadicalTherapy\Views\Admin\NewComments.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


</div>

<script>

    function Reply(Val) {
        var id = Val.split('-')[1];
        var text = document.getElementById(""reply-"" + id).value;
        var type = document.getElementById(""type-"" + id).value;

        $.ajax({
            type: ""POST"",
            url: '/Admin/Reply',
            data: {
                ""Id"": id,
                ""text"": text,
                ""type"": type
            },
            success: function (response) {
                document.getElementById(""btnReply-"" + id).style.backgroundColor = ""red"";
                document.getElementById(""btnReply-"" + id).value = ""ارسال شد"";
                document.getElementById(""btnReply-"" + id).onclick = null;
            },
            error: function (response) {
                alert('ارسال نشد')
            }
        });
    }
    function Checked(Val) {
        var id = Val.split('-')[1];

        $.ajax({
            type: ""POST"",
            url: '/Admin/Checked',
            data: {
        ");
            WriteLiteral(@"        ""Id"": id,
            },
            success: function (response) {
                document.getElementById(""btnChecked-"" + id).style.backgroundColor = ""red"";
                document.getElementById(""btnChecked-"" + id).value = ""بسته شد"";
                document.getElementById(""btnChecked-"" + id).onclick = null;
            },
            error: function (response) {
                alert('نظر بسته نشد')
            }
        });
    }

</script>
");
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
