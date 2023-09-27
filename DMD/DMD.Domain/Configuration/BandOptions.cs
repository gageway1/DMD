using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Domain.Configuration
{
    public sealed class BandOptions
    {
        public const string SettingsName = "Band";

        public string ApiKey { get; set; } = string.Empty;
        public string TenantId { get; set; } = string.Empty;
    }
}
