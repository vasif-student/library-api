using DomainModels.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models.Entities
{
    public class Book : IEntity
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public short Year { get; set; }
            public DateTime CreateDate { get; set; } = DateTime.Now;
            public DateTime? UpdateDate { get; set; }
            public DateTime? DeleteDate { get; set; }
            public bool IsDeleled { get; set; } = false;
    }
}
