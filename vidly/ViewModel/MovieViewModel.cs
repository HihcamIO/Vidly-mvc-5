
using System.Collections.Generic;
using vidly.Models;

namespace vidly.ViewModel
{
    public class MovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }

        public string Name { get; set; }
    }
}