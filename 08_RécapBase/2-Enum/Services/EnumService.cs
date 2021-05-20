using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_Enum.Services
{
    public class EnumService
    {
        // On impose (where) que celui qui l appel et qui remplace T soit oblige de ne mettre obligatoirement des enums
        public List<string> GetStringFromEnum<T>() where T : Enum           
        {            
            return Enum.GetNames(typeof(T)).ToList();
        }
        // On transforme l'enum en liste de string
        //il recupere tous les "Noms" de enum et cree une liste de string au final
        //retourne une liste de type string provenant d une enum, il recupere les nom provenant de l'enum(GetNames) de type (typeof) T
    }
}
