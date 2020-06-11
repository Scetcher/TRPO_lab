using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class ServiceStationDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public ICollection<CarDTO> Cars { get; set; }
    }
}