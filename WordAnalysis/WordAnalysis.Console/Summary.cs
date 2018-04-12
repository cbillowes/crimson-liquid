namespace WordAnalysis.Console
{
    public class Summary
    {
        public Summary(string file, float fileSize, float milliSeconds)
        {
            File = file;
            FileSize = fileSize;
            MilliSeconds = milliSeconds;
        }

        public string File { get; set; }
        public float FileSize { get; set; }
        public float MilliSeconds { get; set; }
    }
}
