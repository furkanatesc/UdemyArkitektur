using Arkitektur.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Entity.Entities
{
    public class Project:BaseEntity
    {
        public string? Title { get; set; }
        public string? Describtion { get; set; }

        public string? ImageUrl { get; set; }

        public string? Item1 { get; set; }

        public string? Item2 { get; set; }
        public string? Item3 { get; set; }
    }
}
