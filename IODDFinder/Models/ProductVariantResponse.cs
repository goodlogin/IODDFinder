namespace IODDFinder.Models;

public class ProductVariantResponse
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public Product? Product { get; set; }
    public Iodd? Iodd { get; set; }
    public Vendor? Vendor { get; set; }
}

public class Iodd
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public string? DeviceFamily { get; set; }
    public string? DeviceName { get; set; }
    public long UploadDate { get; set; }
    public long ReleaseDate { get; set; }
    public string? IoLinkRev { get; set; }
    public string? Version { get; set; }
    public string? Status { get; set; }
    public string? IndicationOfSource { get; set; }
    public string? DriverName { get; set; }
    public Vendor? Vendor { get; set; }
    public ProductVariantMd? Md { get; set; }
    public bool HasMd { get; set; }
}

public class ProductVariantMd
{
}

public class Product
{
    public string? ProductId { get; set; }
}

public class Vendor
{
    public string? Name { get; set; }
    public int VendorId { get; set; }
    public string? Url { get; set; }
}