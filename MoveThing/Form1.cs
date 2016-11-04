using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            currentVisibleMap.LoadTerrainMap(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-random.txt");
            currentVisibleMap.LoadItemMap(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\items-random.txt");
            currentVisibleMap.LoadMonsterMap(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monsters-random.txt");

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
