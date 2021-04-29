using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Staffisher.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnSignUpTapped(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new SignUpPage(), this);
            await Navigation.PopAsync();
        }

        private async void OnLogInClicked(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            string email = emailEntry.Text.Trim();

            if (email.Length == 0 || passwordEntry.Text.Length == 0)
            {
                errorLabel.Text = "All Fields Must Be Filled";
                return;
            }

            Classes.Angler angler = ValidateEmail(email);
            if (angler == null) return;
            if (!ValidatePassword(angler)) return;

            App.User = angler;
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        private Classes.Angler ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                errorLabel.Text = "Email Is Invalid";
                return null;
            }

            Predicate<Classes.Angler> predicate = (Classes.Angler predicateAngler) =>
            {
                return predicateAngler.Email == email;
            };

            Classes.Angler angler = App.Anglers.Find(predicate);

            if (angler == null)
            {
                errorLabel.Text = "Email Or Password Incorrect";
                return null;
            }

            return angler;
        }

        private bool ValidatePassword(Classes.Angler angler)
        {
            if (App.GetHash(passwordEntry.Text.Trim()) != angler.PasswordHash)
            {
                errorLabel.Text = "Email Or Password Incorrect";
                return false;
            }
            return true;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
