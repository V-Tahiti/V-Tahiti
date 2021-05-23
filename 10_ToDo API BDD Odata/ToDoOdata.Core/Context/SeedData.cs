using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoOdata.Core.Context;
using ToDoOdata.Models;

namespace ToDoOdata.Core
{//alimentation de la BDD Virtuelle
    public class SeedData
    {
        public static void Initialize(ToDoOdataContext context)
        {
            //Si rien n'existe dans les propriétés du context(BDD), il faut ajouter avec la méthode "Initialize" les objets
            //ToDo et ToDoType avec les références relationnelles de "Foreign Key" définies dans le model de "ToDo"
            if (!context.ToDoes.Any() && !context.ToDoTypes.Any())
            {
                context.ToDoes.AddRange(
                    new ToDo
                    {
                        Description = "A faire1",
                        //relation de "Foreign Key" pour ToDoType
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

