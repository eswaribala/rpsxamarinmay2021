
using SQLite;
using StackLayoutForm.Models;
using StackLayoutForm.Persistence;
using StackLayoutForm.ViewModels;
using StackLayoutForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackLayoutForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
       

        public Login()
        {
            // InitializeComponent();
           
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.ValidLoginPrompt += () =>
            {
                this.Navigation.PushAsync(new HomePage());
            };
            
            InitializeComponent();
            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RegisterPage());
        }

        
    }
}