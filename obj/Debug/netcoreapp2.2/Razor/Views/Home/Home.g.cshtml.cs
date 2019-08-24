#pragma checksum "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96f6433c5620e32e0ea5b98aa348a7dfe752ca28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Home), @"mvc.1.0.view", @"/Views/Home/Home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Home.cshtml", typeof(AspNetCore.Views_Home_Home))]
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
#line 1 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/_ViewImports.cshtml"
using ActivityCenter;

#line default
#line hidden
#line 2 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/_ViewImports.cshtml"
using ActivityCenter.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96f6433c5620e32e0ea5b98aa348a7dfe752ca28", @"/Views/Home/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e339c4346f16b3c5483ad512c481a4e17eb8f1c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wrapper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 274, true);
            WriteLiteral(@"<div class=""container"">
    <div class=""banner"" style=""margin-top: 30px; display: block;"">
        <h1 style=""display: inline-block; vertical-align: top;"">Dojo Activity Center</h1>
        <h4 style=""display: inline-block; vertical-align: top; margin-left: 300px;"">Welcome, ");
            EndContext();
            BeginContext(290, 17, false);
#line 5 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                                                                        Write(ViewBag.User.Name);

#line default
#line hidden
            EndContext();
            BeginContext(307, 647, true);
            WriteLiteral(@"!</h4>
        <a href=""/logout"" style=""display: inline-block; vertical-align: top; margin-left: 70px;""><h4>Logout</h4></a>
        <hr style=""margin-top: 20px;"">
    </div>
    <div class=""table"">
        <table class=""table table-bordered"">
            <thead>
                <tr>
                <th scope=""col"">Activity</th>
                <th scope=""col"">Date and Time</th>
                <th scope=""col"">duration</th>
                <th scope=""col"">Event Coordinator</th>
                <th scope=""col"">No. of Participants</th>
                <th scope=""col"">Actions</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 22 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                 foreach(var activity in Model.AllActivities){

#line default
#line hidden
            BeginContext(1017, 84, true);
            WriteLiteral("                    <tr>\n                        <td>\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1101, "\"", 1138, 2);
            WriteAttributeValue("", 1108, "/activity/", 1108, 10, true);
#line 25 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
WriteAttributeValue("", 1118, activity.ActivityId, 1118, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1139, 5, true);
            WriteLiteral("><h4>");
            EndContext();
            BeginContext(1145, 14, false);
#line 25 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                                                    Write(activity.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1159, 101, true);
            WriteLiteral("</h4></a>\n                        </td>\n                        <td>\n                            <h4>");
            EndContext();
            BeginContext(1261, 38, false);
#line 28 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                           Write(activity.ActivityDate.ToString("M/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1301, 40, false);
#line 28 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                                                   Write(activity.ActivityTime.ToString("h:mmtt"));

#line default
#line hidden
            EndContext();
            BeginContext(1341, 97, true);
            WriteLiteral("</h4>\n                        </td>\n                        <td>\n                            <h4>");
            EndContext();
            BeginContext(1439, 17, false);
#line 31 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                           Write(activity.Duration);

#line default
#line hidden
            EndContext();
            BeginContext(1456, 97, true);
            WriteLiteral("</h4>\n                        </td>\n                        <td>\n                            <h4>");
            EndContext();
            BeginContext(1554, 71, false);
#line 34 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                           Write(Model.AllUsers.FirstOrDefault(u=>u.UserId == activity.OrganizerId).Name);

#line default
#line hidden
            EndContext();
            BeginContext(1625, 97, true);
            WriteLiteral("</h4>\n                        </td>\n                        <td>\n                            <h4>");
            EndContext();
            BeginContext(1723, 26, false);
#line 37 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                           Write(activity.Attendees.Count());

#line default
#line hidden
            EndContext();
            BeginContext(1749, 65, true);
            WriteLiteral("</h4>\n                        </td>\n                        <td>\n");
            EndContext();
#line 40 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                              
                                if(activity.OrganizerId == ViewBag.UserId)
                                {

#line default
#line hidden
            BeginContext(1954, 38, true);
            WriteLiteral("                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1992, "\"", 2027, 2);
            WriteAttributeValue("", 1999, "/delete/", 1999, 8, true);
#line 43 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
WriteAttributeValue("", 2007, activity.ActivityId, 2007, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2028, 21, true);
            WriteLiteral("><h4>Delete</h4></a>\n");
            EndContext();
#line 44 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                } else {
                                    IEnumerable<int> yes = activity.Attendees.Select(att=>att.AttendeeId);
                                    

#line default
#line hidden
#line 46 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                     if(yes.Contains((int)ViewBag.UserId)){

#line default
#line hidden
            BeginContext(2273, 42, true);
            WriteLiteral("                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2315, "\"", 2349, 2);
            WriteAttributeValue("", 2322, "/leave/", 2322, 7, true);
#line 47 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
WriteAttributeValue("", 2329, activity.ActivityId, 2329, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2350, 20, true);
            WriteLiteral("><h4>Leave</h4></a>\n");
            EndContext();
#line 48 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                    } else {

#line default
#line hidden
            BeginContext(2415, 42, true);
            WriteLiteral("                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2457, "\"", 2490, 2);
            WriteAttributeValue("", 2464, "/join/", 2464, 6, true);
#line 49 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
WriteAttributeValue("", 2470, activity.ActivityId, 2470, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2491, 19, true);
            WriteLiteral("><h4>Join</h4></a>\n");
            EndContext();
#line 50 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                    }

#line default
#line hidden
#line 50 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                                     
                                }
                            

#line default
#line hidden
            BeginContext(2612, 56, true);
            WriteLiteral("                        </td>\n                    </tr>\n");
            EndContext();
#line 55 "/Users/richpurcell/Downloads/Coding-Dojo/C#_stack/ASP_MVC/ActivityCenter/Views/Home/Home.cshtml"
                }

#line default
#line hidden
            BeginContext(2686, 169, true);
            WriteLiteral("            </tbody>\n        </table>\n        <a href=\"/new\" style=\"margin-left: 930px;\"><button class=\"btn btn-primary\">New Activity</button></a>\n    </div>\n    \n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
