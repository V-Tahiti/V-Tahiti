using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoOdata.Models
{
    public class ToDoType : IId
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
