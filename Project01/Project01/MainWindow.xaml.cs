using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Project01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MathF mathF = new MathF();

        //Маркер для Rad и Deg c подсветкой
        private bool buttonRadIsEnable = false;
        private bool buttonRadIsLight = false;

        private double saveA = 0;

        //Маркеры для кнопок с двумя операндами
        private bool buttonXYIsEnable = false;
        private bool buttonYkorenXIsEnable = false;
        private bool buttonYXIsEnable = false;
        private bool buttonLogYIsEnable = false;

        //Маркер на точку
        private bool buttonDotIsEnabled = false;

        //Память
        private double memory = 0;

        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            foreach (UIElement el in Buttons.Children)
            {
                if (el is Button)
                    ((Button)el).Click += ButtonClick;
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string contentButton = ((Button)e.OriginalSource).Content.ToString();

                switch (contentButton)
                {
                    default:
                        if (Output.Text == "0" || Output.Text == "не число" || Output.Text == "Ошибка")
                            Output.Text = contentButton;
                        else
                            Output.Text += contentButton;
                        break;

                    case "+":
                        if (!CheckingSign())
                            Output.Text += contentButton;
                        break;

                    case "-":
                        if (!CheckingSign())
                            Output.Text += contentButton;
                        break;

                    case "÷":
                        if (!CheckingSign())
                            Output.Text += "/";
                        break;

                    case "×":
                        if (!CheckingSign())
                            Output.Text += "*";
                        break;

                    case ".":
                        if(!buttonDotIsEnabled)
                        Output.Text += ".";

                        buttonDotIsEnabled = true;
                        break;

                    case "mc":
                        memory = 0;
                        break;

                    case "m+":
                        memory += Convert.ToDouble(Output.Text);
                        break;

                    case "m-":
                        memory -= Convert.ToDouble(Output.Text);
                        break;

                    case "mr":
                        if (CheckingSign())
                        {
                            Output.Text += memory.ToString();
                        }
                        else
                        {
                            Output.Text = memory.ToString();
                        }

                        break;

                    case "2nd":
                        Replace2nd();
                        break;

                    case "%":
                        if (Output.Text != "")
                            Output.Text = (Convert.ToDouble(Output.Text) / 100).ToString();
                        break;


                    case "AC":
                        Output.Text = "0";

                        buttonDotIsEnabled = false;
                        break;

                    case "±":
                        if(!CheckingSign())
                        Output.Text = (Convert.ToDouble(Output.Text) * (-1)).ToString();
                        break;

                    case "=":
                        Result();

                        buttonDotIsEnabled = false;
                        break;

                    case "x²":
                        Output.Text = Math.Pow(Convert.ToDouble(Output.Text), 2).ToString();
                        break;
                    case "x³":
                        Output.Text = Math.Pow(Convert.ToDouble(Output.Text), 3).ToString();
                        break;

                    case "xᵞ":
                        RemoveMarker();
                        buttonXYIsEnable = true;

                        saveA = Convert.ToDouble(Output.Text);
                        Output.Text = "";
                        break;

                    case "yᵡ":
                        RemoveMarker();
                        buttonYXIsEnable = true;

                        saveA = Convert.ToDouble(Output.Text);
                        Output.Text = "";
                        break;

                    case "eᵡ":
                        Output.Text = mathF.VariableDegree(Math.E, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "10ᵡ":
                        Output.Text = mathF.VariableDegree(10, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "1/x":
                        Output.Text = Convert.ToDouble(Output.Text).ToString();
                        break;

                    case "²√x":
                        Output.Text = Math.Sqrt(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "³√x":
                        Output.Text = Math.Pow(Convert.ToDouble(Output.Text), 1.0 / 3.0).ToString();
                        break;

                    case "ᵞ√x":
                        RemoveMarker();
                        buttonYkorenXIsEnable = true;

                        saveA = Convert.ToDouble(Output.Text);
                        Output.Text = "";
                        break;

                    case "logᵧ":
                        RemoveMarker();
                        buttonLogYIsEnable = true;

                        saveA = Convert.ToDouble(Output.Text);
                        Output.Text = "";
                        break;

                    case "ln":
                        Output.Text = Math.Log(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "log₁₀":
                        Output.Text = Math.Log10(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "x!":
                        Output.Text = mathF.Factorial(Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "sin":
                        Output.Text = Math.Sin(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(",", ".");
                        break;

                    case "cos":
                        Output.Text = Math.Cos(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(",", ".");
                        break;

                    case "tan":
                        Output.Text = Math.Tan(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(",", ".");
                        break;

                    case "sinh":
                        Output.Text = Math.Sinh(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(",", ".");
                        break;

                    case "cosh":
                        Output.Text = Math.Cosh(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(",", ".");
                        break;

                    case "tanh":
                        Output.Text = Math.Tanh(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString();
                        break;

                    case "e":
                        Output.Text += Math.E.ToString();
                        break;

                    case "EE":
                        string a = Output.Text.Replace('.', ',');
                        Output.Text = mathF.EE(Convert.ToDouble(a));
                        break;

                    case "π":
                        Output.Text += Math.PI.ToString();
                        break;

                    case "Rand":
                        Output.Text += mathF.Rnd().ToString().Replace(',', '.');
                        break;

                    case "Rad":
                        buttonRadIsLight = true;
                        Rad.Text = "Rad";
                        btnRad.Content = "Deg";
                        break;

                    case "Deg":
                        Rad.Text = "";
                        btnRad.Content = "Rad";
                        buttonRadIsLight = false;
                        break;

                    case "sin⁻¹":
                        Output.Text = (Math.Asin(Convert.ToDouble(Output.Text.Replace('.', ','))) * 180 / Math.PI).ToString().Replace(',', '.');
                        break;

                    case "cos⁻¹":
                        Output.Text = (Math.Acos(Convert.ToDouble(Output.Text.Replace('.', ','))) * 180 / Math.PI).ToString().Replace(',', '.');
                        break;

                    case "tan⁻¹":
                        Output.Text = (Math.Atan(Convert.ToDouble(Output.Text.Replace('.', ','))) * 180 / Math.PI).ToString().Replace(',', '.');
                        break;

                    case "2ᵡ":
                        Output.Text = Math.Pow(2, Convert.ToDouble(Output.Text)).ToString();
                        break;

                    case "sinh⁻¹":
                        Output.Text = mathF.ArcSinH(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(',', '.');
                        break;

                    case "cosh⁻¹":
                        Output.Text = mathF.ArcCosH(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(',', '.');
                        break;

                    case "tanh⁻¹":
                        Output.Text = mathF.ArcTanH(Convert.ToDouble(Output.Text.Replace('.', ','))).ToString().Replace(',', '.');
                        break;

                    case "log₂":
                        Output.Text = Math.Log(Convert.ToDouble(Output.Text), 2).ToString();
                        break;

                }
            }
            catch (Exception)
            {
                Output.Text = "Ошибка";
            }
        }

        private void RemoveMarker()
        {
            buttonXYIsEnable = false;
            buttonYkorenXIsEnable = false;
            buttonYXIsEnable = false;
            buttonLogYIsEnable = false;
        }

        private void Result()
        {
            try
            {
                if (!buttonXYIsEnable && !buttonYkorenXIsEnable && !buttonYXIsEnable && !buttonLogYIsEnable)
                {
                    string answer = new DataTable().Compute(Output.Text, null).ToString().Replace(',', '.');
                    Output.Text = answer;
                }

                if (buttonXYIsEnable)
                {
                    Output.Text = Math.Pow(saveA, Convert.ToDouble(Output.Text)).ToString();
                }

                if (buttonYXIsEnable)
                {
                    Output.Text = Math.Pow(Convert.ToDouble(Output.Text), saveA).ToString();
                }

                if (buttonYkorenXIsEnable)
                {
                    Output.Text = Math.Pow(saveA, 1 / Convert.ToDouble(Output.Text)).ToString();
                }

                if (buttonLogYIsEnable)
                {
                    Output.Text = Math.Log(saveA, Convert.ToDouble(Output.Text)).ToString();
                }

                RemoveMarker();
            }
            catch (Exception)
            {
                Output.Text = "Ошибка";
            }

        }

        private void Replace2nd()
        {
            if (!buttonRadIsEnable)
            {
                buttonRadIsEnable = true;

                button2nd.Background = Brushes.Gray;
                button2nd.Foreground = Brushes.Black;

                tenX.Content = "2ᵡ";
                eX.Content = "yᵡ";
                log10.Content = "log₂";
                ln.Content = "logᵧ";
                tan.Content = "tan⁻¹";
                cos.Content = "cos⁻¹";
                sin.Content = "sin⁻¹";
                tanh.Content = "tanh⁻¹";
                cosh.Content = "cosh⁻¹";
                sinh.Content = "sinh⁻¹";
            }
            else
            {
                buttonRadIsEnable = false;

                var bc = new BrushConverter();
                button2nd.Background = (Brush)bc.ConvertFrom("#212121");
                button2nd.Foreground = Brushes.White;

                tenX.Content = "10ᵡ";
                eX.Content = "eᵡ";
                log10.Content = "log₁₀";
                ln.Content = "ln";
                tan.Content = "tan";
                cos.Content = "cos";
                sin.Content = "sin";
                tanh.Content = "tanh";
                cosh.Content = "cosh";
                sinh.Content = "sinh";
            }
        }

        //TODO
        private void CorrectNumber()
        {
            if (Output.Text.IndexOf("∞") != -1)
                Output.Text = Output.Text.Substring(0, Output.Text.Length - 1);

            if (Output.Text[0] == '0' && (Output.Text.IndexOf(",") != 1))
                Output.Text = Output.Text.Remove(0, 1);

            if (Output.Text[0] == '-')
                if (Output.Text[1] == '0' && (Output.Text.IndexOf(",") != 2))
                    Output.Text = Output.Text.Remove(1, 1);
        }

        private bool CheckingSign()
        {
            if (Output.Text.EndsWith("+") || Output.Text.EndsWith("-") || Output.Text.EndsWith("/") || Output.Text.EndsWith("*") || Output.Text == "не число" || Output.Text == "Ошибка")
                return true;
            else
                return false;
        }

    }
}
