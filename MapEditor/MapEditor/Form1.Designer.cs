
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapEditor
{
    partial class Form1
    {
        string imagePath = string.Empty;
        Color currentColor = Color.Black;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Text = "MapEditor++";
            this.ShowIcon = false;
            this.MinimumSize = new Size(900, 800);

            this.Earth = new System.Windows.Forms.RadioButton();
            this.Water = new System.Windows.Forms.RadioButton();
            this.Road = new System.Windows.Forms.RadioButton();
            this.Tree = new System.Windows.Forms.RadioButton();
            this.Mine = new System.Windows.Forms.RadioButton();
            this.Bridge = new System.Windows.Forms.RadioButton();

            // 
            // Earth
            // 
            this.Earth.AutoSize = true;
            this.Earth.Location = new System.Drawing.Point(10, 11);
            this.Earth.Name = "Earth";
            this.Earth.Size = new System.Drawing.Size(50, 17);
            this.Earth.TabIndex = 0;
            this.Earth.TabStop = true;
            this.Earth.Text = "Earth";
            this.Earth.UseVisualStyleBackColor = true;
            // 
            // Water
            // 
            this.Water.AutoSize = true;
            this.Water.Location = new System.Drawing.Point(10, 34);
            this.Water.Name = "Water";
            this.Water.Size = new System.Drawing.Size(60, 17);
            this.Water.TabIndex = 1;
            this.Water.TabStop = true;
            this.Water.Text = "Water";
            this.Water.UseVisualStyleBackColor = true;
            // 
            // Road
            // 
            this.Road.AutoSize = true;
            this.Road.Location = new System.Drawing.Point(10, 57);
            this.Road.Name = "Road";
            this.Road.Size = new System.Drawing.Size(51, 17);
            this.Road.TabIndex = 2;
            this.Road.TabStop = true;
            this.Road.Text = "Road";
            this.Road.UseVisualStyleBackColor = true;
            // 
            // Tree
            // 
            this.Tree.AutoSize = true;
            this.Tree.Location = new System.Drawing.Point(10, 80);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(47, 17);
            this.Tree.TabIndex = 3;
            this.Tree.TabStop = true;
            this.Tree.Text = "Tree";
            this.Tree.UseVisualStyleBackColor = true;
            // 
            // Mine
            // 
            this.Mine.AutoSize = true;
            this.Mine.Location = new System.Drawing.Point(10, 103);
            this.Mine.Name = "Mine";
            this.Mine.Size = new System.Drawing.Size(48, 17);
            this.Mine.TabIndex = 4;
            this.Mine.TabStop = true;
            this.Mine.Text = "Mine";
            this.Mine.UseVisualStyleBackColor = true;
            // 
            // Bridge
            // 
            this.Bridge.AutoSize = true;
            this.Bridge.Location = new System.Drawing.Point(10, 126);
            this.Bridge.Name = "Bridge";
            this.Bridge.Size = new System.Drawing.Size(55, 17);
            this.Bridge.TabIndex = 5;
            this.Bridge.TabStop = true;
            this.Bridge.Text = "Bridge";
            this.Bridge.UseVisualStyleBackColor = true;
            //
            // BridgeHori
            //
            this.Bridge.AutoSize = true;
            this.Bridge.Location = new System.Drawing.Point(10, 149);
            this.Bridge.Name = "BridgeHori";
            this.Bridge.Size = new System.Drawing.Size(55, 17);
            this.Bridge.TabIndex = 6;
            this.Bridge.TabStop = true;
            this.Bridge.Text = "BridgeHori";
            this.Bridge.UseVisualStyleBackColor = true;

            buttons = new List<Button>()
            {
                new Button()
                {
                    Text = "Save",
                    Name = "Save",
                    Font = new Font("Consolas",10),
                    Size = new Size(80,40),
                    Location = new Point(10, 750),
                    Anchor = AnchorStyles.Right
                },
                new Button()
                {
                    Text = "Open",
                    Name = "Open",
                    Font = new Font("Consolas",10),
                    Size = new Size(80,40),
                    Location = new Point(10,700),
                    Anchor = AnchorStyles.Right
                },
                new Button()
                {
                    Text = "Clear",
                    Name = "Clear",
                    Font = new Font("Consolas",10),
                    Size = new Size(80,40),
                    Location = new Point(10,650),
                },
                new Button()
                {
                    Text = "Fill",
                    Name = "Fill",
                    Font = new Font("Consolas",10),
                    Size = new Size(80,40),
                    Location = new Point(10,600),
                },
            };

            panel = new Panel()
            {
                Size = new Size(100, 800),
                Location = new Point(800, 0),
                BackColor = Color.FromArgb(255, 220, 220, 220)
            };

            this.panel.Controls.Add(this.Earth);
            this.panel.Controls.Add(this.Water);
            this.panel.Controls.Add(this.Road);
            this.panel.Controls.Add(this.Tree);
            this.panel.Controls.Add(this.Mine);
            this.panel.Controls.Add(this.Bridge);

            paintField = new PictureBox()
            {
                Size = new Size(800, 800),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(255, 230, 230, 230)
            };

            buttons.ForEach(x => panel.Controls.Add(x));
            buttons.ForEach(x => x.MouseClick += X_MouseClick);

            Controls.Add(panel);
            Controls.Add(paintField);

            paintField.MouseDown += PaintField_MouseDown;
            paintField.MouseMove += PaintField_MouseMove;

            elements = new List<Element>();

            this.Paint += Form1_Paint;
        }


        private Color GetColor()
        {
            switch ((TypeOfTerrain)panel.Controls.IndexOf(panel.Controls.OfType<RadioButton>().Where(x => x.Checked).First()))
            {
                case TypeOfTerrain.Earth:
                    return Color.ForestGreen;
                case TypeOfTerrain.Water:
                    return Color.Blue;
                case TypeOfTerrain.Road:
                    return Color.SandyBrown;
                case TypeOfTerrain.Tree:
                    return Color.Green;
                case TypeOfTerrain.Mine:
                    return Color.Yellow;
                case TypeOfTerrain.Bridge:
                    return Color.DarkOrange;
            }
            return Color.ForestGreen;
        }
        private int GetSize()
        {
            switch ((TypeOfTerrain)panel.Controls.IndexOf(panel.Controls.OfType<RadioButton>().Where(x => x.Checked).First()))
            {
            }
            return 8;
        }
        private Point GetPointSize()
        {
            switch ((TypeOfTerrain)panel.Controls.IndexOf(panel.Controls.OfType<RadioButton>().Where(x => x.Checked).First()))
            {
            }
            return new Point(8, 8);
        }

        private Color GetColorWhileOpen(Field field)
        {
            switch (field.terrain)
            {
                case TypeOfTerrain.Earth:
                    return Color.ForestGreen;
                case TypeOfTerrain.Water:
                    return Color.Blue;
                case TypeOfTerrain.Road:
                    return Color.SandyBrown;
                case TypeOfTerrain.Tree:
                    return Color.Green;
                case TypeOfTerrain.Mine:
                    return Color.Yellow;
                case TypeOfTerrain.Bridge:
                    return Color.DarkOrange;
            }
            return Color.ForestGreen;
        }
        private int GetSizeWhileOpen(Field field)
        {
            switch (field.terrain)
            {
                case TypeOfTerrain.Earth:
                    return 8;
            }
            return 8;
        }
        private Point GetPointSizeWhileOpen(Field field)
        {
            switch (field.terrain)
            {
                case TypeOfTerrain.Mine:
                    //return new Point(16, 16);
                    return new Point(8, 8);
            }
            return new Point(8, 8);
        }

        private void PaintField_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ((e.Location.X > 0 && e.Location.X < 800) && (e.Location.Y > 0 && e.Location.Y < 800)))
            {
                SaveTerrainsToMap(e);
                elements.Add(new Element(new Size(GetPointSize()), new Point(e.Location.X / GetSize() * GetSize(), e.Location.Y / GetSize() * GetSize()), GetColor(), 2));
                Invalidate();
            }
        }

        private void PaintField_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SaveTerrainsToMap(e);
                elements.Add(new Element(new Size(GetPointSize()), new Point(e.Location.X / GetSize() * GetSize(), e.Location.Y / GetSize() * GetSize()), GetColor(), 2));
                Invalidate();
            }
        }

        private void SaveTerrainsToMap(MouseEventArgs e)
        {
            switch ((TypeOfTerrain)panel.Controls.IndexOf(panel.Controls.OfType<RadioButton>().Where(x => x.Checked).First()))
            {
                case TypeOfTerrain.Earth:
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Earth;
                    break;
                case TypeOfTerrain.Water:
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Water;
                    break;
                case TypeOfTerrain.Road:
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Road;
                    break;
                case TypeOfTerrain.Tree:
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Tree;
                    break;
                case TypeOfTerrain.Mine:
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Mine;
                    //map[(int)e.Location.X / GetSize() + 1, (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Mine;
                    //map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize() + 1].terrain = TypeOfTerrain.Mine;
                    //map[(int)e.Location.X / GetSize() + 1, (int)e.Location.Y / GetSize() + 1].terrain = TypeOfTerrain.Mine;
                    break;
                case TypeOfTerrain.Bridge:
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Bridge;
                    break;
            }
        }

        private void IndicateRoadSprite()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (map[i, j].terrain == TypeOfTerrain.Road)
                        map[i, j].spriteId = CheckAllRoadVariants(i, j);
                }
            }
        }

        private void IndicateWaterSprite()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (map[i, j].terrain == TypeOfTerrain.Water)
                        map[i, j].spriteId = CheckAllWaterVariants(i, j);
                }
            }
        }
        private void IndicateTreeSprite()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (map[i, j].terrain == TypeOfTerrain.Tree)
                        map[i, j].spriteId = CheckAllTreeVariants(i, j);
                }
            }
        }
        private void IndicateEarthSprite()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (map[i, j].terrain == TypeOfTerrain.Earth)
                        map[i, j].spriteId = CheckAllEarthVariants(i, j);
                }
            }
        }

        private void IndicateMineSprite()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (map[i, j].terrain == TypeOfTerrain.Mine)
                        CheckAllMineVariants(i, j);
                }
            }
        }
        private void IndicateBridgeSprite()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (map[i, j].terrain == TypeOfTerrain.Bridge)
                        CheckAllBridgeVariants(i, j);
                }
            }
        }

        private int CheckAllTreeVariants(int i, int j)
        {
            int spriteId = 0;
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            if (i - 1 < 0 || map[i - 1, j].terrain == TypeOfTerrain.Tree)
            {
                left = true;
            }
            if (i + 1 >= 100 || map[i + 1, j].terrain == TypeOfTerrain.Tree)
            {
                right = true;
            }
            if (j - 1 < 0 || map[i, j - 1].terrain == TypeOfTerrain.Tree)
            {
                up = true;
            }
            if (j + 1 >= 100 || map[i, j + 1].terrain == TypeOfTerrain.Tree)
            {
                down = true;
            }

            if (left && right && up && down)
            {
                spriteId = 5;
            }
            else if (left && right && down)
            {
                spriteId = 2;
            }
            else if (left && right && up)
            {
                spriteId = 8;
            }
            else if (down && right && up)
            {
                spriteId = 4;
            }
            else if (down && left && up)
            {
                spriteId = 6;
            }
            else if (down && left)
            {
                spriteId = 3;
            }
            else if (up && left)
            {
                spriteId = 9;
            }
            else if (up && right)
            {
                spriteId = 7;
            }
            else if (down && right)
            {
                spriteId = 1;
            }

            return spriteId;
        }
        private int CheckAllRoadVariants(int i, int j)
        {
            int spriteId = 0;

            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Road) left = true;
            if (i + 1 <= 100 && map[i + 1, j].terrain == TypeOfTerrain.Road) right = true;
            if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Road) up = true;
            if (j + 1 <= 100 && map[i, j + 1].terrain == TypeOfTerrain.Road) down = true;

            if (left && right && up && down) spriteId = 6;
            else if (left && right && up) spriteId = 4;
            else if (left && right && down) spriteId = 2;
            else if (right && up && down) spriteId = 5;
            else if (left && up && down) spriteId = 7;
            else if (left && up) spriteId = 8;
            else if (left && down) spriteId = 11;
            else if (right && down) spriteId = 10;
            else if (right && up) spriteId = 9;
            else if (left || right) spriteId = 1;
            else if (up || down) spriteId = 3;
            else spriteId = 3;

            return spriteId;
        }
        private int CheckAllWaterVariants(int i, int j)
        {
            int spriteId = 17;

            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Earth) left = true;
            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Earth) right = true;
            if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Earth) up = true;
            if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Earth) down = true;

            else if (left && down) spriteId = 11;
            else if (left && up) spriteId = 5;
            else if (right && up) spriteId = 6;
            else if (right && down) spriteId = 12;

            return spriteId;
        }
        private int CheckAllEarthVariants(int i, int j)
        {
            int spriteId = 75;

            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Water) left = true;
            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Water) right = true;
            if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Water) up = true;
            if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Water) down = true;

            if (right && down)
            {
                spriteId = 4;
                if ((i + 1 < 100 && i - 1 > 0 && j - 1 > 0 && j + 1 < 100) && map[i + 1, j + 1].terrain == TypeOfTerrain.Water || map[i - 1, j - 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 79;
                }
                //if ((i - 1 > 0 && j + 2 < 100) && map[i - 1, j + 2].terrain == TypeOfTerrain.Water)
                //{
                //    spriteId = 1;
                //}
            }
            else if (left && up)
            {
                spriteId = 13;
                if ((i + 1 < 100 && i - 1 > 0 && j - 1 > 0 && j + 1 < 100) && map[i + 1, j + 1].terrain == TypeOfTerrain.Water || map[i - 1, j - 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 76;
                }
                //if ((i + 1 < 100 && j - 2 > 0) && map[i + 1, j - 2].terrain == TypeOfTerrain.Water)
                //{
                //    spriteId = 16;
                //}
            }
            else if (right && up)
            {
                //spriteId = 14;
                spriteId = 77;
                //if ((i - 1 > 0 && j - 2 > 0) && map[i - 1, j - 2].terrain == TypeOfTerrain.Water)
                //{
                //    spriteId = 10;
                //}
            }
            else if (left && down)
            {
                spriteId = 7;
                if ((i + 1 < 100 && i - 1 > 0 && j - 1 > 0 && j + 1 < 100) && map[i - 1, j - 1].terrain == TypeOfTerrain.Water && map[i + 1, j + 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 78;
                }
                else if ((i + 1 < 100 && i - 1 > 0 && j - 1 > 0 && j + 1 < 100) && map[i - 1, j - 1].terrain != TypeOfTerrain.Water && map[i + 1, j + 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 80;
                }
                //if ((i + 1 < 100 && j + 2 < 100) && map[i + 1, j + 2].terrain == TypeOfTerrain.Water)
                //{
                //    spriteId = 3;
                //}
            }
            else if (right)
            {
                spriteId = 8;
                if (i + 1 < 100 && map[i + 1, j].spriteId == 5)
                    spriteId = 4;
                if (i + 1 < 100 && map[i + 1, j].spriteId == 11)
                    spriteId = 10;
            }
            else if (left)
            {
                spriteId = 9;
                if (i - 1 > 0 && map[i - 1, j].spriteId == 6)
                    spriteId = 7;
                if (i - 1 > 0 && map[i - 1, j].spriteId == 12)
                    spriteId = 13;
            }
            else if (down)
            {
                spriteId = 2;
                if (j + 1 < 100 && map[i, j + 1].spriteId == 5)
                    spriteId = 1;
                if (j + 1 < 100 && map[i, j + 1].spriteId == 6)
                    spriteId = 3;
            }
            else if (up)
            {
                spriteId = 15;
                if (j - 1 > 0 && map[i, j - 1].spriteId == 11)
                    spriteId = 14;
                if (j - 1 > 0 && map[i, j - 1].spriteId == 12)
                    spriteId = 16;
            }

            return spriteId;
        }
        private void CheckAllMineVariants(int i, int j)
        {
            bool up = false;
            bool left = false;

            bool right = false;
            bool rightsecond = false;

            if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Mine) up = true;
            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Mine) left = true;

            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Mine) right = true;
            if (i + 2 < 100 && map[i + 2, j].terrain == TypeOfTerrain.Mine) rightsecond = true;

            if (!up && !left && right && rightsecond)
            {
                map[i, j].spriteId = 1;
                map[i + 1, j].spriteId = 2;
                map[i + 2, j].spriteId = 3;

                map[i, j + 1].spriteId = 4;
                map[i + 1, j + 1].spriteId = 5;
                map[i + 2, j + 1].spriteId = 6;

                map[i, j + 2].spriteId = 7;
                map[i + 1, j + 2].spriteId = 8;
                map[i + 2, j + 2].spriteId = 9;
            }
        }
        private void CheckAllBridgeVariants(int i, int j)
        {
            bool up = false;
            bool left = false;

            bool right = false;
            bool rightsecond = false;
            bool rightthird = false;
            bool rightfourth = false;

            if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Bridge) up = true;
            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Bridge) left = true;

            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Bridge) right = true;
            if (i + 2 < 100 && map[i + 2, j].terrain == TypeOfTerrain.Bridge) rightsecond = true;
            if (i + 3 < 100 && map[i + 3, j].terrain == TypeOfTerrain.Bridge) rightthird = true;
            if (i + 4 < 100 && map[i + 4, j].terrain == TypeOfTerrain.Bridge) rightfourth = true;

            if (!up && !left && right && rightsecond)
            {
                map[i, j].spriteId = 1;
                map[i + 1, j].spriteId = 2;
                map[i + 2, j].spriteId = 3;

                map[i, j + 1].spriteId = 4;
                map[i + 1, j + 1].spriteId = 5;
                map[i + 2, j + 1].spriteId = 6;

                map[i, j + 2].spriteId = 7;
                map[i + 1, j + 2].spriteId = 8;
                map[i + 2, j + 2].spriteId = 9;

                map[i, j + 3].spriteId = 10;
                map[i + 1, j + 3].spriteId = 11;
                map[i + 2, j + 3].spriteId = 12;

                map[i, j + 4].spriteId = 13;
                map[i + 1, j + 4].spriteId = 14;
                map[i + 2, j + 4].spriteId = 15;
            }
            if (!up && !left && right && rightsecond && rightthird && rightfourth)
            {
                map[i, j].spriteId = 16;
                map[i, j + 1].spriteId = 21;
                map[i, j + 2].spriteId = 26;

                map[i + 1, j].spriteId = 17;
                map[i + 1, j + 1].spriteId = 22;
                map[i + 1, j + 2].spriteId = 27;

                map[i + 2, j].spriteId = 18;
                map[i + 2, j + 1].spriteId = 23;
                map[i + 2, j + 2].spriteId = 28;

                map[i + 3, j].spriteId = 19;
                map[i + 3, j + 1].spriteId = 24;
                map[i + 3, j + 2].spriteId = 29;

                map[i + 4, j].spriteId = 20;
                map[i + 4, j + 1].spriteId = 25;
                map[i + 4, j + 2].spriteId = 30;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(800, 800);

            Graphics g = Graphics.FromImage(bitmap);

            SolidBrush brush;
            for (int i = 0; i < elements.Count; i++)
            {
                brush = new SolidBrush(elements[i].color);
                g.FillRectangle(brush, elements[i].point.X, elements[i].point.Y, elements[i].size.Width, elements[i].size.Height);
            }
            paintField.Image = bitmap;
        }


        private void X_MouseClick(object sender, MouseEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "Fill":
                    elements.Clear();
                    elements.Add(new Element(paintField.Size, new Point(0, 0), Color.ForestGreen, 2));
                    Invalidate();
                    break;
                case "Clear":
                    elements.Clear();
                    imagePath = string.Empty;
                    elements.Add(new Element(paintField.Size, new Point(0, 0), Color.ForestGreen, 2));
                    Invalidate();
                    break;
                case "Open":
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "WC|*.wc";

                    if (openFileDialog.ShowDialog() == DialogResult.OK) map = JsonConvert.DeserializeObject<Field[,]>(File.ReadAllText(openFileDialog.FileName));

                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            elements.Add(new Element(new Size(GetPointSizeWhileOpen(map[i, j])), new Point(i * GetSizeWhileOpen(map[i, j]), j * GetSizeWhileOpen(map[i, j])), GetColorWhileOpen(map[i, j]), 2));
                        }
                    }
                    this.Invalidate();
                    break;
                case "Save":
                    IndicateBridgeSprite();
                    IndicateRoadSprite();
                    IndicateWaterSprite();
                    IndicateEarthSprite();
                    IndicateTreeSprite();
                    IndicateMineSprite();

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "WC|*.wc";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(saveFileDialog.FileName))
                        {
                            File.Create(saveFileDialog.FileName).Close();
                            File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(map));
                        }
                        else
                        {
                            File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(map));
                        }
                    }
                    this.Invalidate();
                    break;
            }
        }

        private Panel panel;
        private List<Button> buttons;
        private PictureBox paintField;

        private System.Windows.Forms.RadioButton Bridge;
        private System.Windows.Forms.RadioButton Mine;
        private System.Windows.Forms.RadioButton Tree;
        private System.Windows.Forms.RadioButton Road;
        private System.Windows.Forms.RadioButton Water;
        private System.Windows.Forms.RadioButton Earth;

        private List<Element> elements;
        #endregion
    }
}


