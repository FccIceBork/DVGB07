using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Media.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Text_editor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool saved, file_select, new_page;
        string title;
        Windows.Storage.IStorageFile file;
        public MainPage()
        {
            saved = true;
            file_select = false;
            new_page = false;
            this.InitializeComponent();
        }

        private void Cleaning()
        {
            saved = true;
            file_select = false;
            new_page = true;
            Titel.Text = "namnlös.txt";
            Text_box.Text = "";
        }

        private async Task Save_Game()
        {
            saved = true;
            await Windows.Storage.FileIO.WriteTextAsync(file, $"{Text_box.Text}"); //Skriver över till filen som används
            Titel.Text = title;
        }

        private async Task Save_Game_Som()
        {
            file_select = true;
            saved = true;
            var fs_Picker = new FileSavePicker();
            fs_Picker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" }); //Skapar en "Plain Text" text file
            var result = await fs_Picker.PickSaveFileAsync(); //Lägger tillgågnen till filen i "result"

            if (result != null)
            {
                await Windows.Storage.FileIO.WriteTextAsync(result, $"{Text_box.Text}"); //Skriver till filen
                file = result;  //Lägger in tillgången till filen i den globala "file"
                title = result.Name; //Lägger in filnamanet i den globala "title"
                Titel.Text = title; //Sätter titeln till filnamnet
            }
        }

        private async Task Open_Game()
        {
            saved = true;
            file_select = true;
            new_page = true;
            var fo_Picker = new FileOpenPicker();
            fo_Picker.FileTypeFilter.Add(".txt");
            var result = await fo_Picker.PickSingleFileAsync();

            if (result != null)
            {
                var text = await Windows.Storage.FileIO.ReadTextAsync(result);
                Text_box.Text = text;
                file = result;
                title = result.Name;
                Titel.Text = title;
            }
        }

        private async Task Pop_Up(int operation)
        {
            MessageDialog msg = new MessageDialog("Vill du spara filen innan?");
            msg.Commands.Add(new UICommand("Ja", async x =>
            {
                if(!file_select)
                {
                    await Save_Game_Som();
                    if(operation == 0)
                    {
                        Cleaning();
                    }
                    else
                    {
                        await Open_Game();
                    }
                }
                else
                {
                    await Save_Game();
                    if(operation == 0)
                    {
                        Cleaning();
                    }
                    else
                    {
                        await Open_Game();
                    }
                }
            }));
            msg.Commands.Add(new UICommand("Nej", async x =>
            {
                if(operation == 0)
                {
                    Cleaning();
                }
                else
                {
                    await Open_Game();
                }
            }));
            msg.Commands.Add(new UICommand("Avbryt"));
            await msg.ShowAsync();
        }

        private async void Ny_Click(object sender, RoutedEventArgs e)
        {
            if(Titel.Text.EndsWith("*"))
            {
                await Pop_Up(0);
            }
            else
            {
                Cleaning();
            }
        }

        private async void Spara_Click(object sender, RoutedEventArgs e)
        {
            if (!file_select)
            {
                await Save_Game_Som();
            }
            else
            {
                await Save_Game();
            }
        }

        private async void Spara_som_Click(object sender, RoutedEventArgs e)
        {
            await Save_Game_Som();
        }

        private async void Oppna_Click(object sender, RoutedEventArgs e)
        {
            if (Titel.Text.EndsWith("*"))
            {
                await Pop_Up(1);
            }
            else
            {
                await Open_Game();
            }
        }

        private void Text_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (saved)
            {
                if(new_page)
                {
                    new_page = false;
                }
                else
                {
                    Titel.Text += "*";
                    saved = false;
                }
            }
        }
    }
}
