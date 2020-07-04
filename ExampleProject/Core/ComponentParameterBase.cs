using System.Runtime.Serialization;
using ExampleProject.Extensions;

namespace ExampleProject.Core
{
    public class ComponentParameterBase
    {
        [IgnoreDataMember] public int Id => this.ValueHashCode();
    }
}