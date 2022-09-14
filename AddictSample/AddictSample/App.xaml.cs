using AddictSample.ViewModels;
using AddictSample.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddictSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ProdutosPage produtosPage = new ProdutosPage();
            produtosPage.BindingContext = new ProdutosViewModel();
            MainPage = produtosPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
