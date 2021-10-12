using System;

namespace SeaBattle
{
    class Program
    {
        // «Морской бой» — вывести на экран массив 10х10, состоящий из
        // символов X и O, где Х — элементы кораблей, а О — свободные клетки.

        static void Main()
        {
            Field field = new ();

            //Рисуем один 4-х палубный корабль
            field.PaintShips(4, field);

            //Рисуем два 3-х палубных корабля
            field.PaintShips(3, field);

            //Рисуем три 2-х палубных корабля
            field.PaintShips(2, field);

            //Рисуем четыре 1-но палубных корабля
            field.PaintShips(1, field);

            field.PaintField();

            Console.WriteLine("Print GO, if you want to try one more time");
            var str = Console.ReadLine().ToLower();
            if (str == "go") { Main(); }
            
        }
    }
}
