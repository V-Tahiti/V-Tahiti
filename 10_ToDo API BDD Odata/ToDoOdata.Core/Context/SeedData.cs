using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoOdata.Core.Context;
using ToDoOdata.Models;

namespace ToDoOdata.Core
{
    public class SeedData
    {
        public static void Initialize(ToDoOdataContext context)
        {
            if (!context.ToDoes.Any() && !context.ToDoTypes.Any())
            {
                context.ToDoes.AddRange(
                    new ToDo
                    {
                        Description = "A faire1",
                        ToDoType_Id = 1
                    },
                    new ToDo
                    {
                        Description = "A faire2",
                        ToDoType_Id = 2
                    }); 
                context.ToDoTypes.AddRange(
                new ToDoType
                {
                    Description = "Test 1"
                },
              new ToDoType
              {
                  Description = "Test 2"
              }
                );
                context.SaveChanges();
            }
        }
    }
}

