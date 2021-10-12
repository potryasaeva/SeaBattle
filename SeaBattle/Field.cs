using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Field 
    {
        public char[,] fieldMap = new char[10, 10];
        public char[,] busyCells = new char[10, 10];
        public char[,] someCells = new char[10, 10];

        public Field()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    fieldMap[i, j] = 'O';
                    busyCells[i, j] = 'O';
                    someCells[i, j] = 'O';
                }
            }
        }

        public void PaintField()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{fieldMap[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void PaintShips(int numberOfDecks, Field field)
        {
            int[] list = new int[5-numberOfDecks];
           
            foreach (int i in list)
            {
                if (numberOfDecks == 4)
                {
                    Cell ship = new Cell(4);
                    ship.PaintShip4(field);
                }
                else if(numberOfDecks == 3)
                {
                    Cell ship = new Cell(3);
                    ship.PaintShip3(field);
                }
                else if (numberOfDecks == 2)
                {
                    Cell ship = new Cell(2);
                    ship.PaintShip2(field);
                }
                else if (numberOfDecks == 1)
                {
                    Cell ship = new Cell(1);
                    ship.PaintShip1(field);
                }

            }
        }
    }
}
