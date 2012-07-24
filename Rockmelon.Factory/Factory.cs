using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using Ninject.Injection;
using Rockmelon.Repository;
using Ninject.Extensions.Conventions;

namespace Rockmelon
{
    public class Factory : IIocContainer
    {
        public readonly IKernel Kernel;
        public Factory(params INinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);           
        }
             
        public Factory()
        {
            Kernel = new StandardKernel();
            Kernel.Bind(x => x
                .FromAssembliesMatching("*")
                .SelectAllClasses()
                .BindDefaultInterface());                  
        }

        /// <summary>
        /// Replace interface mapping -clear all and then add
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        public void Register<T>(object type)
        {
            Kernel.Rebind<T>().To(type.GetType());
        }

        /// <summary>
        /// Add to the implentations of a particular interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        public void RegisterExtra<T>(object type)
        {
            Kernel.Bind<T>().To(type.GetType());
        }

        public object Get(Type type)
        {
            try
            {
                return Kernel.Get(type);
            }
            catch (ActivationException exception)
            {
                throw exception;
            }
        }

        public T TryGet<T>()
        {
            return Kernel.TryGet<T>();
        }

        public T Get<T>()
        {
            try
            {
                return Kernel.Get<T>();
            }
            catch (ActivationException exception)
            {
                throw exception;
            }
        }

        public T Get<T>(string name, string value)
        {
            var result = Kernel.TryGet<T>(metadata => metadata.Has(name) &&
                         (string.Equals(metadata.Get<string>(name), value,
                                        StringComparison.InvariantCultureIgnoreCase)));

            if (Equals(result, default(T))) throw new ActivationException(null);
            return result;
        }

        public void Inject(object item)
        {
            Kernel.Inject(item);
        }

    }

}
