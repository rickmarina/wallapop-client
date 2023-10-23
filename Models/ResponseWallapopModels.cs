
    public class Flags
    {
        public bool pending { get; set; }
        public bool sold { get; set; }
        public bool reserved { get; set; }
        public bool banned { get; set; }
        public bool expired { get; set; }
        public bool onhold { get; set; }
    }

    public class Image
    {
        public string? original { get; set; }
        public string? xsmall { get; set; }
        public string? small { get; set; }
        public string? large { get; set; }
        public string? medium { get; set; }
        public string? xlarge { get; set; }
        public int original_width { get; set; }
        public int original_height { get; set; }
    }

    public class Image2
    {
        public string? original { get; set; }
        public string? xsmall { get; set; }
        public string? small { get; set; }
        public string? large { get; set; }
        public string? medium { get; set; }
        public string? xlarge { get; set; }
        public int original_width { get; set; }
        public int original_height { get; set; }
    }

    public class Location
    {
        public string? postal_code { get; set; }
        public string? country_code { get; set; }
        public string? city { get; set; }
    }

    public class ResponseWallapopModel
    {
        public List<SearchObject>? search_objects { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public bool distance_ordered { get; set; }
        public string? keywords { get; set; }
        public string? order { get; set; }
        public string? bubble { get; set; }
        public SearchPoint? search_point { get; set; }
    }

    public class SearchObject
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public double distance { get; set; }
        public List<Image>? images { get; set; }
        public User? user { get; set; }
        public Flags? flags { get; set; }
        public VisibilityFlags? visibility_flags { get; set; }
        public double price { get; set; }
        public string? currency { get; set; }
        public bool free_shipping { get; set; }
        public string? web_slug { get; set; }
        public int category_id { get; set; }
        public Shipping? shipping { get; set; }
        public bool supports_shipping { get; set; }
        public bool shipping_allowed { get; set; }
        public string? seller_id { get; set; }
        public bool favorited { get; set; }
        public object? creation_date { get; set; }
        public object? modification_date { get; set; }
        public Location? location { get; set; }
        public TypeAttributes? type_attributes { get; set; }
        public List<int>? taxonomy { get; set; }
        public object? discount { get; set; }
    }

    public class SearchPoint
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Shipping
    {
        public bool item_is_shippable { get; set; }
        public bool user_allows_shipping { get; set; }
        public string? cost_configuration_id { get; set; }
    }

    public class TypeAttributes
    {
    }

    public class User
    {
        public string? micro_name { get; set; }
        public string? id { get; set; }
        public Image? image { get; set; }
        public bool online { get; set; }
        public string? kind { get; set; }
    }

    public class VisibilityFlags
    {
        public bool bumped { get; set; }
        public bool highlighted { get; set; }
        public bool urgent { get; set; }
        public bool country_bumped { get; set; }
        public bool boosted { get; set; }
    }

