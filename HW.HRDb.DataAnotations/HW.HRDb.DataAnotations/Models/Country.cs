using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW.HRDb.DataAnotations.Models
{
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string CountryName { get; set; }

        public int RegionId { get; set; }

        public Region Region { get; set; }

        public List<Location> Locations { get; set; }
    }
}
