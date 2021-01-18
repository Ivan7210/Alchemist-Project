using ElementsLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace Alchemist_the_Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {
        //Список, привязанный к DataGrid
        Elements elementsInfo = new Elements(new List<Element>());
        //Элемент на первой позиции в формуле
        Element ingredient1 = null;
        //Элемент на второй позиции в формуле
        Element ingredient2 = null;
        //Проигрывает звук колокольчика
        SoundPlayer OpenElementSound;
        //Показывает, включен или выключен звук
        bool sound = true;


        public MainWindow()
        {
            InitializeComponent();
        }

        //Загружает стартовую конфигурацию
        public void DataGrid_Loaded(object sender, EventArgs e)
        {
            try
            {
                LoadingGame(@"defaultList.txt");
                OpenElementSound = new SoundPlayer("OpenElementSound.wav");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        //Назначает выбранный в таблице элемент на первую позицию в формуле
        public void ingredient1Button_Click(object sender, EventArgs e)
        {
            if (ElementsINFOdataGRID.SelectedItem != null)
            {
                var selectedCell = ElementsINFOdataGRID.SelectedCells[0];
                var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);

                ingredient1 = elementsInfo[(cellContent as TextBlock).Text];
                ingredient1Button.Content = (cellContent as TextBlock).Text;
                resultButton.Content = "?";
            }
        }

        //Назначает выбранный в таблице элемент на вторую позицию в формуле
        public void ingredient2Button_Click(object sender, EventArgs e)
        {
            if (ElementsINFOdataGRID.SelectedItem != null)
            {
                var selectedCell = ElementsINFOdataGRID.SelectedCells[0];
                var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);

                ingredient2 = elementsInfo[(cellContent as TextBlock).Text];
                ingredient2Button.Content = (cellContent as TextBlock).Text;
                resultButton.Content = "?";
            }
        }

        //Складывает два выбранных ранее элемента
        public void resultButton_Click(object sender, EventArgs e)
        {
            if ((ingredient1 != null) && (ingredient2 != null))
            {
                Element result = ingredient1 + ingredient2;
                if (result != null)
                {
                    resultButton.Content = result.Name;
                    int buff = elementsInfo.SortToShow().Count();
                    result.OpenElement();
                    try
                    {
                        if ((elementsInfo.SortToShow().Count() != buff)&&(sound))
                            OpenElementSound.Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Ошибка");
                    }
                    ElementsINFOdataGRID.DataContext = elementsInfo.SortToShow();
                    ScoreBox.Text = "Открыто элементов: " + elementsInfo.SortToShow().Count() + "/" + elementsInfo.Count();
                    if (result.CompareName("Жизнь"))
                        MessageBox.Show("Поздравляем! Вы создали создали саму жизнь! Станет ли это пределом ваших устремлений?", "Потрясающее открытие!");
                    if (result.CompareName("Человек"))
                        MessageBox.Show("Поздравляем! Вы создали Homo Sapiens - человека разумного. Станет ли это пределом ваших устремлений?", "Потрясающее открытие!");
                    if (result.CompareName("Философский камень"))
                        MessageBox.Show("Поздравляем! Вы создали Философский камень - легендарный алхимический элемент, превращающий любые металлы в золото и наделяющий людей бессмертием. Станет ли это пределом ваших устремлений?", "Потрясающее открытие!");
                    if (elementsInfo.SortToShow().Count() == elementsInfo.Count())
                        MessageBox.Show("Поздравляем! Вы открыли все элементы!", "Конец игры");
                }
                else
                    resultButton.Content = "Несуществующий элемент";
            }
            else
                resultButton.Content = "Выберите элементы для смешивания";
        }

        //Обнуляет текущий прогресс и начинает новую игру
        public void newGameButton_Click(object sender, EventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Вы действительно хотите начать новую игру? Весь Ваш не сохраненный прогресс будет удален.", "Новая игра", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
                try
                {
                    LoadingGame(@"defaultList.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка");
                }
        }

        //Делает сохранение игры в указанном месте
        public void SaveButton_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt"; 
            dlg.Filter = "Text documents (.txt)|*.txt"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                foreach (Element curent in elementsInfo)
                {
                    writer.WriteLine(curent.Name.Replace(' ', '_'));
                    writer.WriteLine(curent.OpenDate.ToString());
                }
                writer.WriteLine("Формулы:");
                writer.WriteLine("{");
                foreach (Element curent in elementsInfo)
                    foreach (Formula f in curent.FormulasWithElement)
                        writer.WriteLine(curent.Name.Replace(' ', '_') + " + " + f.Name.Replace(' ', '_') + " = " + f.Result.Name.Replace(' ', '_'));
                writer.WriteLine("}");
                writer.Close();
            }

        }

        //Вызывает диалоговое окно для выбора файла, который нужно загрузить, а затем вызывает LoadingGame(path)
        public void LoadButton_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt"; 
            dlg.Filter = "Text documents (.txt)|*.txt"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
                try
                {
                    LoadingGame(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка");
                }
        }

        //Загружает файл сохранения
        public void LoadingGame (String path)
        {
            StreamReader reader = new StreamReader(path);
            string line1;
            string line2;
            char[] charsToTrim = { ' ' };
            char[] charsToSplit = { '+', '=' };
            elementsInfo.Clear();
            try
            {
                while (((line1 = reader.ReadLine()) != null) && (line1 != "{") && ((line2 = reader.ReadLine()) != null) && (line2 != "{"))
                    elementsInfo.Add(new Element(line1.Trim(charsToTrim).Replace('_', ' '), Convert.ToDateTime(line2.Trim(charsToTrim))));
                while ((line1 = reader.ReadLine()) != "}")
                {
                    String[] curent = line1.Trim(charsToTrim).Split();
                    if (curent[4] == null)
                        throw new Exception();
                    Element e0 = elementsInfo[curent[0].Replace('_', ' ')];
                    Element e2 = elementsInfo[curent[2].Replace('_', ' ')];
                    Element e4 = elementsInfo[curent[4].Replace('_', ' ')];
                    if ((e0 == null)||(e2 == null)||(e4 == null))
                        throw new Exception();
                    e0.FormulasWithElement.Add(new Formula(curent[2].Replace('_', ' '), e4));
                }
                ElementsINFOdataGRID.DataContext = elementsInfo.SortToShow();
                ScoreBox.Text = "Открыто элементов: " + elementsInfo.SortToShow().Count() + "/" + elementsInfo.Count();               
            }
            catch (Exception e)
            {
                throw new Exception("Не удается прочитать файл сохранения:\n" + e);
            }
            finally
            {
                reader.Close();
                ingredient1 = null;
                ingredient2 = null;
                ingredient1Button.Content = "?";
                ingredient2Button.Content = "?";
                resultButton.Content = "?";
            }
        }

        //Включает или выключает звук
        public void soundButton_Click(object sender, EventArgs e)
        {
            if (sound)
            {
                sound = false;
                soundButton.Content = "Включить звук";
            }
            else
            {
                sound = true;
                soundButton.Content = "Выключить звук";
            }
        }

        //Выводит справку
        public void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данный проект – это компьютерная игра, в которой игрок в роли исследователя-алхимика может открывать новые " +
                "элементы путем объединения уже имеющихся попарно. Изначально игрок получает четыре базовых элемента - это воздух, вода, земля " +
                "и огонь. Объединяя базовые элементы, а также элементы полученные из них, игрок может получить еще 196 элементов. Цель игры – " +
                "открыть философский камень – сказочный элемент из средневековых легенд. Проект носит развлекательный характер, формулы, по " +
                "которым получаются элементы, не имеют ничего общего с реальностью и могут быть получены как логическим, так и парадоксальным " +
                "путем. К экспериментам следует подходить творчески.\n" +
                "При нажатии на любую из двух верхних  кнопок с вопросительным знаком, программа запоминает выбранный в данный момент в списке " +
                "элемент и помещает его на позицию в формуле.Если на этой позиции уже стоял элемент, он будет заменен."+
                "При нажатии на кнопку с вопросительным знаком, находящуюся после знака равенства, программа складывает выбранные игроком " +
                "элементы, и, если в списке еще нет элемента, который является результатом сложения, добавляет его в список и воспроизводит " +
                "звук колокольчика.Так же обновляется информация о количестве открытых элементов.Если сумма двух выбранных игроком элементов " +
                "равна null, программа оповестит об этом, выведя на кнопку надпись ”Несуществующий элемент”.\n"+
                "При нажатии на кнопку “Новая игра”, программа загружает файл defaultList, в котором записана стартовая конфигурация игры.\n"+
                "При нажатии на кнопку “Сохранить игру”, программа делает сохранение в формате файла txt, в котором сначала перечисляются все " +
                "элементы(на первой строке название элемента, на второй дата его открытия(дата 01.01.0001 0:00:00 обозначает, что элемент еще " +
                "не был открыт игроком)).Каждый элемент записывается с новой строки.После описания элементов следует ключевое слово “Формулы:” " +
                "и в { }"+
                "перечисляются все формулы, в формате Элемент1 + Элемент2 = Элемент3, каждая формула с новой строки.Во всех названиях " +
                "элементов пробелы заменяются на _.\n"+
                "При нажатии на кнопку “Загрузить игру”, программа загружает файл сохранения.Если он не будет обладать указанными выше " +
                "свойствами, программа сообщит об ошибке.Пользователь может создать собственный список элементов, отвечающий перечисленным " +
                "выше требованиям, и играть по нему.\n"+
                "Чтобы выключить звук, нажмите на кнопку “Выключить звук”. Чтобы включить звук, снова нажмите на эту кнопку.", "Как играть?");
        }

    }
}
