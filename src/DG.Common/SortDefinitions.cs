using System.Collections.Generic;

namespace DG.Common
{
    public class SortDefinitions
    {
        private readonly List<SortItem> _softItems = new List<SortItem>();
        public List<SortItem> SoftItems
        {
            get { return _softItems; }
        }
    }
}
