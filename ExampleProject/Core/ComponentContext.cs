using System.Collections.Generic;

namespace ExampleProject.Core
{
    public class ComponentContext
    {
        public HashSet<string> RanScripts { get; } = new HashSet<string>();

        public List<ComponentBase> RegisteredComponents { get; } = new List<ComponentBase>();
    }
}