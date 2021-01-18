using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public abstract class Named
    {
        //Название объекта
        String name;

        //Присваивает имени объекта значение null
        public void ClearName ()
        {
            this.Name = null;
        }

        //Проверяет, совпадает ли имя объекта с данной строкой
        public bool CompareName(string nameToCompare)
        {
            return (this.Name.CompareTo(nameToCompare) == 0);
        }
        public string Name { get => name; set => name = value; }
    }
}
