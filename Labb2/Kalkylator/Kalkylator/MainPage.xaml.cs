using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Kalkylator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int num1, num2;
        int sum;
        bool add, sub, mul, div;
        public MainPage()
        {
            num1 = 0; num2 = 0; 
            sum = 0;
            add = false; sub = false; mul = false; div = false;
            this.InitializeComponent();
        }

        private async void To_Much_Bugg_5_Me()
        {
            MessageDialog msg = new MessageDialog($"sum = {sum} num1 = {num1} num2 = {num2}");
            await msg.ShowAsync();
        }

        private void Lagg_till_tal(int tal)
        {
            bool succsess = int.TryParse(Kalkylator_ruta2.Text, out num1);
            if (succsess && num1 != 0)
            {
                Kalkylator_ruta2.Text += $"{tal}";
            }
            else
            {
                Kalkylator_ruta2.Text = $"{tal}";
            }
            int.TryParse(Kalkylator_ruta2.Text, out num1);
        }

        private bool DunderFlow()
        {
            Kalkylator_ruta1.Text = "";
            Kalkylator_ruta2.Text = "Over-/underflow";
            num1 = 0;
            num2 = 0;
            sum = 0;
            add = false; sub = false; mul = false; div = false;
            return false;
        }

        private bool Add_Sub_Mul_Div()
        {
            if(num1 == 0)
            {
                return true;
            }
            else if(add == true)
            {
                try
                {
                    checked { num2 = num2 + num1; }
                }
                catch (OverflowException e)
                {
                    return DunderFlow();
                }
                num1 = 0;
            }
            else if(sub == true)
            {
                try
                {
                    checked { num2 = num2 - num1; }
                }
                catch (OverflowException e)
                {
                    return DunderFlow();
                }
                num1 = 0;
            }
            else if(mul == true)
            {
                try
                {
                    checked { num2 = num2 * num1; }
                }
                catch (OverflowException e)
                {
                    return DunderFlow();
                }
                num1 = 0;
            }
            else if(div == true)
            {
                num2 = num2 / num1;
                num1 = 0;
            }
            else
            {
                num2 = num1;
                num1 = 0;
            }
            return true;
        }

        private bool Sum_Tals()
        {
            if(add == true)
            {
                try
                {
                    checked { sum = num2 + num1; }
                }
                catch (OverflowException e)
                {
                    return DunderFlow();
                }
            }
            else if(sub == true)
            {
                try
                {
                    checked { sum = num2 - num1; }
                }
                catch (OverflowException e)
                {
                    return DunderFlow();
                }
            }
            else if(mul == true)
            {
                try
                {
                    checked { sum = num2 * num1; }
                }
                catch (OverflowException e)
                {
                    return DunderFlow();
                }
            }
            else if(div == true)
            {
                sum = num2 / num1;
            }
            return true;
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(1);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(2);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(3);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool succ = Add_Sub_Mul_Div();
            if (succ)
            {
                Kalkylator_ruta2.Text = "";
                Kalkylator_ruta1.Text = $"{num2} +";
                add = true;
                sub = false; mul = false; div = false;
            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(4);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(5);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(6);
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            bool succ = Add_Sub_Mul_Div();
            if (succ)
            {
                Kalkylator_ruta2.Text = "";
                Kalkylator_ruta1.Text = $"{num2} -";
                sub = true;
                add = false; mul = false; div = false;
            }
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(7);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(8);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(9);
        }

        private void Mul_Click(object sender, RoutedEventArgs e)
        {
            bool succ = Add_Sub_Mul_Div();
            if (succ)
            {
                Kalkylator_ruta2.Text = "";
                Kalkylator_ruta1.Text = $"{num2} x";
                mul = true;
                add = false; sub = false; div = false;
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            sum = 0;
            Kalkylator_ruta1.Text = "";
            Kalkylator_ruta2.Text = "";
            add = false; sub = false; mul = false; div = false;
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Lagg_till_tal(0);
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            if (div == true && num1 == 0)
            {
                Kalkylator_ruta1.Text = "";
                Kalkylator_ruta2.Text = "Ej def";
                num1 = 0;
                num2 = 0;
                sum = 0;
            }
            else
            {
                bool succ = Sum_Tals();
                if (succ)
                {
                    Kalkylator_ruta1.Text = $"{sum}";
                    Kalkylator_ruta2.Text = "";
                    num1 = 0;
                    num2 = sum;
                    add = false; sub = false; mul = false; div = false;
                }
            }
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            Add_Sub_Mul_Div();
            Kalkylator_ruta2.Text = "";
            Kalkylator_ruta1.Text = $"{num2} /";
            div = true;
            add = false; sub = false; mul = false;
        }
    }
}
