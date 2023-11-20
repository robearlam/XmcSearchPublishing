using System;
using System.Threading.Tasks;
using XmcSearchPublishing.SearchIndexUpdate.Models;

namespace XmcSearchPublishing.SearchIndexUpdate.Edge
{
    public interface IEdgeDataRetriever
    {
        Task<EdgeData> GetEdgeData(Guid rootItemId, bool deep);        
    }
}