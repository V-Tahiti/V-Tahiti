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
            // insertion de donnée dans la table ToDo
            if (!context.ToDoes.Any())
            {
                context.ToDoes.AddRange(

                    new ToDo
                    {
                        Description = "Test 1"
                    },

                    new ToDo
                    {
                        Description = "Test 2"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
