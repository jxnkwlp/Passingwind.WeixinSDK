using System.Collections.Generic;
using TinyIoC;

namespace Passingwind.Weixin.Dependency
{
    public static class DependencyManager
    {
        private static readonly TinyIoCContainer _container = TinyIoCContainer.Current;

        static DependencyManager()
        {
            _container.AutoRegister();
        }

        public static void Register<TServiceType>() where TServiceType : class
        {
            _container.Register<TServiceType>();
        }

        public static void Register<TServiceType, TImplServiceType>()
            where TServiceType : class
            where TImplServiceType : class, TServiceType
        {
            _container.Register<TServiceType, TImplServiceType>();
        }

        public static TServiceType Resolve<TServiceType>() where TServiceType : class
        {
            return _container.Resolve<TServiceType>();
        }

        public static IEnumerable<TServiceType> ResolveAll<TServiceType>() where TServiceType : class
        {
            return _container.ResolveAll<TServiceType>();
        }
    }
}
