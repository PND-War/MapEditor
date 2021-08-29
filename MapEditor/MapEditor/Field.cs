using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    enum TypeOfTerrain
    {
        Earth,
        Water,
        Road,
        Tree,
        Mine,
        Bridge
    }
    class Field
    {
        public TypeOfTerrain terrain { get; set; }
        public bool cheked { get; set; } = false;
        public Texture2D fieldTexture { get; set; }
        public AUnit unit { get; set; }
        public int spriteId { get; set; }

        public Color GetFieldColor()
        {
            Color returnableColor = new Color();
            switch (terrain)
            {
                case TypeOfTerrain.Earth:
                    returnableColor = Color.ForestGreen;
                    break;
                case TypeOfTerrain.Water:
                    returnableColor = Color.Blue;
                    break;
                case TypeOfTerrain.Road:
                    returnableColor = Color.SandyBrown;
                    break;
                case TypeOfTerrain.Tree:
                    returnableColor = Color.Green;
                    break;
                case TypeOfTerrain.Mine:
                    returnableColor = Color.Yellow;
                    break;
            }
            return returnableColor;
        }
    }

    public class Texture2D
    {
    }
    public class AUnit
    {
    }
}
