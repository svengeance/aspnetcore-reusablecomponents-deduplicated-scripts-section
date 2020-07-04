using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ExampleProject.Components;
using ExampleProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ExampleProject.Core
{
    public abstract class ComponentBase<T>: ComponentBase where T: ComponentParameterBase
    {
        protected T Parameters { get; set; }

        protected ComponentBase(ComponentContext componentContext) : base(componentContext) { }

        protected override ViewViewComponentResult InvokeWithParameter(ViewMode viewMode, ComponentParameterBase parameters = null) =>
            viewMode switch
            {
                ViewMode.HTML    => View("Default", Parameters),
                ViewMode.Scripts => View("Scripts", Parameters),
                ViewMode.Styles  => View("Styles", Parameters),
                _                => throw new ArgumentOutOfRangeException()
            };

        public ViewViewComponentResult Invoke(T parameters)
        {
            Parameters ??= parameters;
            Id = parameters.Id;
            return InvokeCore(ViewMode.HTML, parameters);
        }
    }

    public abstract class ComponentBase: ViewComponent
    {
        protected readonly ComponentContext ComponentContext;

        public int Id { get; protected set; }

        protected ComponentBase(ComponentContext componentContext)
        {
            ComponentContext = componentContext;
        }

        public ViewViewComponentResult InvokeForSection(ViewMode viewMode)
        {
            OnInvoke(viewMode);

            return InvokeWithParameter(viewMode);
        }

        protected ViewViewComponentResult InvokeCore(ViewMode viewMode, ComponentParameterBase parameters)
        {
            OnInvoke(viewMode);

            var result = InvokeWithParameter(viewMode, parameters);
            ComponentContext.RegisteredComponents.Add(this);
            return result;
        }

        protected abstract ViewViewComponentResult InvokeWithParameter(ViewMode viewMode, ComponentParameterBase parameters = null);

        protected abstract void OnInvoke(ViewMode viewMode);
    }
}