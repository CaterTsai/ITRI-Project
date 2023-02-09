using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITRI_Project.Model
{
    public class Record
    {
        public int Id { get; set; }
        
        [Unicode(false)]
        [MaxLength(50)]
        public string Guid { get; set; }
        
        [Unicode(false)]
        [MaxLength(20)]
        public string Key { get; set; }
        
        public Byte Type { get; set; }

        [Unicode(true)]
        public string? Value { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
