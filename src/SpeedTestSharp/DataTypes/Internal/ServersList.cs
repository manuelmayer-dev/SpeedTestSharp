using System.Xml.Serialization;

namespace SpeedTestSharp.DataTypes.Internal
{
    [XmlRoot("settings")]
    public class ServersList
    {
        [XmlArray("servers")]
        [XmlArrayItem("server")]
        public Server[]? Servers { get; set; }
    }
}