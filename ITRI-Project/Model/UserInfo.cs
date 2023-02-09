using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITRI_Project.Model
{
    [Index(nameof(Guid), IsUnique = true)]
    public class UserInfo
    {
        public int Id { get; set; }

        [Unicode(false)]
        [MaxLength(50)]
        public string Guid { get; set; }
        
        [Unicode(true)]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Unicode(false)]
        public string Mail { get; set; }
       
        [Unicode(false)]
        [MaxLength(15)]
        public string Phone { get; set; }
        
        public DateTime? Birthday { get; set; }

        [MaxLength(10)]
        public string Zodiac { get; set; }
        
        [Unicode(false)]
        [MaxLength(50)]
        public string PassNode { get; set; }

        public byte NowMapType { get; set; }

    }
}
