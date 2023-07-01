namespace Worker.Helpers
{
    public class ConnectionStringsConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new();
    }

    public class ConnectionStrings
    {
        public string MongoDB { get; set; } = string.Empty;
    }
}