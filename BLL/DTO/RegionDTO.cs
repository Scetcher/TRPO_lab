﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public ICollection<ServiceStationDTO> ServiceStations { get; set; }
        public string Name { get; set; }
    }
}