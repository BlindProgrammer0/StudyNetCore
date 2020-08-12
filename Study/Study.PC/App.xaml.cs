using Autofac;
using Study.Common.Helper;
using Study.Common.Interfaces;
using Study.Core.Common.Contract;
using Study.Core.Interfaces;
using Study.PC.ViewCenter;
using Study.Service;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Study.PC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            Contract.ServerUrl = ConfigurationManager.AppSettings["ServerAddress"];
            var container = ConfigureServices();
            NetCoreProvider.RegisterServiceLocator(container);
            LoginCenter viewCenter = new LoginCenter();
            await viewCenter.ShowDialog();
        }

        private IContainer ConfigureServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsumptionService>().As<IConsumptionService>();
            builder.RegisterInstance<ILog>(NLogHelper.Instance());
            var assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes();

            //builder.RegisterTypes(types);

            foreach (var t in types)
            {
                if (t.Name.EndsWith("Center")) //简陋判断一下,一般而言,该定义仅仅注册Center结尾的类依赖关系。
                {
                    var firstInterface = t.GetInterfaces().FirstOrDefault();
                    if (firstInterface != null)
                        builder.RegisterType(t).Named(t.Name, firstInterface);
                }
            }
            return builder.Build();
        }

        

    }
}
