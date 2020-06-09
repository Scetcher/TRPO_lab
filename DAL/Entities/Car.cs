using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Enums;

namespace DAL.Entities
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ServiceStationId { get; set; }
        public ServiceStation ServiceStation { get; set; }
        public CarStatus Status { get; set; }
        public string Number { get; set; }
        public string Model { get; set; }
    }
}