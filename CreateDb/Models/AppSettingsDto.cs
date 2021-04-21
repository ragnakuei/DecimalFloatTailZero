namespace CreateDb.Models
{
    public class AppSettingsDto
    {
        public AppSettingsDbDto Db { get; set; }
    }

    public class AppSettingsDbDto
    {
        public string DataBaseName { get; set; }

        public string DefaultSchema { get; set; }

        public string Collation { get; set; }
    }
}
