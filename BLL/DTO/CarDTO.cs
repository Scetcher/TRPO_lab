using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using DAL.Entities;
using DAL.Enums;

namespace BLL.DTO
{
    public class CarDTO
    {
        public Guid Id { get; set; }
        public Guid ServiceStationId { get; set; }
        public CarStatus Status { get; set; }
        public string Number { get; set; }
        public string Model { get; set; }
    }
}
