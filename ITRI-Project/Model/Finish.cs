using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITRI_Project.Model
{
    public class Finish
    {
        public int Id { get; set; }
        [Unicode(false)]
        [MaxLength(50)]
        public string Guid { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
