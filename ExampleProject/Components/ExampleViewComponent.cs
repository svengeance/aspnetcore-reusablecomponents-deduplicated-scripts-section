using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using ExampleProject.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ExampleProject.Components
{
    public class ExampleViewComponent : ComponentBase<ExampleComponentParameters>
    {
        public ExampleViewComponent(ComponentContext context) : base(context)
        {
        }

        protected override void OnInvoke(ViewMode viewMode)
        {
            Console.WriteLine($"Instantiated ExampleViewComponent for mode {viewMode.ToString()}");
        }
    }

    public class ExampleComponentParameters: ComponentParameterBase
    {
        public string CssClass { get; set; } = "alert alert-primary";
        public string CustomStyle { get; set; }
    }
}