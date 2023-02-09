using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITRI_Project.Model
{
    public class Node
    {
        public int Id { get; set; }
        
        public int nodeID { get; set; }
        
        public int orderID { get; set; }
        
        [Unicode(false)]
        [MaxLength(20)]
        public string key { get; set; }
        
        public Byte type { get; set; }

        [Unicode(true)]
        public string? question { get; set; }

        [Unicode(false)]
        public string? questionAudio { get; set; }
        
        public bool isGenerate { get; set; }

        [Unicode(true)]
        public string? hints { get; set; }

        [Unicode(false)]
        public string? variableKey { get; set; }

        public bool hasFixedRep { get; set; }

        [Unicode(true)]
        public string? response { get; set; }

        [Unicode(false)]
        public string? responseAudio { get; set; }

        [Unicode(true)]
        public string? scriptParameter { get; set; }

    }
}
