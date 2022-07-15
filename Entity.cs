using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mars_task
{
    public abstract class Entity : IEntity
    {

        /// Тип существа
        public int TypeEntity { protected set; get; }

        /// Основной цвет 
        public Color MainColor { protected set; get; }
        /// <summary>
        /// Путь существа
        /// </summary>
        public List<Point> _points = new List<Point>();
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }
        public Color GetMainColor()
        {
            return MainColor;
        }
        public int GetTypeEntity()
        {
            return TypeEntity;
        }
        public List<Point> GetPoints()
        {
            return _points;
        }
        public void SetPoints(List<Point> points)
        {
            _points = points;
        }
        public void ClearPoints()
        {
            _points = new List<Point>();
        }
        public abstract void DrawEntity(Graphics g, Tuple<int, int, int>[] traps);
        public abstract void MoveEntity(Array directions, int cell);
    }
}
