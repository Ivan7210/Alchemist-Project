using ElementsLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public class Elements : IEnumerable
    {
        List<Element> elementsList;

        public Elements(List<Element> elementsList)
        {
            ElementsList = elementsList;
        }

        //Находит элемент по его названию
        //Э
        public Element FindElement(String nameToFind)
        {
            foreach (Element curent in elementsList)
            {
                if (curent.CompareName(nameToFind))
                    return curent;
            }
            return null;
        }

        //Присваивает элементу значение по его названию 
        //Э
        public void SetValue(String name, Element elementToSet)
        {
            Element curentElement = this.FindElement(name);
            curentElement.Name = elementToSet.Name;
            curentElement.FormulasWithElement = elementToSet.FormulasWithElement;
            curentElement.OpenDate = elementToSet.OpenDate;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)elementsList).GetEnumerator();
        }

        public Element this[String name]
        {
            get
            {
                return this.FindElement(name);
            }
            set
            {
                this.SetValue(name, value);
            }
        }

        //Добавляет элемент в список
        //Б
        public void Add(Element elementToAdd)
        {
            ElementsList.Add(elementToAdd);
        }

        //Сортирует список элементов перед его отображением в DataGrid
        //Э
        public List<Element> SortToShow()
        {
            List<Element> result = new List<Element>();
            foreach(Element curentElement in this.ElementsList)
            {
                if (curentElement.OpenDate.CompareTo(new DateTime(1,1,1,0,0,0)) != 0)
                    result.Add(curentElement);
            }
            result.Sort(CompareByDate);
            return result;

        }

        //Сравнивает элементы на основании даты открытия
        //Э Б
        public static int CompareByDate(Element x, Element y)
        {
            return (x.OpenDate.CompareTo(y.OpenDate));
        }

        //Очищает список
        //
        public void Clear()
        {
            ElementsList.Clear();
        }

        //Подсчитывает количество элеметнов в списке
        //
        public int Count()
        {
            return ElementsList.Count();
        }


        public List<Element> ElementsList { get => elementsList; set => elementsList = value; }
    }
}
