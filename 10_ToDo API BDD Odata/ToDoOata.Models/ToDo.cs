using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoOdata.Models
{
    public class ToDo : IId
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int? ToDoType_Id { get; set; }

        [ForeignKey("ToDoType_Id")]
        public virtual ToDoType ToDoType { get; set; }
    }
}
