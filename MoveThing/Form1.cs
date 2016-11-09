using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoveThing
{
    public partial class Form1 : Form
    {
        private VisibleMap currentVisibleMap;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentVisibleMap = new VisibleMap(playArea, txtHistory, txtInventory);
            Layer terrainLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-random.txt");
            currentVisibleMap.Layers.Add(terrainLayer);
            Layer itemLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-random.txt");
            currentVisibleMap.Layers.Add(itemLayer);
            Layer monsterLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monster-random.txt");
            currentVisibleMap.Layers.Add(monsterLayer);
            Layer fogLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\Movething\fog-random.txt");
            fogLayer.Name = "fog"; 
            currentVisibleMap.Layers.Add(fogLayer);

            currentVisibleMap.RefreshMap();
        
            textBox1.Focus();
         }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                currentVisibleMap.MoveRight();
            }
            if (e.KeyCode == Keys.Left)
            {
                currentVisibleMap.MoveLeft();
            }
            if (e.KeyCode == Keys.Down)
            {
                currentVisibleMap.MoveDown();
            }
            if (e.KeyCode == Keys.Up)
            {
                currentVisibleMap.MoveUp();
            }
            if (e.KeyCode == Keys.P)
            {
                currentVisibleMap.Pickup();
            }
            if (e.KeyCode == Keys.U)
            {
                currentVisibleMap.Use();
            }
        }       

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                currentVisibleMap.MoveRight();
            }
            if (e.KeyCode == Keys.Left)
            {
                currentVisibleMap.MoveLeft();
            }
            if (e.KeyCode == Keys.Down)
            {
                currentVisibleMap.MoveDown();
            }
            if (e.KeyCode == Keys.Up)
            {
                currentVisibleMap.MoveUp();
            }
            if (e.KeyCode == Keys.P)
            {
                currentVisibleMap.Pickup();
            }
            if (e.KeyCode == Keys.U)
            {
                currentVisibleMap.Use();
            }
        }

        private void txtInventory_Enter(object sender, EventArgs e)
        {
            ActiveControl = textBox1;
        }

        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    playArea.Width = this.Width / 2;
        //    playArea.Height = this.Height /2;
        //    txtHistory.Height = this.Height / 5;
        //    txtInventory.Width = this.Width / 4;
        //    currentVisibleMap.RefreshMap();
        //}
    }
}
