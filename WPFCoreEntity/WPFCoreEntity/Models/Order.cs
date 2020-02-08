using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFCoreEntity.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ItemsTotal { get; set; }

        public int Phone { get; set; }

        public int DeliveryStreet { get; set; }

        public int DeliveryCity { get; set; }

        public int DeliveryZip { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
