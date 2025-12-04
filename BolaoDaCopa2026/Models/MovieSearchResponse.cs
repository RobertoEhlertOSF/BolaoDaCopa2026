using System.Collections.Generic;

namespace BolaoDaCopa2026.Models
{
    public class MovieSearchResponse
    {
        public List<MovieItem> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
