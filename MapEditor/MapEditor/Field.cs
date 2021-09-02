using System.Drawing;

namespace MapEditor
{
    public enum TypeOfTerrain
    {
        Earth,
        Water,
        Road,
        Tree,
        Mine,
        Bridge
    }
    public class Field
    {
        public TypeOfTerrain terrain { get; set; }
        public bool cheked { get; set; } = false;
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
