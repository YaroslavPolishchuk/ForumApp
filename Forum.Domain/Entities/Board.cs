using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Answers { get; set; }
        public string Description { get; set; }

    }
}
