using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.BotExample.Settings
{
    public class SettingsModel
    {
        [YamlProperty("BotExample.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("BotExample.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("BotExample.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
