﻿using OP.ContactsApp.Views;
using Plugin.ContactService;
using SimpleInjector;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OP.ContactsApp
{
    public partial class App : Application
    {
        private readonly Container _container;

        public App()
        {
            InitializeComponent();
            _container = new Container();
            ConfigurContainer(_container);
            var mainPage = _container.GetInstance<ContactsListView>();
            MainPage = mainPage;
        }

        private void ConfigurContainer(Container container)
        {
            container.Register<IContactService>(() => CrossContactService.Current);
        }
    }
}
