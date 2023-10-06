using System;
using System.Collections.Generic;

namespace Final.Models
{
    public partial class Format
    {
        public Format()
        {
            SeriesEntries = new HashSet<SeriesEntry>();
        }

        public int FormatId { get; set; }
        public string? FormatName { get; set; }

        public virtual ICollection<SeriesEntry> SeriesEntries { get; set; }
    }
}
