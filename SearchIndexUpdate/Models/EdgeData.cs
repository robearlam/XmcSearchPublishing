namespace XmcSearchPublishing.SearchIndexUpdate.Models
{
    public class EdgeData
    {
        public EdgeItem Item { get; set; }
    }

    public class EdgeItem
    {
        public RenderedItem Rendered { get; set; }
    }

    public class RenderedItem
    {
        public SitecoreData Sitecore { get; set; }
    }

    public class SitecoreData
    {
        public ContextData Context { get; set; }
        public RouteData Route{ get; set; }
    }

    public class RouteData
    {
    }

    public class ContextData
    {
        public bool PageEditing { get; set; }
        public SiteData Site { get; set; }
        public string PageState { get; set; }
        public string Language { get; set; }
        public string ItemPath { get; set; }
    }

    public class SiteData
    {
        public string name { get; set; }
    }
}
