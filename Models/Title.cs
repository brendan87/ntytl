using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTytL.Models
{
    public class Title
    {
        public virtual string Name { get; set; }

        public virtual ICollection<TitleVote> Votes { get; set; }
    }
}
