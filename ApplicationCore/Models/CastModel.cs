using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastModel
    {
        public CastModel()
        {
            Movies = new List<MovieCardModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string Character { get; set; }
        public string Gender { get; set; }

        public List<MovieCardModel> Movies { get; set; }
    }
}
