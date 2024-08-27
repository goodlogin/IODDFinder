using System.Text.Json.Serialization;

namespace IODDFinder.Models;

public class ProductVariantMenuResponse : BaseResponse
{
    public List<Menu>? Menus { get; set; }
}

public record Button
{
    public required string ButtonValue { get; set; }
}

public class Child
{
    public string AccessRightRestriction { get; set; }
    public string Id { get; set; }
    public string DefaultValue { get; set; }
    public string FixedLengthRestriction { get; set; }
    public string Index { get; set; }
    public string AccessRights { get; set; }
    public string Mandatory { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Datatype Datatype { get; set; }
    public List<Child> Children { get; set; }
    public string ExcludedFromDataStorage { get; set; }
    public Feature Feature { get; set; }
    public List<object> Profile { get; set; }
    public CommunicationCharacteristic CommunicationCharacteristic { get; set; }
    public List<SupportedProductVariant> SupportedProductVariants { get; set; }
    public List<object> SupportedDeviceIds { get; set; }
    public Condition Condition { get; set; }
    public string Bitrate { get; set; }
    public string MinCycleTime { get; set; }
    public string SioSupported { get; set; }
    public string MSequenceCapability { get; set; }
    public string Subindex { get; set; }
    public string BitOffset { get; set; }
    public string Value { get; set; }
    public string RawValue { get; set; }
    public string DisplayFormat { get; set; }
    public string Dynamic { get; set; }
    public string ModifiesOtherVariables { get; set; }
    public Button Button { get; set; }

    [JsonPropertyName("x-displayedValue")]
    public string XDisplayedValue { get; set; }
    public string BitLength { get; set; }
    public string ConnectionSymbol { get; set; }
    public List<Product> Products { get; set; }
    public string LowerValue { get; set; }
    public string UpperValue { get; set; }
    public string RawLowerValue { get; set; }
    public string RawUpperValue { get; set; }

    [JsonPropertyName("{http://www.w3.org/2001/XMLSchema-instance}type")]
    public string Httpwwww3org2001XMLSchemainstancetype { get; set; }
    public string Function { get; set; }
    public string Color { get; set; }
    public string Parameter { get; set; }
    public string DataStorage { get; set; }
    public string LocalParameterization { get; set; }
    public string LocalUserInterface { get; set; }
}

public class CommunicationCharacteristic
{
    [JsonPropertyName("{http://www.w3.org/2001/XMLSchema-instance}type")]
    public string Httpwwww3org2001XMLSchemainstancetype { get; set; }
    public string IolinkRevision { get; set; }
    public string Bitrate { get; set; }
    public string MinCycleTime { get; set; }
    public string SioSupported { get; set; }
    public string MSequenceCapability { get; set; }
    public string ProcessDataInput { get; set; }
    public string ProcessDataOutput { get; set; }
    public string IsduSupport { get; set; }
}

public class Condition
{
    public string VariableId { get; set; }
    public string Subindex { get; set; }
    public string Value { get; set; }
    public string Name { get; set; }
    public string ValueName { get; set; }
}

public class Datatype
{
    public string Type { get; set; }
    public string FixedLength { get; set; }
    public string Encoding { get; set; }
    public List<Child> Children { get; set; }
    public string BitLength { get; set; }
    public string SubindexAccessSupported { get; set; }
    public string Id { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public string BlockParameter { get; set; }
    public string DataStorage { get; set; }
    public List<Child> Children { get; set; }
}

public class Menu
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Child> Children { get; set; }
}

public class SupportedProductVariant
{
    public string ProductId { get; set; }
    public string Name { get; set; }
}