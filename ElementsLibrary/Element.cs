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
        public static Element operator + (Element element1, Element element2)
        {
            if ((element1 == null)||(element2 == null))
                return null;

            foreach (Formula curentFormula in element1.FormulasWithElement)
            {
                if (curentFormula.CompareName(element2.Name))
                    return curentFormula.Result;
            }

            foreach (Formula curentFormula in element2.FormulasWithElement)
            {
                if (curentFormula.CompareName(element1.Name))
                    return curentFormula.Result;
            }

            return null;
        }

        //Проверяет, открыт ли этот элемент игроком, и если не открыт, записывает дату открытия как текущее время
        public void OpenElement ()
        {
            if (OpenDate.CompareTo(new DateTime(1, 1, 1, 0, 0, 0)) == 0)
                OpenDate = DateTime.Now;
        }


        public DateTime OpenDate { get => openDate; set => openDate = value; }
        public Formulas FormulasWithElement { get => formulasWithElement; set => formulasWithElement = value; }
    }
}
