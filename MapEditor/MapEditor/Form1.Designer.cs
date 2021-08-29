
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
                case TypeOfTerrain.Earth:
                    return 8;
                case TypeOfTerrain.Water:
                    return 8;
                case TypeOfTerrain.Road:
                    return 8;
                case TypeOfTerrain.Tree:
                    return 8;
                case TypeOfTerrain.Mine:
                    return 16;
                case TypeOfTerrain.Bridge:
                    return 8;
            }
            return 8;
        }
        private Point GetPointSize()
        {
            switch ((TypeOfTerrain)panel.Controls.IndexOf(panel.Controls.OfType<RadioButton>().Where(x => x.Checked).First()))
            {
                case TypeOfTerrain.Earth:
                    return new Point(8, 8);
                case TypeOfTerrain.Water:
                    return new Point(8, 8);
                case TypeOfTerrain.Road:
                    return new Point(8, 8);
                case TypeOfTerrain.Tree:
                    return new Point(8, 8);
                case TypeOfTerrain.Mine:
                    return new Point(16, 16);
                case TypeOfTerrain.Bridge:
                    return new Point(8, 8);
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
                case TypeOfTerrain.Water:
                    return 8;
                case TypeOfTerrain.Road:
                    return 8;
                case TypeOfTerrain.Tree:
                    return 8;
                case TypeOfTerrain.Mine:
                    return 16;
                case TypeOfTerrain.Bridge:
                    return 8;
            }
            return 8;
        }
        private Point GetPointSizeWhileOpen(Field field)
        {
            switch (field.terrain)
            {
                case TypeOfTerrain.Earth:
                    return new Point(8, 8);
                case TypeOfTerrain.Water:
                    return new Point(8, 8);
                case TypeOfTerrain.Road:
                    return new Point(8, 8);
                case TypeOfTerrain.Tree:
                    return new Point(8, 8);
                case TypeOfTerrain.Mine:
                    return new Point(16, 16);
                case TypeOfTerrain.Bridge:
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
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Tree;
                    map[(int)e.Location.X / GetSize() + 1, (int)e.Location.Y / GetSize()].terrain = TypeOfTerrain.Tree;
                    map[(int)e.Location.X / GetSize(), (int)e.Location.Y / GetSize() + 1].terrain = TypeOfTerrain.Tree;
                    map[(int)e.Location.X / GetSize() + 1, (int)e.Location.Y / GetSize() + 1].terrain = TypeOfTerrain.Tree;
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

        private int CheckAllRoadVariants(int i, int j)
        {
            int spriteId = 0;

            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Road)
            {
                spriteId = 1;
                if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Road)
                {
                    spriteId = 8;
                    if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Road)
                    {
                        spriteId = 7;

                        if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Road)
                        {
                            spriteId = 6;
                        }
                    }
                }
                else if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Road)
                {
                    spriteId = 10;

                    if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Road)
                    {
                        spriteId = 2;
                    }
                }
            }
            else if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Road)
            {
                spriteId = 1;
                if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Road)
                {
                    spriteId = 9;
                    if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Road)
                    {
                        spriteId = 5;

                        if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Road)
                        {
                            spriteId = 6;
                        }
                    }
                }
                else if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Road)
                {
                    spriteId = 11;

                    if (i + 1 > 0 && map[i + 1, j].terrain == TypeOfTerrain.Road)
                    {
                        spriteId = 2;
                    }
                }
            }
            else spriteId = 3;

            return spriteId;
        }
        private int CheckAllWaterVariants(int i, int j)
        {
            int spriteId = 17;

            if (i - 1 > 0 && (map[i - 1, j].terrain == TypeOfTerrain.Earth))
            {
                if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Earth)
                {
                    spriteId = 85;
                    if ((j + 1 < 100) && (map[i - 1, j + 1].terrain == TypeOfTerrain.Earth || map[i - 1, j - 1].terrain == TypeOfTerrain.Earth))
                        spriteId = 5;
                }
                else if ((j + 1 < 100 && i + 1 < 100) && map[i, j + 1].terrain == TypeOfTerrain.Earth)
                {
                    spriteId = 83;
                    if ((j - 1 > 0) && (map[i + 1, j + 1].terrain == TypeOfTerrain.Earth || map[i - 1, j - 1].terrain == TypeOfTerrain.Earth))
                        spriteId = 11;
                }
            }

            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Earth)
            {
                if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Earth)
                {
                    spriteId = 84;
                    if ((i - 1 > 0 && j + 1 < 100) && (map[i - 1, j + 1].terrain == TypeOfTerrain.Earth || map[i + 1, j - 1].terrain == TypeOfTerrain.Earth))
                        spriteId = 6;
                }
                else if (j + 1 < 100 && map[i, j + 1].terrain == TypeOfTerrain.Earth)
                {
                    spriteId = 12;
                    if ((i - 1 > 0 && j - 1 > 0 && i + 1 < 100) && (map[i + 1, j + 1].terrain == TypeOfTerrain.Earth))
                        spriteId = 82;
                    //map[i - 1, j - 1].terrain == TypeOfTerrain.Earth ||
                }
            }

            return spriteId;
        }

        private int CheckAllEarthVariants(int i, int j)
        {
            int spriteId = 81;
            List<int> exc = new List<int>() { 5, 6, 11, 12, 84, 82, 83, 85 };

            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Water)
            {
                spriteId = 8;
                if (j - 1 > 0 && map[i + 1, j - 1].terrain == TypeOfTerrain.Earth)
                {
                    if ((i - 1 > 0 && j + 1 < 100) && map[i - 1, j + 1].terrain == TypeOfTerrain.Earth)
                    {
                        spriteId = 4;
                    }
                }

                if (j + 1 < 100 && map[i + 1, j + 1].terrain == TypeOfTerrain.Earth)
                {
                    if (j - 1 > 0 && map[i - 1, j - 1].terrain == TypeOfTerrain.Earth)
                    {
                        spriteId = 10;
                    }
                }
            }

            if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Water && (!exc.Contains(map[i, j - 1].spriteId)))
            {
                spriteId = 15;

                if ((j + 1 < 100 && i - 1 > 0) && map[i - 1, j - 1].terrain == TypeOfTerrain.Water)
                {
                    if ((i + 1 < 100 && j - 1 > 0) && map[i + 1, j - 1].terrain == TypeOfTerrain.Water)
                    {
                        spriteId = 16;
                    }
                }

                if (i + 1 < 100 && map[i + 1, j - 1].terrain == TypeOfTerrain.Water)
                {
                    if (map[i + 1, j - 1].terrain == TypeOfTerrain.Water)
                    {
                        spriteId = 14;
                    }
                }

                if ((j + 1 < 100 && i - 1 > 0) && map[i + 1, j - 1].terrain == TypeOfTerrain.Water && map[i - 1, j - 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 15;
                }
            }

            if (i - 1 > 0 && map[i - 1, j].terrain == TypeOfTerrain.Water)
            {
                spriteId = 9;
                if (j + 1 < 100 && map[i - 1, j + 1].terrain == TypeOfTerrain.Earth)
                {
                    if ((i + 1 < 100 && j - 1 > 0) && map[i + 1, j - 1].terrain == TypeOfTerrain.Earth)
                    {
                        spriteId = 13;
                    }
                }

                if (j - 1 > 0 && map[i - 1, j - 1].terrain == TypeOfTerrain.Earth)
                {
                    if (i + 1 < 100 && map[i + 1, j - 1].terrain == TypeOfTerrain.Earth)
                    {
                        spriteId = 7;
                    }
                }
            }



            return spriteId;
        }

        private int OLDCheckAllEarthVariants(int i, int j)
        {
            int spriteId = 0;

            // Po krayam
            if ((i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Earth))
            {
                if (j + 1 < 100 && map[i + 1, j + 1].terrain == TypeOfTerrain.Water)
                    spriteId = 18;
                else if (j - 1 > 0 && map[i + 1, j - 1].terrain == TypeOfTerrain.Water)
                    spriteId = 18;
                else spriteId = 81;
            }

            // Sprava
            if (i + 1 < 100 && map[i + 1, j].terrain == TypeOfTerrain.Water)
            {
                spriteId = 8;
                if ((i + 1 < 100 && j - 1 > 0) && map[i + 1, j - 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 10;

                    if ((i + 1 < 100 && j + 1 < 100) && map[i + 1, j + 1].terrain == TypeOfTerrain.Water)
                    {
                        spriteId = 8;

                    }
                    else if ((i + 1 < 100 && j + 1 < 100) && map[i + 1, j + 1].terrain == TypeOfTerrain.Water)
                        spriteId = 4;
                }

            }

            // Sverhy
            if (i + 1 < 100 && map[i + 1, j].terrain != TypeOfTerrain.Water)
            {
                if (j - 1 > 0 && map[i, j - 1].terrain == TypeOfTerrain.Water)
                {
                    spriteId = 15;
                    if ((i + 1 < 100 && j - 1 > 0) && map[i + 1, j - 1].terrain == TypeOfTerrain.Water)
                    {
                        spriteId = 14;
                        if ((i - 1 > 0 && j - 1 > 0) && map[i - 1, j - 1].terrain == TypeOfTerrain.Water)
                            spriteId = 15;
                    }
                    else if ((i - 1 > 0 && j - 1 > 0) && map[i - 1, j - 1].terrain == TypeOfTerrain.Water)
                        spriteId = 12;
                }
            }

            return spriteId;
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
                            elements.Add(new Element(new Size(GetPointSizeWhileOpen(map[i,j])), new Point(i * GetSizeWhileOpen(map[i, j]), j * GetSizeWhileOpen(map[i, j])), GetColorWhileOpen(map[i, j]), 2));
                        }
                    }
                    this.Invalidate();
                    break;
                case "Save":
                    IndicateRoadSprite();
                    IndicateWaterSprite();
                    IndicateEarthSprite();

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


