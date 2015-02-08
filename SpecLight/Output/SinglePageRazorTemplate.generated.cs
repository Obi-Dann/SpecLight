﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpecLight.Output
{
    using System;
    
    #line 9 "..\..\Output\SinglePageRazorTemplate.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Output\SinglePageRazorTemplate.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 11 "..\..\Output\SinglePageRazorTemplate.cshtml"
    using SpecLight;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Output\SinglePageRazorTemplate.cshtml"
    using SpecLight.Output.ViewModel;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class SinglePageRazorTemplate : SpecLight.Output.RazorTemplateBase
    {
#line hidden
#line hidden
public System.Web.WebPages.HelperResult RenderMarkdown(string s)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 136 "..\..\Output\SinglePageRazorTemplate.cshtml"
 
	var html = MarkdownSharp.Markdown.Instance.Transform(s);
	
#line default
#line hidden


#line 138 "..\..\Output\SinglePageRazorTemplate.cshtml"
WriteTo(@__razor_helper_writer, RawHtml(html));

#line default
#line hidden


#line 138 "..\..\Output\SinglePageRazorTemplate.cshtml"
               

#line default
#line hidden

});

}

#line hidden
public System.Web.WebPages.HelperResult TagBox(IEnumerable<string> tags)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 142 "..\..\Output\SinglePageRazorTemplate.cshtml"
 
    if (tags == null || !tags.Any())
    {
        return;
    }

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    <span class=\"tags\">");



#line 147 "..\..\Output\SinglePageRazorTemplate.cshtml"
WriteTo(@__razor_helper_writer, string.Join(", ", tags.Select(x => "@" + x)));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</span>\r\n");



#line 148 "..\..\Output\SinglePageRazorTemplate.cshtml"

#line default
#line hidden

});

}

#line hidden
public System.Web.WebPages.HelperResult ExtraData(IDictionary<string, object> dataDictionary)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 151 "..\..\Output\SinglePageRazorTemplate.cshtml"
 
    var data = dataDictionary.FormatExtraData();
    if (!string.IsNullOrWhiteSpace(data))
    {

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "        <span class=\"extra-data\" title=\"Extra Data\">");



#line 155 "..\..\Output\SinglePageRazorTemplate.cshtml"
                     WriteTo(@__razor_helper_writer, data);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</span>\r\n");



#line 156 "..\..\Output\SinglePageRazorTemplate.cshtml"
    }

#line default
#line hidden

});

}

#line hidden
public System.Web.WebPages.HelperResult FolderToc(FolderViewModel folder)
{
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {



#line 160 "..\..\Output\SinglePageRazorTemplate.cshtml"
 
    if (!string.IsNullOrWhiteSpace(folder.Name))
    {
        var statusCounts = folder.DescendantClasses().SelectMany(y => y.Specs.Select(x => x.Status)).ToList();

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "        <span class=\"folderName\">\r\n            <span class=\"folderGlyph\"></span>\r" +
"\n            <span class=\"folderNameText\">");



#line 166 "..\..\Output\SinglePageRazorTemplate.cshtml"
          WriteTo(@__razor_helper_writer, folder.Name);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</span>\r\n            <span class=\"graph\" style=\"");



#line 167 "..\..\Output\SinglePageRazorTemplate.cshtml"
        WriteTo(@__razor_helper_writer, Gradient(statusCounts));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" title=\"");



#line 167 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                        WriteTo(@__razor_helper_writer, Title(statusCounts));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, " in folder \'");



#line 167 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                        WriteTo(@__razor_helper_writer, folder.Name);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\'\"></span>\r\n        </span>\r\n");



#line 169 "..\..\Output\SinglePageRazorTemplate.cshtml"
    }

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    <ul data-tags=\"");



#line 170 "..\..\Output\SinglePageRazorTemplate.cshtml"
WriteTo(@__razor_helper_writer, string.Join(" ", folder.DescendantClasses().SelectMany(x => x.Specs).SelectMany(x => x.EffectiveTags()).Distinct()));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">\r\n");



#line 171 "..\..\Output\SinglePageRazorTemplate.cshtml"
         foreach (var child in folder.SubFolders.OrderBy(x => x.Name))
        {
            var featureClass = folder.DescendantClasses().SelectMany(x => x.Specs).Select(x => x.Status).DefaultIfEmpty(Status.Pending).Max().ToString().ToLowerInvariant();

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "            <li class=\"folder ");



#line 174 "..\..\Output\SinglePageRazorTemplate.cshtml"
WriteTo(@__razor_helper_writer, featureClass);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">\r\n\r\n                ");



#line 176 "..\..\Output\SinglePageRazorTemplate.cshtml"
WriteTo(@__razor_helper_writer, FolderToc(child));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\r\n            </li>\r\n");



#line 178 "..\..\Output\SinglePageRazorTemplate.cshtml"
        }

#line default
#line hidden



#line 179 "..\..\Output\SinglePageRazorTemplate.cshtml"
         foreach (var feature in folder.Classes.OrderBy(x => x.Name))
        {
            var maxStatus = feature.Specs.Select(x => x.Status).DefaultIfEmpty(Status.Pending).Max();
            var featureClass = maxStatus.ToString().ToLowerInvariant();

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "            <li class=\"feature ");



#line 183 "..\..\Output\SinglePageRazorTemplate.cshtml"
WriteTo(@__razor_helper_writer, featureClass);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" title=\"Feature: ");



#line 183 "..\..\Output\SinglePageRazorTemplate.cshtml"
                               WriteTo(@__razor_helper_writer, feature.Name);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, " (");



#line 183 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                              WriteTo(@__razor_helper_writer, maxStatus);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, ")\" data-tags=\"");



#line 183 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                      WriteTo(@__razor_helper_writer, string.Join(" ", feature.Specs.SelectMany(x => x.EffectiveTags()).Distinct()));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">\r\n                <a class=\"featureLink\" href=\"#");



#line 184 "..\..\Output\SinglePageRazorTemplate.cshtml"
               WriteTo(@__razor_helper_writer, AnchorName(feature));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">");



#line 184 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                     WriteTo(@__razor_helper_writer, feature.Name);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</a>\r\n                <ul class=\"scenarios\">\r\n");



#line 186 "..\..\Output\SinglePageRazorTemplate.cshtml"
                     foreach (var spec in feature.Specs.OrderBy(x => x.MethodName))
                    {
                        var scenarioClass = spec.Status.ToString().ToLowerInvariant();

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "                        <li class=\"");



#line 189 "..\..\Output\SinglePageRazorTemplate.cshtml"
    WriteTo(@__razor_helper_writer, scenarioClass);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\" title=\"Scenario: ");



#line 189 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                     WriteTo(@__razor_helper_writer, spec.MethodName);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, " (");



#line 189 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                       WriteTo(@__razor_helper_writer, spec.Status);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, ")\" data-tags=\"");



#line 189 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                                 WriteTo(@__razor_helper_writer, string.Join(" ", spec.EffectiveTags()));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">\r\n                            <a class=\"scenarioLink\" href=\"#");



#line 190 "..\..\Output\SinglePageRazorTemplate.cshtml"
                            WriteTo(@__razor_helper_writer, AnchorName(feature, spec));

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "\">");



#line 190 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                        WriteTo(@__razor_helper_writer, spec.MethodName);

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "</a>\r\n                        </li>\r\n");



#line 192 "..\..\Output\SinglePageRazorTemplate.cshtml"
                    }

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "                </ul>\r\n            </li>\r\n");



#line 195 "..\..\Output\SinglePageRazorTemplate.cshtml"
        }

#line default
#line hidden

WriteLiteralTo(@__razor_helper_writer, "    </ul>\r\n");



#line 197 "..\..\Output\SinglePageRazorTemplate.cshtml"

#line default
#line hidden

});

}


        #line 200 "..\..\Output\SinglePageRazorTemplate.cshtml"


    string AnchorName(TestClassViewModel c, SpecViewModel spec)
    {
        return "Scenario-" + (c.NameSpace + "." + c.Name + "-" + spec.MethodName).Replace(" ", "_");
    }

    string AnchorName(TestClassViewModel c)
    {
        return "Feature-" + (c.NameSpace + "." + c.Name).Replace(" ", "_");
    }


    static readonly Dictionary<Status, string> StatusColours = new Dictionary<Status, string>
    {
        {Status.Passed, "rgba(86, 158, 78, 0.9)"},
        {Status.Failed, "rgba(238, 66, 68, 0.9)"},
        {Status.Skipped, "rgba(245, 184, 81, 0.9)"},
        {Status.Pending, "rgba(245, 220, 95, 0.9)"},
        {Status.NotRun, "transparent"},
    };

    static readonly Status[] HumanOrderedStatuses = {Status.Failed, Status.Passed, Status.Skipped, Status.Pending, Status.NotRun};

    static string Gradient(IEnumerable<Status> statuses)
    {
        double tp = 0;
        var s = "";
        foreach (var status in HumanOrderedStatuses)
        {
            var colour = StatusColours[status];
            s += string.Format(", {0} {1}%", colour, tp);
            tp += statuses.Count(y => y == status)/(double) statuses.Count()*100;
            s += string.Format(", {0} {1}%", colour, tp);
        }


        return "background-image: linear-gradient(to right" + s + ")";
    }


    static string Title(IEnumerable<Status> statuses)
    {
        var v = from s in HumanOrderedStatuses
            let count = statuses.Count(y => y == s)
            where count > 0
            select count + " " + s;

        return string.Join(", ", v);
    }


        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");



WriteLiteral("\r\n");







            
            #line 14 "..\..\Output\SinglePageRazorTemplate.cshtml"
  
    var statusCounts = TemplateModel.RootFolder.DescendantClasses().SelectMany(y => y.Specs.Select(x => x.Status));
    var tags = TemplateModel.Tags.ToList();
    double fattestTagCount = tags.Select(x => x.Statuses.Count()).DefaultIfEmpty(1).Max();


            
            #line default
            #line hidden
WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">\r\n\t<head>\r\n" +
"\t\t<meta charset=\"utf-8\" />\r\n\t\t<title>SpecLight report</title>\r\n\t\t<style type=\"te" +
"xt/css\">\r\n\t\t\t");


            
            #line 25 "..\..\Output\SinglePageRazorTemplate.cshtml"
Write(IncludeEmbeddedResource("Style.min.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t</style>\r\n\t\t<script type=\"text/javascript\">\r\n            ");


            
            #line 28 "..\..\Output\SinglePageRazorTemplate.cshtml"
       Write(IncludeEmbeddedResource("jquery-1.10.2.min.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </script>\r\n\r\n\r\n\r\n\t\t<script type=\"text/javascript\">\r\n            $(funct" +
"ion() {\r\n                //folder collapsing\r\n                $(\"li.folder > spa" +
"n.folderName\").click(function() {\r\n                    $(this).parent().toggleCl" +
"ass(\"collapsed\");\r\n                });\r\n\r\n                //highlight current it" +
"em\r\n                function updateHighlight() {\r\n                    $(\"#TableO" +
"fContents a\").removeClass(\"current\");\r\n                    $(\"h2[id], h3[id]\").f" +
"ilter(\":visible\").filter(function() {\r\n                        var elemTop = $(t" +
"his).offset().top;\r\n                        return elemTop >= 0;\r\n              " +
"      }).first().each(function() {\r\n                        $(\"#TableOfContents " +
"a[href=\'#\" + this.id + \"\']\").addClass(\"current\");\r\n                    });\r\n    " +
"            }\r\n\r\n                $(\"#Content\").scroll(updateHighlight);\r\n       " +
"         updateHighlight();\r\n\r\n                //tag behaviour\r\n                " +
"$(\"input[data-tag-controller]\").change(function() {\r\n                    var sel" +
"ectedTags = $(\"input[data-tag-controller]:checked\").map(function(i, d) { return " +
"$(d).data(\"tag-controller\"); });\r\n                    if (selectedTags.size()) {" +
"\r\n                        $(\"*[data-tags]\").hide();\r\n                        sel" +
"ectedTags.each(function() { $(\"*[data-tags~=\'\" + this + \"\']\").show(); });\r\n     " +
"               } else {\r\n                        $(\"*[data-tags]\").show();\r\n    " +
"                }\r\n                    updateHighlight();\r\n                });\r\n" +
"            });\r\n        </script>\r\n\t</head>\r\n\t<body>\r\n\t\t<div id=\"TableOfContent" +
"s\">\r\n\t\t\t<div class=\"graph\" style=\"");


            
            #line 70 "..\..\Output\SinglePageRazorTemplate.cshtml"
                        Write(Gradient(statusCounts));

            
            #line default
            #line hidden
WriteLiteral("\" title=\"Status breakdown for all scenarios\">");


            
            #line 70 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                                            Write(Title(statusCounts));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\t\t\t<div class=\"tagCloud\">\r\n");


            
            #line 72 "..\..\Output\SinglePageRazorTemplate.cshtml"
 				foreach (var tag in tags)
				{
					var fatness = (tag.Statuses.Count() - 1)/fattestTagCount;
					var size = 90 + fatness*60;


            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t<input id=\"tagCheckbox-");


            
            #line 77 "..\..\Output\SinglePageRazorTemplate.cshtml"
                       Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("\" type=\"checkbox\" data-tag-controller=\"");


            
            #line 77 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                       Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("\"/>\r\n");



WriteLiteral("\t\t\t\t\t<label for=\"tagCheckbox-");


            
            #line 78 "..\..\Output\SinglePageRazorTemplate.cshtml"
                        Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("\" title=\"Tag \'");


            
            #line 78 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                               Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("\' (");


            
            #line 78 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                           Write(Title(tag.Statuses));

            
            #line default
            #line hidden
WriteLiteral(") - Click to filter\" style=\"");


            
            #line 78 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                                                           Write(Gradient(tag.Statuses));

            
            #line default
            #line hidden
WriteLiteral("; font-size: ");


            
            #line 78 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                                                                                                Write(size);

            
            #line default
            #line hidden
WriteLiteral("%\">");


WriteLiteral("@");


            
            #line 78 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                                                                                                           Write(tag.Name);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");


            
            #line 79 "..\..\Output\SinglePageRazorTemplate.cshtml"
				}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t</div>\r\n\t\t\t");


            
            #line 81 "..\..\Output\SinglePageRazorTemplate.cshtml"
Write(FolderToc(TemplateModel.RootFolder));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\t\t</div>\r\n\t\t<div id=\"Content\">\r\n\t\t\t<h1>Speclight report</h1>\r\n\r\n");


            
            #line 87 "..\..\Output\SinglePageRazorTemplate.cshtml"
 			foreach (var testClass in TemplateModel.RootFolder.DescendantClasses())
			{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<div class=\"feature\" data-tags=\"");


            
            #line 89 "..\..\Output\SinglePageRazorTemplate.cshtml"
                               Write(string.Join(" ", testClass.Specs.SelectMany(x => x.EffectiveTags()).Distinct()));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\t\t\t\t\t<h2 id=\"");


            
            #line 90 "..\..\Output\SinglePageRazorTemplate.cshtml"
        Write(AnchorName(testClass));

            
            #line default
            #line hidden
WriteLiteral("\">Class: ");


            
            #line 90 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                       Write(testClass.Name);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\t\t\t\t\t");


            
            #line 91 "..\..\Output\SinglePageRazorTemplate.cshtml"
Write(TagBox(testClass.Specs.SelectMany(x => x.EffectiveTags()).Distinct()));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 92 "..\..\Output\SinglePageRazorTemplate.cshtml"
 					if (testClass.Description != null)
					{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<div class=\"class-description markdown-host\">\r\n\t\t\t\t\t\t\t");


            
            #line 95 "..\..\Output\SinglePageRazorTemplate.cshtml"
  Write(RenderMarkdown(testClass.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t</div>\r\n");


            
            #line 97 "..\..\Output\SinglePageRazorTemplate.cshtml"
					}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\r\n");


            
            #line 99 "..\..\Output\SinglePageRazorTemplate.cshtml"
 					foreach (var spec in testClass.Specs.OrderBy(x => x.MethodName))
					{
						var firstError = spec.Spec.Outcomes.Select(x => x.Error).FirstOrDefault(x => x != null);

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<div class=\"scenario ");


            
            #line 102 "..\..\Output\SinglePageRazorTemplate.cshtml"
                      Write(spec.Status.ToString().ToLowerInvariant());

            
            #line default
            #line hidden
WriteLiteral("\" data-tags=\"");


            
            #line 102 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                             Write(string.Join(" ", spec.EffectiveTags()));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\t\t\t\t\t\t\t<h3 id=\"");


            
            #line 103 "..\..\Output\SinglePageRazorTemplate.cshtml"
          Write(AnchorName(testClass, spec));

            
            #line default
            #line hidden
WriteLiteral("\">Method: ");


            
            #line 103 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                Write(spec.MethodName);

            
            #line default
            #line hidden
WriteLiteral("  (");


            
            #line 103 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                   Write(spec.Status.ToString());

            
            #line default
            #line hidden
WriteLiteral(")</h3>\r\n\t\t\t\t\t\t\t");


            
            #line 104 "..\..\Output\SinglePageRazorTemplate.cshtml"
  Write(TagBox(spec.Spec.SpecTags));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t<p class=\"description markdown-host\">");


            
            #line 105 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                       Write(RenderMarkdown(spec.Spec.Description));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\t\t\t\t\t\t\t");


            
            #line 106 "..\..\Output\SinglePageRazorTemplate.cshtml"
  Write(ExtraData(spec.Spec.DataDictionary));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t<ul>\r\n");


            
            #line 108 "..\..\Output\SinglePageRazorTemplate.cshtml"
 								foreach (var o in spec.Spec.Outcomes)
								{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t<li class=\"");


            
            #line 110 "..\..\Output\SinglePageRazorTemplate.cshtml"
               Write(o.Status.ToString().ToLowerInvariant());

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 110 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                        Write(o.Empty?"empty":"");

            
            #line default
            #line hidden
WriteLiteral("\" title=\"");


            
            #line 110 "..\..\Output\SinglePageRazorTemplate.cshtml"
                                                                                     Write(o.Error);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n\t\t\t\t\t\t\t\t\t\t<em>");


            
            #line 111 "..\..\Output\SinglePageRazorTemplate.cshtml"
         Write(o.Step.Type);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n\t\t\t\t\t\t\t\t\t\t");


            
            #line 112 "..\..\Output\SinglePageRazorTemplate.cshtml"
     Write(o.Step.Description);

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 113 "..\..\Output\SinglePageRazorTemplate.cshtml"
 										if (o.Empty)
										{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t<strong title=\"Test step contained no code\">(Empty)</strong>\r\n");


            
            #line 116 "..\..\Output\SinglePageRazorTemplate.cshtml"
										}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t\t\t");


            
            #line 117 "..\..\Output\SinglePageRazorTemplate.cshtml"
     Write(TagBox(o.Step.Tags));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t");


            
            #line 118 "..\..\Output\SinglePageRazorTemplate.cshtml"
     Write(ExtraData(o.Step.DataDictionary));

            
            #line default
            #line hidden
WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t</li>\r\n");


            
            #line 120 "..\..\Output\SinglePageRazorTemplate.cshtml"
								}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t</ul>\r\n");


            
            #line 122 "..\..\Output\SinglePageRazorTemplate.cshtml"
 							if (firstError != null)
							{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t\t<pre class=\"errorMessage\">");


            
            #line 124 "..\..\Output\SinglePageRazorTemplate.cshtml"
                             Write(firstError);

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n");


            
            #line 125 "..\..\Output\SinglePageRazorTemplate.cshtml"
							}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t</div>\r\n");


            
            #line 127 "..\..\Output\SinglePageRazorTemplate.cshtml"
					}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</div>\r\n");


            
            #line 129 "..\..\Output\SinglePageRazorTemplate.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n\r\n\t</body>\r\n</html>\r\n\r\n");



WriteLiteral("\r\n\r\n");



WriteLiteral("\r\n\r\n");



WriteLiteral("\r\n\r\n");



WriteLiteral("\r\n\r\n");


WriteLiteral("\r\n");


        }
    }
}
#pragma warning restore 1591
