using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ui4Vagrant.Support
{
    class MachinesIndex
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("machines")]
        public Dictionary<string, VirtualMachine> Machines { get; set; }
    }
}
