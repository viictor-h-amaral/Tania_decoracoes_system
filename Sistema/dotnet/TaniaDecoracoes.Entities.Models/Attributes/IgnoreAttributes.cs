namespace TaniaDecoracoes.Entities.Models.Attributes
{

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreOnFormAttribute : Attribute
    {
        public string? Reason { get; }

        public IgnoreOnFormAttribute() { }

        public IgnoreOnFormAttribute(string reason)
        {
            Reason = reason;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreOnGridAttribute : Attribute
    {
        public string? Reason { get; }

        public IgnoreOnGridAttribute() { }

        public IgnoreOnGridAttribute(string reason)
        {
            Reason = reason;
        }
    }
}
