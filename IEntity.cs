using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mars_task
{
    public interface IEntity
    {
        void MoveEntity(Array directions, int cell);
        void DrawEntity(Graphics g, Tuple<int, int, int>[] traps);
        void SetMainColor(Color color);
        Color GetMainColor();
        int GetTypeEntity();
        List<Point> GetPoints();
        void SetPoints(List<Point> points);
        void ClearPoints();
    }
}
