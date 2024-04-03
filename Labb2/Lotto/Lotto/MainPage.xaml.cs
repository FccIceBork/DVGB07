using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lotto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    static class Constants
    {
        public const int size = 7;
    }

    public sealed partial class MainPage : Page
    {
        int[] arrayLr = new int[Constants.size];
        int ad = -1;
        public MainPage()
        {
            for(int i = 0; i < arrayLr.Length; i++)
            {
                arrayLr[i] = 0;
            }
            ad = -1;
            this.InitializeComponent();

        }

        private bool Check_dup()
        {
            int[] copy = new int[Constants.size];
            int temp;
            for(int i = 0; i < Constants.size; i++)
            {
                copy[i] = arrayLr[i];
            }
            for(int i = 0; i < Constants.size; i++)
            {
                temp = copy[i];
                copy[i] = 0;
                if(copy.Contains(temp))
                    return false;
            }
            return true;
        }

        private int Error_h()
        {
            int error_n = 1;
            if (arrayLr.Contains(0))
            {
                return error_n;
            }
            error_n++;

            for ( int i = 0; i < Constants.size; i++)
            {
                if (arrayLr[i] < 1 || arrayLr[i] > 35)
                {
                    return error_n;
                }
            }
            error_n++;

            if(!Check_dup())
            {
                return error_n;
            }
            error_n++;

            if(ad <= 0 || ad > 1000000)
            {
                return error_n;
            }

            return 0;
        }

        private async void Pop_Up(int num)
        {
            /*MessageDialog msg = new MessageDialog($"{lr_char} {lr_num} {lr_unik} {funkade}");
            await msg.ShowAsync();*/
            if (num == 0)
            {
                MessageDialog msg = new MessageDialog("Allting ser korrekt ut!");
                await msg.ShowAsync();
            }
            else if(num == 1)
            {
                MessageDialog msg = new MessageDialog("Fyll i lottofälten med en unika siffror mellan 1 & 35!");
                await msg.ShowAsync();
            }
            else if(num == 2)
            {
                MessageDialog msg = new MessageDialog("Lottofälten får bara inehålla siffror mellan 1 & 35!!");
                await msg.ShowAsync();
            }
            else if(num == 3)
            {
                MessageDialog msg = new MessageDialog("Lottofälten får bara inehålla en UNIK siffra!!!");
                await msg.ShowAsync();
            }
            else if(num == 4)
            {
                MessageDialog msg = new MessageDialog("Antal dragningar måste vara ett tal mellan 1 & 1000000!");
                await msg.ShowAsync();
            }
            else
            {
                MessageDialog msg = new MessageDialog("Något annat blev fel...");
                await msg.ShowAsync();
            }
        }

        private void Lottande()
        {
            int counter = 0;
            int vinst, num_fem = 0, num_sex = 0, num_sju = 0;
            Random rn = new Random();
            int num = 0;
            int[] lotto = new int[Constants.size];
            do 
            {
                vinst = 0;
                for(int i = 0; i < Constants.size; i++)
                {
                    lotto[i] = 0;
                }
                for(int i = 0; i < Constants.size; i++)
                {
                    num = rn.Next(1, 36);
                    while (lotto.Contains(num))
                    {
                        num = rn.Next(1, 36);
                    }
                    lotto[i] = num;
                    if (arrayLr.Contains(num))
                        vinst++;
                }
                if(vinst == 7)
                {
                    num_sju++;
                }
                else if(vinst == 6)
                {
                    num_sex++;
                }
                else if(vinst == 5)
                {
                    num_fem++;
                }
                counter++; 
            }while(counter < ad);
            fem_ratt.Text = $"{num_fem}";
            sex_ratt.Text = $"{num_sex}";
            sju_ratt.Text = $"{num_sju}";
        }

        private void LR_c1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c1.Text, out nummer);
            arrayLr[0] = nummer;
        }

        private void LR_c2_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c2.Text, out nummer);
            arrayLr[1] = nummer;
        }

        private void LR_c3_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c3.Text, out nummer);
            arrayLr[2] = nummer;
        }

        private void LR_c4_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c4.Text, out nummer);
            arrayLr[3] = nummer;
        }

        private void LR_c5_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c5.Text, out nummer);
            arrayLr[4] = nummer;
        }

        private void LR_c6_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c6.Text, out nummer);
            arrayLr[5] = nummer;
        }
        private void LR_c7_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(LR_c7.Text, out nummer);
            arrayLr[6] = nummer;
        }

        private void antal_dragningar_TextChanged(object sender, TextChangedEventArgs e)
        {
            int nummer = 0;
            bool succsess = int.TryParse(antal_dragningar.Text, out nummer);
            ad = nummer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int error_h = -1;
            error_h = Error_h();
            if(error_h != 0)
            {
                Pop_Up(error_h);
            }
            else
            {
                Lottande();
            }
        }
    }
}
