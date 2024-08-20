namespace IODDFinder.Models;

public class DriversResponse
{
    public List<Content> Content { get; set; }
    public int Number { get; set; }
    public int Size { get; set; }
    public int NumberOfElements { get; set; }
    public List<object> Sort { get; set; }
    public bool First { get; set; }
    public bool Last { get; set; }
    public int TotalPages { get; set; }
    public int TotalElements { get; set; }
}

public class Content
{
    public bool HasMoreVersions { get; set; }
    public int DeviceId { get; set; }
    public string IoLinkRev { get; set; }
    public string VersionString { get; set; }
    public int IoddId { get; set; }
    public string ProductId { get; set; }
    public int ProductVariantId { get; set; }
    public string ProductName { get; set; }
    public string VendorName { get; set; }
    public object UploadDate { get; set; }
    public int VendorId { get; set; }
    public string IoddStatus { get; set; }
    public string IndicationOfSource { get; set; }
    public bool HasMd { get; set; }
    public string DriverName { get; set; }
    public Md Md { get; set; }
    public string Icon => $"https://ioddfinder.io-link.com/api/productvariants/{ProductVariantId}/files/icon";
}

public class Md
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string Revision { get; set; }
    public object ReleasedAt { get; set; }
    public object UpdatedAt { get; set; }
}