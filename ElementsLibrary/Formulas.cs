using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public class Formulas : IEnumerable
    {
        List<Formula> formulasList;

        public Formulas(List<Formula> formulasList)
        {
            FormulasList = formulasList;
        }

        //Находит формулу по ее названию 
        //Ф
        public Formula FindFormula(String miscibleToFind)
        {
            foreach (Formula curent in formulasList)
            {
                if (curent.CompareName(miscibleToFind))
                    return curent;
            }
            return null;
        }

        //Присваивает формуле значение по ее названию 
        //Ф
        public void SetValue(String miscibleToSet, Formula FormulaToSet)
        {
            Formula curentFormula = this.FindFormula(miscibleToSet);
            curentFormula.Name = FormulaToSet.Name;
            curentFormula.Result = FormulaToSet.Result;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)formulasList).GetEnumerator();
        }

        public Formula this[String miscible]
        {
            get
            {
                return this.FindFormula(miscible);
            }
            set
            {
                this.SetValue(miscible, value);
            }
        }

        //Добавляет формулу в список
        //Б
        public void Add(Formula formulaToAdd)
        {
            FormulasList.Add(formulaToAdd);
        }
        public List<Formula> FormulasList { get => formulasList; set => formulasList = value; }
    }
}
