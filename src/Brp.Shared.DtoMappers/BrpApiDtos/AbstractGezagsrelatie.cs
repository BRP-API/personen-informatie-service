namespace Brp.Shared.DtoMappers.BrpApiDtos;

[Newtonsoft.Json.JsonConverter(typeof(JsonInheritanceConverter), "type")]
[JsonInheritanceAttribute("TweehoofdigOuderlijkGezag", typeof(TweehoofdigOuderlijkGezag))]
[JsonInheritanceAttribute("EenhoofdigOuderlijkGezag", typeof(EenhoofdigOuderlijkGezag))]
[JsonInheritanceAttribute("GezamenlijkGezag", typeof(GezamenlijkGezag))]
[JsonInheritanceAttribute("Voogdij", typeof(Voogdij))]
[JsonInheritanceAttribute("GezagNietTeBepalen", typeof(GezagNietTeBepalen))]
[JsonInheritanceAttribute("TijdelijkGeenGezag", typeof(TijdelijkGeenGezag))]
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.1.0.0 (NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class AbstractGezagsrelatie
{
    [Newtonsoft.Json.JsonProperty("minderjarige", Required = Newtonsoft.Json.Required.Always)]
    public Minderjarige Minderjarige { get; set; } = new Minderjarige();

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.1.0.0 (NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0))")]
public partial class TijdelijkGeenGezag : AbstractGezagsrelatie
{
}
