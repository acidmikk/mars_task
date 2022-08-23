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
        /// <summary>
        /// установить цвет
        /// </summary>
        /// <param name="color">цвет</param>
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }
        /// <summary>
        /// получить цвет
        /// </summary>
        /// <returns></returns>
        public Color GetMainColor()
        {
            return MainColor;
        }
        /// <summary>
        /// получить тип
        /// </summary>
        /// <returns></returns>
        public int GetTypeEntity()
        {
            return TypeEntity;
        }
        /// <summary>
        /// получить маршрут
        /// </summary>
        /// <returns></returns>
        public List<Point> GetPoints()
        {
            return _points;
        }
        /// <summary>
        /// установить маршрут
        /// </summary>
        /// <param name="points"></param>
        public void SetPoints(List<Point> points)
        {
            _points = points;
        }
        /// <summary>
        /// очистить маршрут
        /// </summary>
        public void ClearPoints()
        {
            _points = new List<Point>();
        }
        public abstract void DrawEntity(Graphics g);
        public abstract void MoveEntity(Array directions, int _startHeightField, int _startWidthField, int cell);
    }
}
