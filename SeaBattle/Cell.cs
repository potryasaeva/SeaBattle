using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Cell
    {
        public int randX;
        public int randY;

        public Cell(int ship)
        {
            randX = new Random().Next(ship, 10 - ship);
            randY = new Random().Next(ship, 10 - ship);
        }

        public void AddBusyCells(int randX, int randY, char[,] busyCells)
        {
            //исключить все что за полем стыковка возможна
            for (int i = randX - 1; i < randX + 2; i++)
            {
                for (int j = randY - 1; j < randY + 2; j++)
                {
                    if ((i < 0) || (j < 0) || (9 < i) || (9 < j))
                    {
                        continue;
                    }
                    else busyCells[i, j] = '.';
                }
            }
        }

        public void PaintShip4(Field field)
        {
            if (randX % 2 == 0)
            {
                for (int i = randX; i < (randX + 4); i++)
                {
                    field.fieldMap[i, randY] = 'X';
                    AddBusyCells(i, randY, field.busyCells);
                }
            }
            else
            {
                for (int i = randY; i < (randY + 4); i++)
                {
                    field.fieldMap[randX, i] = 'X';
                    AddBusyCells(randX, i, field.busyCells);
                }
            }
        }
        public void PaintShip3(Field field)
        {

            if ((field.busyCells[randX - 2, randY] != '.') &
                (field.busyCells[randX - 1, randY] != '.') &
                (field.busyCells[randX, randY] != '.'))
            {
                field.fieldMap[randX - 2, randY] = 'X';
                field.fieldMap[randX - 1, randY] = 'X';
                field.fieldMap[randX, randY] = 'X';

                AddBusyCells(randX - 2, randY, field.busyCells);
                AddBusyCells(randX - 1, randY, field.busyCells);
                AddBusyCells(randX, randY, field.busyCells);

            }
            else if ((field.busyCells[randX, randY - 2] != '.') &
                    (field.busyCells[randX, randY - 1] != '.') &
                    (field.busyCells[randX, randY] != '.'))
            {
                field.fieldMap[randX, randY - 2] = 'X';
                field.fieldMap[randX, randY - 1] = 'X';
                field.fieldMap[randX, randY] = 'X';

                AddBusyCells(randX, randY - 2, field.busyCells);
                AddBusyCells(randX, randY - 1, field.busyCells);
                AddBusyCells(randX, randY, field.busyCells);
            }
            else
            {
                if (randX != 0)
                {
                    randX = randX++;
                    randY = randY++;
                }
                else
                {
                    randX = new Random().Next(3, 7);
                    randY = new Random().Next(3, 7);
                }

                if ((field.someCells[randX, randY] != '.') & (field.busyCells[randX, randY] != '.') &
                    (field.someCells[randX + 1, randY] != '.') & (field.busyCells[randX + 1, randY] != '.') &
                    (field.someCells[randX + 2, randY] != '.') & (field.busyCells[randX + 2, randY] != '.'))
                {
                    field.fieldMap[randX, randY] = 'X';
                    field.fieldMap[randX + 1, randY] = 'X';
                    field.fieldMap[randX + 2, randY] = 'X';
                    AddBusyCells(randX + 2, randY, field.busyCells);
                    AddBusyCells(randX + 1, randY, field.busyCells);
                    AddBusyCells(randX, randY, field.busyCells);
                    field.someCells[randX, randY] = '.';
                    field.someCells[randX + 1, randY] = '.';
                    field.someCells[randX + 2, randY] = '.';
                }
                else
                {
                    for (int i = 1; i < 9; i++)
                    {// по X
                        if ((field.someCells[i, randY] != '.') & (field.busyCells[i, randY] != '.') &
                            (field.someCells[i, randY + 1] != '.') & (field.busyCells[i, randY + 1] != '.') &
                            (field.someCells[i, randY + 2] != '.') & (field.busyCells[i, randY + 2] != '.'))
                        {
                            field.fieldMap[i, randY] = 'X';
                            field.fieldMap[i, randY + 1] = 'X';
                            field.fieldMap[i, randY + 2] = 'X';
                            AddBusyCells(i, randY, field.busyCells);
                            AddBusyCells(i, randY + 1, field.busyCells);
                            AddBusyCells(i, randY + 2, field.busyCells);
                            field.someCells[i, randY] = '.';
                            field.someCells[i, randY + 1] = '.';
                            field.someCells[i, randY + 2] = '.';
                            break;
                        }
                        else if ((field.someCells[randX, i] != '.') & (field.busyCells[randX, i] != '.') &
                            (field.someCells[randX + 1, i] != '.') & (field.busyCells[randX + 1, i] != '.') &
                            (field.someCells[randX + 2, i] != '.') & (field.busyCells[randX + 2, i] != '.'))// по Y
                        {
                            field.fieldMap[randX, i] = 'X';
                            field.fieldMap[randX + 1, i] = 'X';
                            field.fieldMap[randX + 2, i] = 'X';
                            AddBusyCells(randX, i, field.busyCells);
                            AddBusyCells(randX + 1, i, field.busyCells);
                            AddBusyCells(randX + 2, i, field.busyCells);
                            field.someCells[randX, i] = '.';
                            field.someCells[randX + 1, i] = '.';
                            field.someCells[randX + 2, i] = '.';
                            break;
                        }
                        else { continue; }
                    }
                }
            }

        }
        public void PaintShip2(Field field)
        {

            if ((field.busyCells[randX - 1, randY] != '.') &
                (field.busyCells[randX, randY] != '.'))
            {
                field.fieldMap[randX - 1, randY] = 'X';
                field.fieldMap[randX, randY] = 'X';

                AddBusyCells(randX - 1, randY, field.busyCells);
                AddBusyCells(randX, randY, field.busyCells);
            }

            else if ((field.busyCells[randX, randY - 1] != '.') &
                    (field.busyCells[randX, randY] != '.'))
            {
                field.fieldMap[randX, randY - 1] = 'X';
                field.fieldMap[randX, randY] = 'X';

                AddBusyCells(randX, randY - 1, field.busyCells);
                AddBusyCells(randX, randY, field.busyCells);

            }
            else
            {
                if (randX != 0)
                {
                    randX = randX++;
                    randY = randY++;
                }
                else
                {
                    randX = new Random().Next(2, 8);
                    randY = new Random().Next(2, 8);
                }

                if ((field.someCells[randX, randY] != '.') & (field.busyCells[randX, randY] != '.') &
                    (field.someCells[randX + 1, randY] != '.') & (field.busyCells[randX + 1, randY] != '.'))
                {
                    field.fieldMap[randX, randY] = 'X';
                    field.fieldMap[randX + 1, randY] = 'X';
                    AddBusyCells(randX + 1, randY, field.busyCells);
                    AddBusyCells(randX, randY, field.busyCells);
                    field.someCells[randX, randY] = '.';
                    field.someCells[randX + 1, randY] = '.';
                }
                else
                {
                    for (int i = 1; i < 9; i++)
                    {// по X
                        if ((field.someCells[i, randY] != '.') & (field.busyCells[i, randY] != '.') &
                            (field.someCells[i, randY + 1] != '.') & (field.busyCells[i, randY + 1] != '.'))
                        {
                            field.fieldMap[i, randY] = 'X';
                            field.fieldMap[i, randY + 1] = 'X';
                            AddBusyCells(i, randY, field.busyCells);
                            AddBusyCells(i, randY + 1, field.busyCells);
                            field.someCells[i, randY] = '.';
                            field.someCells[i, randY + 1] = '.';
                            break;
                        }
                        else if ((field.someCells[randX, i] != '.') & (field.busyCells[randX, i] != '.') &
                            (field.someCells[randX + 1, i] != '.') & (field.busyCells[randX + 1, i] != '.'))// по Y
                        {
                            field.fieldMap[randX, i] = 'X';
                            field.fieldMap[randX + 1, i] = 'X';
                            AddBusyCells(randX, i, field.busyCells);
                            AddBusyCells(randX + 1, i, field.busyCells);
                            field.someCells[randX, i] = '.';
                            field.someCells[randX + 1, i] = '.';
                            break;
                        }
                        else { continue; }
                    }
                }
            }

        }
        public void PaintShip1(Field field)
        {

            if (field.busyCells[randX, randY] != '.')
            {
                field.fieldMap[randX, randY] = 'X';
                AddBusyCells(randX, randY, field.busyCells);
            }
            else if (field.busyCells[randX, randY] != '.')
            {
                field.fieldMap[randX, randY] = 'X';
                AddBusyCells(randX, randY, field.busyCells);
            }
            else
            {
                if (randX != 0)
                {
                    randX = randX++;
                    randY = randY++;
                }
                else
                {
                    randX = new Random().Next(1, 9);
                    randY = new Random().Next(1, 9);
                }

                if ((field.someCells[randX, randY] != '.') & (field.busyCells[randX, randY] != '.'))
                {
                    field.fieldMap[randX, randY] = 'X';
                    AddBusyCells(randX, randY, field.busyCells);
                    field.someCells[randX, randY] = '.';
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {// по X
                        if ((field.someCells[i, randY] != '.') & (field.busyCells[i, randY] != '.'))
                        {
                            field.fieldMap[i, randY] = 'X';
                            AddBusyCells(i, randY, field.busyCells);
                            field.someCells[i, randY] = '.';
                            break;
                        }
                        else if ((field.someCells[randX, i] != '.') & (field.busyCells[randX, i] != '.'))// по Y
                        {
                            field.fieldMap[randX, i] = 'X';
                            AddBusyCells(randX, i, field.busyCells);
                            field.someCells[randX, i] = '.';
                            break;
                        }
                        else { continue; }
                    }
                }
            }
        }
    }
}
