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
        /// ¬ысота от границы до старта пол€
        /// </summary>
        static private int _startHeightField = 132 - 90;
        /// <summary>
        /// Ўирина от границы до старта пол€
        /// </summary>
        static private int _startWidthField = 200 - 90;
        /// <summary>
        /// ловушки
        /// </summary>
        private Tuple<int, int, int>[] traps = new Tuple<int, int, int>[9];
        private List<IEntity> entities = new List<IEntity>()
        {
            new Creature(Color.Red, 0, _startHeightField),
            new Creature(Color.Orange, 0, _startHeightField),
            new Creature(Color.Gray, 0, _startHeightField)
        };
        public Form1()
        {
            InitializeComponent();
            Draw();
        }
        Bitmap[] bmps = new Bitmap[2];
        Random rnd = new Random();
        private void Draw()
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
                    DrawBell(actualX, actualY, g);
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
                    DrawProto(actualX, actualY, g);
                }
                if (trap_count == 3) { trap = false; }
            }
            bmps[1] = bmps[0].Clone(new RectangleF(0, 0, pictureBox.Width, pictureBox.Height), bmps[0].PixelFormat);
            pictureBox.Image = bmps[0];
        }
        public void DrawBell(int x, int y, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, x + 30, y + 5, x + 55, y + 30);
            g.DrawLine(pen, x + 55, y + 30, x + 30, y + 55);
            g.DrawLine(pen, x + 30, y + 55, x + 5, y + 30);
            g.DrawLine(pen, x + 5, y + 30, x + 30, y + 5);
        }
        public void DrawProto(int x, int y, Graphics g)
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
        private void DrawAndMoveCreature(Graphics g, IEntity entity)
        {
            List<Point> points = entity.GetPoints();
            points.Add(new Point(200, _startHeightField - 30));
            points.Add(new Point(200, _startHeightField + 30));
            int typeEntity = entity.GetTypeEntity();
            entity.MoveEntity(directions, cell);
            entity.SetPoints(points);
            for (int i = 0; i < entities.Count; i++)
            {
                int typeEnt = entities[i].GetTypeEntity();
                if (i != typeEntity - 1 && typeEnt != 0) { 
                    entities[i].DrawEntity(g, traps); 
                }
            }
            entities[typeEntity - 1].DrawEntity(g, traps);
            pictureBox.Image = bmps[0];
        }
        private void createEntity(Color color, int typeEntity, int start)
        {
            entities[typeEntity - 1] = new Creature(color, typeEntity, start);
            bmps[0] = bmps[1].Clone(new RectangleF(0, 0, pictureBox.Width, pictureBox.Height), bmps[1].PixelFormat);
            Graphics g = Graphics.FromImage(bmps[0]);
            DrawAndMoveCreature(g, entities[typeEntity - 1]);
        }
        private void catButton_Click(object sender, EventArgs e)
        {
            createEntity(Color.Red, 1, _startHeightField);
        }
        private void vampusButton_Click(object sender, EventArgs e)
        {
            createEntity(Color.Orange, 2, _startHeightField);
        }
        private void ghostButton_Click(object sender, EventArgs e)
        {
            createEntity(Color.Gray, 3, _startHeightField);
        }
        private void generateButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].ClearPoints();
            }
            traps = new Tuple<int, int, int>[9];
            Draw();
        }
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