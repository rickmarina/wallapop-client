using System.Web;

public class QueryModel {

    public string? latitude { get; set; }
    public string? longitude { get; set; }
    public string? keywords { get; set; }
    public string filter_source  { get; set; } = "search_box";
    public int start { get; set; } = 0;
    public int items_count { get; set; } = 10; //default is 40

    public string BuildQuery() { 
        List<string> q = new(); 
        
        if (!string.IsNullOrEmpty(filter_source))
            q.Add($"{nameof(filter_source)}={filter_source}");
        if (!string.IsNullOrEmpty(keywords))
            q.Add($"{nameof(keywords)}={Uri.EscapeDataString(keywords)}");
        if (!string.IsNullOrEmpty(longitude))    
            q.Add($"{nameof(longitude)}={longitude}");
        if (!string.IsNullOrEmpty(latitude)) 
            q.Add($"{nameof(latitude)}={latitude}");

        q.Add($"{nameof(start)}={start}");
        q.Add($"{nameof(items_count)}={items_count}");

        string query = string.Join("&", q);
        return $"?{query}";

    }

}