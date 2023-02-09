using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITRI_Project.Model
{
    public class Map
    {
        public int Id { get; set; }
        
        public byte Type { get; set; }
        
        public double Longitude { get; set; }
        
        public double Latitude { get; set; }

        public double TriggerDistance { get; set; }

        [Unicode(true)]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Unicode(true)]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? TitleEN { get; set; }

        [Unicode(true)]
        public string? Message { get; set; }

        [Unicode(true)]
        [MaxLength(50)]
        public string? Contact { get; set; }

        [Unicode(true)]
        public string? Notes { get; set; }

    }
}
