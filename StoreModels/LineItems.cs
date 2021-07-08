using System;

namespace StoreModels
{
    public class LineItems
    {
        public int Id { get; set; }
        public int FkId { get; set; }
        public Products Product { get; set; }
        public int Count { get; set; }
        public LineItems()
        {
            
        }
    }
}