using System;
using System.Collections;

namespace _07.ImportFromJson
{
    using Newtonsoft.Json;
using System.Collections.Generic;

    public class MountainJ
    {
        private ICollection<Peak> peaks;
        private ICollection<string> countries;

        public MountainJ(string name)
        {
            this.mountainName = name;
            this.peaks = new HashSet<Peak>();
            this.countries = new List<string>();
        }

        [JsonProperty("mountainName")]
        public string mountainName { get; set; }

        [JsonProperty("peaks")]
        public ICollection<Peak> Peaks
        {
            get { return this.peaks; }
            set { this.peaks = value; }
        }

        [JsonProperty("countries")]
        public ICollection<string> Countries
        {
            get { return this.countries; }
            set { this.countries = value; }
        }
    }
}
