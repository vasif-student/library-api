using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models.Dtos
{
    public class BookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public short Year { get; set; }
    }
}
