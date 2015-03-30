namespace _07.ImportFromJson
{
    using Newtonsoft.Json;

    public class Peak
    {
        public Peak(string name, int el)
        {
            this.PeakName = name;
            this.Elevation = el;
        }

        public string PeakName { get; set; }

        public int Elevation { get; set; }
    }
}
