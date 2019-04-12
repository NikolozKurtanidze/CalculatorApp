﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Calculator
{
    public partial class Form1 : Form
    {
        int counter = 0;
        double a = 0, b = 0, c = 0;
        char operation;
        bool pulled = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButtons_Click(object sender, EventArgs e)
        {
            MainScreen.Text += (sender as Button).Text;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            operation = ' ';
            a = 0;
            b = 0;
            c = 0;
            MainScreen.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var tmp = MainScreen.Text.Substring(0, MainScreen.Text.Length - 1);
            MainScreen.Text = tmp;
        }

        private void btnSQRT_Click(object sender, EventArgs e)
        {
            a = double.Parse(MainScreen.Text);
            c = Math.Pow(a, 0.5);
            MainScreen.Text = c.ToString();
        }

        private void SideBar_MouseHover(object sender, EventArgs e)
        {
            if (!pulled)
            {
                pulled = true;
                timer.Enabled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
         {
            int length = 5;
            counter++;
            if (counter != length)
            {
                SideBar.Location = new Point(SideBar.Location.X + 1, SideBar.Location.Y);
            }
            else if(counter == length)
            {
                counter = 0;
                while(counter < length)
                {
                    SideBar.Location = new Point(SideBar.Location.X - 1, SideBar.Location.Y);
                    counter++;
                }
                counter = length;
                pulled = false;
                timer.Enabled = false;
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            a = double.Parse(MainScreen.Text);
            operation = (sender as Button).Text[0];
            MainScreen.Clear();
        }
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            b = double.Parse(MainScreen.Text);
            switch (operation)
            {
                case '+': c = a + b;
                    break;
                case '-': c = a - b;
                    break;
                case '/': c = a / b;
                    break;
                case 'X': c = a * b;
                    break;
            }
            MainScreen.Text = c.ToString();
        }


    }
}
