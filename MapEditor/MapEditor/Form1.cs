using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        Field[,] map = new Field[100, 100];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    map[i, j] = new Field();
                }
            }
            elements.Clear();
            elements.Add(new Element(paintField.Size, new Point(0, 0), Color.ForestGreen, 2));
            Invalidate();
        }
    }
}
