namespace MyApp.Core.Options
{
    public class JokeApiOptions
    {
        public const string SectionName = "ExternalApis:Joke";

        public string BaseAddress { get; set; } = "";
        public string RandomJokePath { get; set; } = "";
    }
}
