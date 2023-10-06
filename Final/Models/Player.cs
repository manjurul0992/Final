using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public partial class Player
    {
        public Player()
        {
            SeriesEntries = new HashSet<SeriesEntry>();
        }

        public int PlayerId { get; set; }
        public string? PlayerName { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; }
        public bool MaritalStatus { get; set; }

        public virtual ICollection<SeriesEntry> SeriesEntries { get; set; }
    }
}
