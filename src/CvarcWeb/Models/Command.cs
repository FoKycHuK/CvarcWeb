using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvarcWeb.Models
{
    public class Command
    {
        public Command()
        {
            Members = new HashSet<ApplicationUser>();
        }

        public int CommandId { get; set; }
        public string Name { get; set; }
        public ApplicationUser Owner { get; set; }
        public string CvarcTag { get; set; }
        public string LinkToImage { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
    }
}
