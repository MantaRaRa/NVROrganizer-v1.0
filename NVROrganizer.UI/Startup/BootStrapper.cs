using Autofac;
using NvrOrganizer.DataAccess;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.ViewModel;

namespace NvrOrganizer.UI.Startup
{
    public class BootStrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NvrOrganizerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<NvrDataSevice>().As<INvrDataSevice>();

            return builder.Build();
        }
    }
}
