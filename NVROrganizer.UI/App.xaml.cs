﻿using Autofac;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.Startup;
using NvrOrganizer.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NvrOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new BootStrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
