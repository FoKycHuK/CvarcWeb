using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvarcWeb.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string PathToLog { get; set; }
        public virtual ICollection<CommandGameResult> CommandGameResults { get; set; }
    }
}
