using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; } // 1 - 1 relationship btw Game and Genre
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
