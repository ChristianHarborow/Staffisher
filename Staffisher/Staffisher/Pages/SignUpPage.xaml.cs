using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Staffisher.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnLogInTapped(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            bool signUpFailed = false;
            errorLabel.Text = "";
            
            if (emailEntry.Text.Length == 0 || usernameEntry.Text.Length == 0 || passwordEntry.Text.Length == 0 || confirmPasswordEntry.Text.Length == 0)
            {
                errorLabel.Text += "All Fields Must Be Filled";
                signUpFailed = true;
            }

            signUpFailed = ValidateEmail(signUpFailed);
            signUpFailed = ValidatePassword(signUpFailed);

            if (signUpFailed) return;

            App.Anglers.Add(new Classes.Angler(emailEntry.Text, App.GetHash(passwordEntry.Text), usernameEntry.Text));

            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        private bool ValidatePassword(bool signUpFailed)
        {
            if (passwordEntry.Text != confirmPasswordEntry.Text)
            {
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Passwords Must Match";
                return true;
            }
            if (passwordEntry.Text.Length < 8)
            {
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Passwords Must Contain At Least 8 Characters";
                return true;
            }
            return signUpFailed;
        }

        private bool ValidateEmail(bool signUpFailed)
        {
            if (!Regex.IsMatch(emailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                // Should also send email to check if valid
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Email Is Invalid";
                signUpFailed = true;
                return signUpFailed;
            }
            
            Predicate<Classes.Angler> predicate = (Classes.Angler predicateAngler) =>
            {
                return predicateAngler.Email == emailEntry.Text;
            };

            Classes.Angler angler = App.Anglers.Find(predicate);
                
            if (angler != null)
            {
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Email Already In Use";
                signUpFailed = true;
            }

            return signUpFailed;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}