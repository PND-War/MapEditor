using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class Element
    {
        public Size size;
        public Point point;
        public Color color;
        public int type;
        public string text = "Empty";

        public Element(Size size, Point point, Color color, int type)
        {
            this.size = size;
            this.point = point;
            this.color = color;
            this.type = type;
        }
        public Element(Size size, Point point, Color color, int type, string text) : this(size, point, color, type)
        {
            this.text = text;
        }
    }
}
