#pragma checksum "/home/ryota/Documents/Absence/Views/Admin/AdminDash.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fad93cfe4eaadd5f204172e049b99f48d969930d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminDash), @"mvc.1.0.view", @"/Views/Admin/AdminDash.cshtml")]
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
#line 1 "/home/ryota/Documents/Absence/Views/_ViewImports.cshtml"
using Absence;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/ryota/Documents/Absence/Views/_ViewImports.cshtml"
using Absence.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fad93cfe4eaadd5f204172e049b99f48d969930d", @"/Views/Admin/AdminDash.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4de9407ab6e3d93f9b0b092e4f7fe6fdca655c15", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminDash : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Absence.Models.Admin>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/ryota/Documents/Absence/Views/Admin/AdminDash.cshtml"
  
    ViewData["Title"] = "Admin Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Hello Admin</h1>


<div class=""row mt-4"">
	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les absences</h5>
		    <p class=""card-text"">Liste d’absence des étudiants par filière</p>
		    <a href=""#"" class=""btn btn-success"">Start</a>
		  </div>
			</div>
	</div>


	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les absences</h5>
		    <p class=""card-text"">Ajouter une absence d’un étudiant</p>
		    <a href=""#"" class=""btn btn-primary"">Start</a>
		 </div>
	</div>
	</div>

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les absences</h5>
		    <p class=""card-text"">Supprimer absence</p>
		    <a href=""#"" class=""btn btn-warning"">Start</a>
		 </div>
	</div>
	</div>


</div>


<div class=""row mt-4"">

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  ");
            WriteLiteral(@"<div class=""card-body"">
		    <h5 class=""card-title"">Gestion du compte</h5>
		    <p class=""card-text"">créer un nouveau compte</p>
		    <a href=""#"" class=""btn btn-secondary"">Start</a>
		 </div>
	</div>
	</div>


	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gestion du compte</h5>
		    <p class=""card-text"">modification du compte</p>
		    <a href=""#"" class=""btn btn-info"">Start</a>
		 </div>
	</div>
	</div>

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gestion du compte</h5>
		    <p class=""card-text"">consultation du compte</p>
		    <a href=""#"" class=""btn btn-secondary"">Start</a>
		 </div>
	</div>
	</div>





</div>


<div class=""row mt-4"">

<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les absences</h5>
		    <p class=""card-text"">exporter liste d’absence<</p>
		    <a hr");
            WriteLiteral(@"ef=""#"" class=""btn btn-success"">Start</a>
		 </div>
	</div>
	</div>


	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les absences</h5>
		    <p class=""card-text"">modifier absence d’un étudiant</p>
		    <a href=""#"" class=""btn btn-danger"">Start</a>
		 </div>
	</div>
	</div>

</div>

<div class=""row mt-4"">


	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les étudiants par filière</h5>
		    <p class=""card-text"">ajoute Etudiant à une liste</p>
		    <a href=""#"" class=""btn btn-warning"">Start</a>
		 </div>
	</div>
	</div>

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les étudiants par filière</h5>
		    <p class=""card-text"">import liste étudiant</p>
		    <a href=""#"" class=""btn btn-danger"">Start</a>
		 </div>
	</div>
	</div>


	<div class=""col-md-4"">
		<div class=""card");
            WriteLiteral(@""" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les étudiants par filière</h5>
		    <p class=""card-text"">export liste étudiant</p>
		    <a href=""#"" class=""btn btn-primary"">Start</a>
		 </div>
	</div>
	</div>





</div>


<div class=""row mt-4"">

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer l’absence d’un étudiant</h5>
		    <p class=""card-text"">Justifier absence</p>
		    <a href=""#"" class=""btn btn-secondary"">Start</a>
		 </div>
	</div>
	</div>

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer l’absence d’un étudiant</h5>
		    <p class=""card-text"">consulter les absences</p>
		    <a href=""#"" class=""btn btn-info"">Start</a>
		 </div>
	</div>
	</div>

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer l’absence d’un étudiant</h5>");
            WriteLiteral(@"
		    <p class=""card-text"">import un certificat médical</p>
		    <a href=""#"" class=""btn btn-success"">Start</a>
		 </div>
	</div>
	</div>






</div>



<div class=""row mt-4"">

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer l’absence d’un étudiant</h5>
		    <p class=""card-text"">notice d’absence</p>
		    <a href=""#"" class=""btn btn-primary"">Start</a>
		 </div>
	</div>
	</div>


		<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les filières</h5>
		    <p class=""card-text"">Ajouter une nouvelle filière</p>
		    <a href=""#"" class=""btn btn-primary"">Start</a>
		 </div>
	</div>
	</div>

	<div class=""col-md-4"">
		<div class=""card"" style=""width: 18rem;"">
		  <div class=""card-body"">
		    <h5 class=""card-title"">Gérer les filières</h5>
		    <p class=""card-text"">Imprimer fiche d’absence d’une filière</p>
		    <a href=""#"" class=""btn btn-primary"">Start</a>
");
            WriteLiteral("\t\t </div>\n\t</div>\n\t</div>\n\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Absence.Models.Admin> Html { get; private set; }
    }
}
#pragma warning restore 1591