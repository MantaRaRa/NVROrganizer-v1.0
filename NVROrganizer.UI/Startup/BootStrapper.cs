﻿using Autofac;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.ViewModel;

namespace NvrOrganizer.UI.Startup
{
    public class BootStrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NvrDataSevice>().As<INvrDataSevice>();

            return builder.Build();
        }
    }
}