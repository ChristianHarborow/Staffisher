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
            string email = emailEntry.Text.Trim();
            string username = usernameEntry.Text.Trim();
            string password = passwordEntry.Text.Trim();
            string confirmPassword = confirmPasswordEntry.Text.Trim();


            if (email.Length == 0 || username.Length == 0 || password.Length == 0 || confirmPassword.Length == 0)
            {
                errorLabel.Text += "All Fields Must Be Filled";
                signUpFailed = true;
            }

            signUpFailed = ValidateEmail(email, signUpFailed);
            signUpFailed = ValidatePassword(password, confirmPassword, signUpFailed);

            if (signUpFailed) return;

            Classes.Angler angler = new Classes.Angler(email, App.GetHash(password), username);
            App.Anglers.Add(angler);
            App.SerializeAnglers();
            App.User = angler;
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        private bool ValidateEmail(string email, bool signUpFailed)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                // Should also attempt to send email to check if valid
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Email Is Invalid";
                return true;
            }
            
            Predicate<Classes.Angler> predicate = (Classes.Angler predicateAngler) =>
            {
                return predicateAngler.Email == email;
            };

            Classes.Angler angler = App.Anglers.Find(predicate);
                
            if (angler != null)
            {
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Email Already In Use";
                return true;
            }

            return signUpFailed;
        }

        private bool ValidatePassword(string password, string confirmPassword, bool signUpFailed)
        {
            if (password != confirmPassword)
            {
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Passwords Must Match";
                return true;
            }
            if (password.Length < 8)
            {
                errorLabel.Text += (signUpFailed ? "\n" : "") + "Passwords Must Contain At Least 8 Characters";
                return true;
            }
            return signUpFailed;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}