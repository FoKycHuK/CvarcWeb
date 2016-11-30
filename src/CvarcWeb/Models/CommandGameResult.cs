﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvarcWeb.Models
{
    public class CommandGameResult
    {
        public int CommandGameResultId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Command Command { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
