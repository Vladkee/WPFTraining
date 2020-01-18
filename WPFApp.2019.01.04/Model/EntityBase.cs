using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp._2019._01._04.Model
{
    public class EntityBase
    {
        public int Id { get; }

        public bool IsNew { get; set; }

        private static int counter;

        public EntityBase()
        {
            this.IsNew = true;
            this.Id = counter++;
        }

        public void Save()
        {
            this.IsNew = false;
        }
    }
}
