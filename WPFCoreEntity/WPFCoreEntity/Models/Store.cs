using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFCoreEntity.Models
{
    public class Store
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
