using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mars_task
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// параметры клетки
        /// </summary>
        static private int cell = 60;
        /// <summary>
        /// Высота от границы до старта поля
        /// </summary>
        static private int _startHeightField = 132 - 90;
        /// <summary>
        /// Ширина от границы до старта поля
        /// </summary>
        static private int _startWidthField = 200 - 90;
        /// <summary>
        /// ловушки
        /// </summary>
        private Tuple<int, int, int>[] traps = new Tuple<int, int, int>[9];
        /// <summary>
        /// список с существами
        /// </summary>
        private List<IEntity> entities = new List<IEntity>(3)
        {
            new Creature(Color.Red, 0, _startHeightField),
            new Creature(Color.Orange, 0, _startHeightField),
            new Creature(Color.BlueViolet, 0, _startHeightField)
        };
        /// <summary>
        /// иницилизация формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            draw();
        }
        /// <summary>
        /// массив битмапов: основной и резерв
        /// </summary>
        Bitmap[] bmps = new Bitmap[2];
        Random rnd = new Random();
        /// <summary>
        /// отрисовка и расположение поля и ловушек
        /// </summary>
        private void draw()
        {
            bmps[0] = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(bmps[0]);
            Pen pen = new Pen(Color.Black, 3);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    int actualX = _startWidthField + x * cell;
                    int actualY = _startHeightField + y * cell;
                    g.DrawRectangle(pen, actualX, actualY, cell, cell);
                }
            }
            bool trap = true;
            int trap_count = 0;
            while (trap)
            {
                int traps_place = rnd.Next(0, 9);
                if (traps[traps_place] == null)
                {
                    int actualX = _startWidthField + (traps_place % 3) * cell;
                    int actualY = _startHeightField + (traps_place / 3) * cell;
                    trap_count++;
                    traps[traps_place] = new Tuple<int, int, int>(actualX, actualY, 1);
                    drawBell(actualX, actualY, g);
                }
                if (trap_count == 3) { trap = false; }
            }
            trap = true;
            trap_count = 0;
            while (trap)
            {
                int traps_place = rnd.Next(0, 9);
                if (traps[traps_place] == null)
                {
                    int actualX = _startWidthField + (traps_place % 3) * cell;
                    int actualY = _startHeightField + (traps_place / 3) * cell;
                    trap_count++;
                    traps[traps_place] = new Tuple<int, int, int>(actualX, actualY, 2);
                    drawProto(actualX, actualY, g);
                }
                if (trap_count == 3) { trap = false; }
            }
            bmps[1] = bmps[0].Clone(new RectangleF(0, 0, pictureBox.Width, pictureBox.Height), bmps[0].PixelFormat);
            pictureBox.Image = bmps[0];
        }
        /// <summary>
        /// рисует колокольчик
        /// </summary>
        /// <param name="x">ширина клетки</param>
        /// <param name="y">высота клетки</param>
        /// <param name="g">средство рисования</param>
        public void drawBell(int x, int y, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, x + 30, y + 5, x + 55, y + 30);
            g.DrawLine(pen, x + 55, y + 30, x + 30, y + 55);
            g.DrawLine(pen, x + 30, y + 55, x + 5, y + 30);
            g.DrawLine(pen, x + 5, y + 30, x + 30, y + 5);
        }
        /// <summary>
        /// рисование детектора
        /// </summary>
        /// <param name="x">ширина клетки</param>
        /// <param name="y">высота клетки</param>
        /// <param name="g">средство рисования</param>
        public void drawProto(int x, int y, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, x + 30, y + 5, x + 40, y + 20);
            g.DrawLine(pen, x + 40, y + 20, x + 55, y + 30);
            g.DrawLine(pen, x + 55, y + 30, x + 40, y + 40);
            g.DrawLine(pen, x + 40, y + 40, x + 30, y + 55);
            g.DrawLine(pen, x + 30, y + 55, x + 20, y + 40);
            g.DrawLine(pen, x + 20, y + 40, x + 5, y + 30);
            g.DrawLine(pen, x + 5, y + 30, x + 20, y + 20);
            g.DrawLine(pen, x + 20, y + 20, x + 30, y + 5);
        }
        Array directions = typeof(Direction).GetEnumValues();
        /// <summary>
        /// движение и отрисовка существа, закраска активированных ловушек
        /// </summary>
        /// <param name="g">средство рисования</param>
        /// <param name="entity">существо</param>
        private void drawAndMoveCreature(Graphics g, IEntity entity)
        {
            List<Point> points = entity.GetPoints();
            int typeEntity = entity.GetTypeEntity();
            entity.MoveEntity(directions, _startHeightField, _startWidthField, cell);
            entity.SetPoints(points);
            brushTraps(g);
            for (int i = 0; i < entities.Count; i++)
            {
                int typeEnt = entities[i].GetTypeEntity();
                if (i != typeEntity - 1 && typeEnt != 0) { 
                    entities[i].DrawEntity(g); 
                }
            }
            entities[typeEntity - 1].DrawEntity(g);
            pictureBox.Image = bmps[0];
        }
        /// <summary>
        /// создание существа
        /// </summary>
        /// <param name="color">цвет</param>
        /// <param name="typeEntity">тип</param>
        /// <param name="start">середина пол верзней границе поля</param>
        private void createEntity(Color color, int typeEntity, int start)
        {
            entities[typeEntity - 1] = new Creature(color, typeEntity, start);
            bmps[0] = bmps[1].Clone(new RectangleF(0, 0, pictureBox.Width, pictureBox.Height), bmps[1].PixelFormat);
            Graphics g = Graphics.FromImage(bmps[0]);
            drawAndMoveCreature(g, entities[typeEntity - 1]);
        }
        /// <summary>
        /// проверка и закраска ловушек
        /// </summary>
        /// <param name="g"></param>
        private void brushTraps(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Gray);
            for (int i = 0; i < entities.Count; i++)
            {
                int typeEntity = entities[i].GetTypeEntity();
                if (typeEntity != 0)
                {
                    Pen pen = new Pen(Color.Black, 3);
                    List<Point> points = entities[i].GetPoints();
                    int[,] marsh = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                    for (int j = 1; j < points.Count - 1; j++)
                    {
                        int num_trap = (points[j].X - _startWidthField) / cell + (points[j].Y - _startHeightField) / cell * 3;
                        marsh[num_trap / 3, num_trap % 3] += 1;
                        if (0 <= num_trap && num_trap < 9)
                        {
                            if (traps[num_trap] != null)
                            {
                                int x = traps[num_trap].Item1;
                                int y = traps[num_trap].Item2;
                                if (traps[num_trap].Item3 == 1)
                                {
                                    if (typeEntity == 2 && marsh[num_trap / 3, num_trap % 3] == 1)
                                    {
                                        g.FillRectangle(brush, x + 2, y + 2, 57, 57);
                                        drawBell(x, y, g);
                                    } else if (typeEntity == 1 && marsh[num_trap / 3, num_trap % 3] == 2)
                                    {
                                        g.FillRectangle(brush, x + 2, y + 2, 57, 57);
                                        drawBell(x, y, g);
                                    }
                                }
                                else if (traps[num_trap].Item3 == 2)
                                {
                                    if (typeEntity == 3 && marsh[num_trap / 3, num_trap % 3] == 1)
                                    {
                                        g.FillRectangle(brush, x + 2, y + 2, 57, 57);
                                        drawProto(x, y, g);
                                    }
                                    else if (typeEntity == 1 && marsh[num_trap / 3, num_trap % 3] == 2)
                                    {
                                        g.FillRectangle(brush, x + 2, y + 2, 57, 57);
                                        drawProto(x, y, g);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// создать кошку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catButton_Click(object sender, EventArgs e)
        {
            createEntity(Color.Red, 1, _startHeightField);
        }
        /// <summary>
        /// создать вампуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vampusButton_Click(object sender, EventArgs e)
        {
            createEntity(Color.Orange, 2, _startHeightField);
        }
        /// <summary>
        /// создать призрака
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ghostButton_Click(object sender, EventArgs e)
        {
            createEntity(Color.BlueViolet, 3, _startHeightField);
        }
        /// <summary>
        /// пересоздать карту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].ClearPoints();
            }
            traps = new Tuple<int, int, int>[9];
            draw();
        }
        /// <summary>
        /// очистить траектории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].ClearPoints();
            }
            pictureBox.Image = bmps[1];
            bmps[0] = bmps[1].Clone(new RectangleF(0, 0, pictureBox.Width, pictureBox.Height), bmps[1].PixelFormat);
        }
    }
}