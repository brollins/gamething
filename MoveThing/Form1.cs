﻿using System;
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

            DungeonGenerator generator = new DungeonGenerator();
           // generator.RandomSeed = 100;
            generator.GenerateTerrain(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-random.txt");

            currentVisibleMap = new VisibleMap(playArea, txtHistory, txtInventory);
            //Layer terrainLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-random.txt");
            Layer terrainLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\terrain-random.txt");
            currentVisibleMap.Layers.Add(terrainLayer);
            terrainLayer.Name = "terrainLayer";
            //Layer itemLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\item-random.txt");
            //currentVisibleMap.Layers.Add(itemLayer);
            //itemLayer.Name = "itemLayer";
            //Layer monsterLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\MoveThing\monster-random.txt");
            //currentVisibleMap.Layers.Add(monsterLayer);
            //monsterLayer.Name = "monsterLayer";
            //Layer fogLayer = new Layer(@"C:\Users\brad\Documents\Visual Studio 2015\Projects\Movething\fog-random.txt");
            //fogLayer.Name = "fog";
            //currentVisibleMap.Layers.Add(fogLayer);
                        
            currentVisibleMap.RefreshMap();

            //currentVisibleMap.Save();
            //currentVisibleMap.Load();          
                     
            
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
            if (e.KeyCode == Keys.D)
            {
                currentVisibleMap.Drop();
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
            if (e.KeyCode == Keys.D)
            {
                currentVisibleMap.Drop();
            }
        }

        private void txtInventory_Enter(object sender, EventArgs e)
        {
            ActiveControl = textBox1;
        }

        private void txtInventory_KeyDown(object sender, KeyEventArgs e)
        {
            ActiveControl = textBox1;

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
            if (e.KeyCode == Keys.D)
            {
                currentVisibleMap.Drop();
            }
        }

        private void txtHistory_Enter(object sender, EventArgs e)
        {
            ActiveControl = textBox1;
        }
    }
}
