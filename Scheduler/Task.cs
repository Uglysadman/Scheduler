using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class Task
    {
        private DateTime creationDate;

        public string Name { get; set; }
        public DateTime CreationDate { get; }
        public DateTime CompletionDate { get; set; }

        public Task(string Name, DateTime CompletionDate)
        {
            this.Name = Name;
            this.creationDate = DateTime.Now;
            this.CompletionDate = CompletionDate;
        }

        public override string ToString()
        {
            return String.Format("Task Name: {0}\t Creation Date: {1}\t Completion Date: {2}",
                this.Name, this.CreationDate, this.CompletionDate);
        }
    }
}
