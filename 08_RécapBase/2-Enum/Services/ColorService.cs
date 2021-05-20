using _2_Enum.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Enum.Services
{
    public class ColorService
    {
        private readonly EnumService enumService = new EnumService();

        public ColorService()
        {
            Couleurs = enumService.GetStringFromEnum<ColorTypes>();
        }

        public List<string> Couleurs { get; }
    }
}
