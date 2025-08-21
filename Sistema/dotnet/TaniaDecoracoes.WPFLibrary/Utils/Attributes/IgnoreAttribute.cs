namespace TaniaDecoracoes.WPFLibrary.Utils.Attributes
{

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreAttribute : Attribute
    {
        public string? Reason { get; }

        public IgnoreAttribute() { }

        public IgnoreAttribute(string reason)
        {
            Reason = reason;
        }
    }
}
