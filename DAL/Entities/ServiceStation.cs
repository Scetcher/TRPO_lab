using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ServiceStation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
