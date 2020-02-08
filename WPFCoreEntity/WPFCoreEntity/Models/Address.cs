using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFCoreEntity.Models
{
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }
    }
}
