using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PasswordGenerator
{
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            //Creates a random variable and a password variable
            Random r = new Random();
            String password = "";

            //creates a 15 letter password of whatever the user checks in the checkboxes before outputting it to the text field
            for (int i = 0; i < 15; i++)
            {

                    String valid = "";
                    if (SpecialCheck.IsChecked == true)
                    {
                        valid += "!\"#$%@&()[]{}<>^?/\\;:`~-_=+*";
                    }

                    if (NumCheck.IsChecked == true)
                    {
                        valid += "1234567890";
                    }

                    if (UpperCheck.IsChecked == true && LowerCheck.IsChecked == false)
                    {
                        valid += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    }
                    else if (UpperCheck.IsChecked == false && LowerCheck.IsChecked == true)
                    {
                        valid += "abcdefghijklmnopqrstuvwxyz";
                    }
                    else
                    {
                        valid += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    }

                    if (SpecialCheck.IsChecked == false && NumCheck.IsChecked == false && UpperCheck.IsChecked == false && LowerCheck.IsChecked == false)
                    {
                        valid += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%@&()[]{}<>^?/\\;:`~-_=+*";
                    }
                    int num = r.Next(0, valid.Length);
                    password += valid[num];
            }
            try
            {
                PasswordText.Text = password;
            }
            catch (Exception e)
            {
                PasswordText.Text = "Something went wrong! Try again!";
            }
            
        }
    }
}
