using System;
using System.Threading.Tasks;
using ExampleProject.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ExampleProject.Components
{
    public class ExampleViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(ExampleComponentParameters parameters)
        {
            switch (parameters.ViewMode)
            {
                case ViewMode.HTML:
                    return View("Default", parameters);
                case ViewMode.Scripts:
                    return View("Scripts", parameters);
                case ViewMode.Styles:
                    return View("Styles", parameters);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class ExampleComponentParameters
    {
        public ViewMode ViewMode { get; set; } = ViewMode.HTML;
        public string UniqueID { get; set; } = new Guid().ToString().Replace("-", "");
        public string CssClass { get; set; } = "alert alert-primary";
        public string CustomStyle { get; set; }
    }
}