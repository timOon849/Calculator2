using System;
using System.Windows;
using System.Windows.Controls;
using WPF.UI;

namespace Calculator
{
    //Logiccc

    public partial class MainWindow : Window
    {  
        private double firstNumber = 0;
        private string operation = "";
        private bool isOperationClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as Button).Tag.ToString();

            if (isOperationClicked || Display.Text == "0")
            {
                Display.Text = number;
                isOperationClicked = false;
            }
            else
            {
                Display.Text += number;
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ",";
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            operation = button.Tag.ToString();
            firstNumber = double.Parse(Display.Text);
            isOperationClicked = true;
        }


        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double secondNumber = double.Parse(Display.Text);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                            throw new DivideByZeroException("Деление на ноль!");
                        break;
                }

                Display.Text = result.ToString();
                isOperationClicked = true;
            }
            catch (Exception ex)
            {
                Display.Text = "Ошибка";
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }  
        }

        private void Trigonometric_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                string trigFunction = button.Tag.ToString();
                double value = double.Parse(Display.Text);

                switch (trigFunction)
                {
                    case "sin":
                        Display.Text = Math.Sin(value).ToString();
                        break;
                    case "cos":
                        Display.Text = Math.Cos(value).ToString();
                        break;
                    case "tan":
                        Display.Text = Math.Tan(value).ToString();
                        break;
                    case "asin":
                        Display.Text = Math.Asin(value).ToString();
                        break;
                    case "acos":
                        Display.Text = Math.Acos(value).ToString();
                        break;
                    case "atan":
                        Display.Text = Math.Atan(value).ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                Display.Text = "Ошибка";
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            operation = "";
            isOperationClicked = false;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
            }
        }
    }
}