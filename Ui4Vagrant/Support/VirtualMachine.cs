using Newtonsoft.Json;

namespace Ui4Vagrant.Support
{
    public class VirtualMachine
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("vagrantfile_path")]
        public string VagrantFilePath { get; set; }
    }
}
