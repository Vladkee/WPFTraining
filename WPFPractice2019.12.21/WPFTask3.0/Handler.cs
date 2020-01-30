using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTask3._0
{
    public class Handler
    {
        public Task Task { get; set; }

        public ObservableCollection<Task> TaskList { get; set; }

        public Handler()
        {
            this.TaskList = new ObservableCollection<Task>
            {
                new Task("Grocery", "Pick up grocery", 2),
                new Task("Laudry", "Do my laundry", 1),
                new Task("Email", "Check my email and reply on urgent", 3)
            };
        }
    }
}
