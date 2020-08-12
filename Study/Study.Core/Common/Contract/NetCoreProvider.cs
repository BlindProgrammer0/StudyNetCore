using Autofac;

namespace Study.Core.Common.Contract
{
    /// <summary>
    /// 服务提供者
    /// </summary>
    public class NetCoreProvider
    {
        public static IContainer Instance { get; private set; }

        public static void RegisterServiceLocator(IContainer locator)
        {
            if (Instance == null)
                Instance = locator;
        }

        public static void Get<T>(out T result)
        {
            if (Instance == null) _ = default(T);
            result = Instance.Resolve<T>();
        }

        public static void Get<T>(string typeName, out T result)
        {
            result = Instance.ResolveNamed<T>(typeName);
        }

        public void InitLog() 
        {
           
        }
    }
}
