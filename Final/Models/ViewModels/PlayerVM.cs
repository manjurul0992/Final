using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final.Models.ViewModels
{
    public class PlayerVM
    {
        public PlayerVM()
        {
            this.FormatList = new List<int>();
        }

        public int PlayerId { get; set; }
        public string? PlayerName { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; }
        public IFormFile? PicturePath { get; set; }
        public bool MaritalStatus { get; set; }

        public List<int> FormatList { get; set; }
    }
}
