using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvarcWeb.Models
{
    public class GameFilterModel
    {
        public string GameName { get; set; }
        public string CommandName { get; set; }
        public string Region { get; set; }
        public int Page { get; set; }
    }
}
