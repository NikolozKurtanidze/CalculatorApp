using System;
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
        int firstElement;
        int secondElement;
        bool OperatorIsPressed = false;
        bool LastOperatorEquals = false;
        string Operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButtons_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (!OperatorIsPressed)
                {
                    MainScreen.Text += button.Text;
                }
                else
                {
                    MainScreen.Text += button.Text;
                }
            }
        }
        static int Plus(int a, int b)
        {
            return a + b;
        }
        static int Minus(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int Division(int a, int b)
        {
            return a / b;
        }
        private void OperationButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (!string.IsNullOrWhiteSpace(MainScreen.Text))
                {
                    if (!OperatorIsPressed)
                    {
                        OperatorIsPressed = true;
                        Operation = button.Text;
                        MainScreen.Text += button.Text;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                if (!OperatorIsPressed)
                {
                    Application.Exit();
                }
                else
                {
                    if (!LastOperatorEquals)
                    {
                        switch (Operation)
                        {
                            case "+":
                                string[] strarr = MainScreen.Text.Split('+');
                                firstElement = int.Parse(strarr[0]);
                                secondElement = int.Parse(strarr[1]);
                                MainScreen.Text = (firstElement + secondElement).ToString();
                                break;
                            case "-":
                                strarr = MainScreen.Text.Split('-');
                                firstElement = int.Parse(strarr[0]);
                                secondElement = int.Parse(strarr[1]);
                                MainScreen.Text = (firstElement - secondElement).ToString();
                                break;
                            case "*":
                                strarr = MainScreen.Text.Split('*');
                                firstElement = int.Parse(strarr[0]);
                                secondElement = int.Parse(strarr[1]);
                                MainScreen.Text = (firstElement * secondElement).ToString();
                                break;
                            case "/":
                                strarr = MainScreen.Text.Split('/');
                                firstElement = int.Parse(strarr[0]);
                                secondElement = int.Parse(strarr[1]);
                                MainScreen.Text = (firstElement / secondElement).ToString();
                                break;
                        }
                    }
                    else
                    {   
                    }
                }
            }
        }
    }
}
