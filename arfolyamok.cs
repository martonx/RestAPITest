using System.Xml.Serialization;

namespace Test20240430;

[Serializable()]
[XmlRoot(Namespace = "", IsNullable = false)]
public class arfolyamok
{
    public arfolyamokDeviza deviza { get; set; }
}

[Serializable()]
public class arfolyamokDeviza
{
    public arfolyamokDevizaItem item { get; set; }
}

[Serializable()]
public class arfolyamokDevizaItem
{
    public string bank { get; set; }

    public string datum { get; set; }

    public string penznem { get; set; }

    [XmlElement("kozep")]
    public decimal[] kozep { get; set; }
}
