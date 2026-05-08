namespace MyApp.Core.Options
{
    public class MockiApiOptions
    {
        public const string SectionName = "ExternalApis:Mocki";

        public string BaseAddress { get; set; } = "";
        public string DataPath { get; set; } = "";
    }
}
