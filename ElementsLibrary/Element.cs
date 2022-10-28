using ElementsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public class Element: Named, IOpenable
    {
        //Формулы, которые включают в себя данный элемент
        Formulas formulasWithElement;
        //Дата открытия этого элемента
        DateTime openDate;

        public Element(string name, Formulas formulasWithElement)
        {
            Name = name;
            FormulasWithElement = formulasWithElement;
            OpenDate = new DateTime(1, 1, 1, 0, 0, 0);
        }
        public Element(string name, DateTime openDate)
        {
            Name = name;
            FormulasWithElement = new Formulas (new List<Formula>());
            OpenDate = openDate;
        }

        //Скаладывает два элемента 
        //Б
        public static Element operator + (Element element1, Element element2)
        {
            Element result1 = element1.СheckFormulas(element2);
            Element result2 = element2.СheckFormulas(element1);
            if (result1 != null)
                return result1;
            else
                return result2;
        }

        //Э Ф
        public Element СheckFormulas (Element element)
        {
            if (element == null)
                return null;
            foreach (Formula curentFormula in this.FormulasWithElement)
            {
                if (curentFormula.CompareName(element.Name))
                    return curentFormula.Result;
            }
            return null;
        }

        //Проверяет, открыт ли этот элемент игроком, и если не открыт, записывает дату открытия как текущее время
        // Э Б
        public bool OpenElement ()
        {
            if (OpenDate.CompareTo(new DateTime(1, 1, 1, 0, 0, 0)) == 0)
                OpenDate = DateTime.Now;
                return false;
            else
                return true;
        }


        public DateTime OpenDate { get => openDate; set => openDate = value; }
        public Formulas FormulasWithElement { get => formulasWithElement; set => formulasWithElement = value; }
    }
}
