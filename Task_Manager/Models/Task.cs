using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class Task
    {

        public Guid ID { get; set; }
        public string when { get; set; }
        public string where { get; set; }
        public string why { get; set; }
        public string what { get; set; }
        public string how_much { get; set; }
        public string how_long { get; set; }


        public Task(string when, string where, string why, string what, string how_much, string how_long) 
        {
            ID = Guid.NewGuid();
            this.when = when;
            this.where = where;
            this.why = why;
            this.what = what;
            this.how_much = how_much;
            this.how_long = how_long;
        }

        public Task()
        {
        }
        
    }
}
