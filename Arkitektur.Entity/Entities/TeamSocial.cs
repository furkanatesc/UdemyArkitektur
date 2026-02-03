using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Entity.Entities
{
    public class TeamSocial
    {
        public int Title { get; set; }
        public string Icon { get; set; }

        public string Url { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

    }
}
