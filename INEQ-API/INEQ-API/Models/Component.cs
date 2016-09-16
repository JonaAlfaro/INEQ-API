﻿using INEQ_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ_API.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int ComponentTypeId { get; set; }
        public int Equipment_Id { get; set; }
        public int EquipmentType_Id { get; set; }

        public virtual Equipament Equipment { get; set; }
        public virtual EquipamentType EquipmentType { get; set; }
    }
}