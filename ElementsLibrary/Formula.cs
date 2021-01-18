using ElementsLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public class Formula: Named
    {
        //Элемента, который является результатом сложения элемента, который содержит эту формулу в своем списке формул, и элемента,
        //имя которого совпадает с именем этой формулы
        Element result;

        public Formula(String name, Element result)
        {
            Name = name;
            Result = result;
        }
        public Element Result { get => result; set => result = value; }
    }


}