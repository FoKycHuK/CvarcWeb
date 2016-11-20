using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvarcWeb.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int CommandGameResultId { get; set; }
        public virtual CommandGameResult CommandGameResult { get; set; }
        public int Scores { get; set; }
        public string ScoresType { get; set; }
    }
}
