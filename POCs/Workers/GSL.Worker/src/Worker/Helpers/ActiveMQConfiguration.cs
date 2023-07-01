namespace Worker.Helpers
{
    public class ActiveMQConfiguration
    {
        public ActiveMq ActiveMq { get; set; } = new();
    }

    public class ActiveMq
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}