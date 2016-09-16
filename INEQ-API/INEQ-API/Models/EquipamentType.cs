using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ_API.Models
{
    public class EquipamentType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float UsefulLife { get; set; }
        public float GuaranteeDuration { get; set; }
        public bool Active { get; set; }
    }
}