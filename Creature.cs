using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars_task
{
    public class Creature : Entity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mainColor">цвет</param>
        /// <param name="type">тип</param>
        /// <param name="startHeightField">начальные точки</param>
        public Creature(Color mainColor, int type, int startHeightField)
        {
            MainColor = mainColor;
            TypeEntity = type;
            _points.Add(new Point(200, startHeightField - 30));
            _points.Add(new Point(200, startHeightField + 30));
        }
        /// <summary>
        /// отрисовка сущности
        /// </summary>
        /// <param name="g">средство рисование</param>
        /// <param name="traps">расположение ловушек</param>
        public override void DrawEntity(Graphics g, Tuple<int, int, int>[] traps)
        {
            Pen pen = new Pen(MainColor, 2);
            Brush brush = new SolidBrush(Color.Gray);
            for (int i = 1; i < _points.Count; i++)
            {
                g.DrawLine(pen, _points[i - 1].X, _points[i - 1].Y, _points[i].X, _points[i].Y);
            }
        }
        /// <summary>
        /// движение
        /// </summary>
        /// <param name="directions">направления</param>
        /// <param name="cell">ширина клетки</param>
        public override void MoveEntity(Array directions, int cell)
        {
            Random rnd = new Random();
            int _startHeightField = 132 - 90;
            int _startWidthField = 200 - 90;
            bool outField = true;
            while (outField)
            {
                int i = _points.Count;
                Direction direction = (Direction)directions.GetValue(rnd.Next(directions.Length));
                switch (direction)
                {
                    // вправо
                    case Direction.Right:
                        if (_points[i - 1].X + cell < _startWidthField + 3 * cell)
                        {
                            _points.Add(new Point(_points[i - 1].X + cell, _points[i - 1].Y));
                        }
                        else
                        {
                            _points.Add(new Point(_points[i - 1].X + cell, _points[i - 1].Y));
                            outField = false;
                        }
                        break;
                    //влево
                    case Direction.Left:
                        if (_points[i - 1].X - cell >= _startWidthField)
                        {
                            _points.Add(new Point(_points[i - 1].X - cell, _points[i - 1].Y));
                        }
                        else
                        {
                            _points.Add(new Point(_points[i - 1].X - cell, _points[i - 1].Y));
                            outField = false;
                        }
                        break;
                    //вверх
                    case Direction.Up:
                        if (_points[i - 1].Y - cell >= _startHeightField)
                        {
                            _points.Add(new Point(_points[i - 1].X, _points[i - 1].Y - cell));
                        }
                        else
                        {
                            _points.Add(new Point(_points[i - 1].X, _points[i - 1].Y - cell));
                            outField = false;
                        }
                        break;
                    //вниз
                    case Direction.Down:
                        if (_points[i - 1].Y + cell < _startHeightField + 3 * cell)
                        {
                            _points.Add(new Point(_points[i - 1].X, _points[i - 1].Y + cell));
                        }
                        else
                        {
                            _points.Add(new Point(_points[i - 1].X, _points[i - 1].Y + cell));
                            outField = false;
                        }
                        break;
                }
            }
        }
    }
}
