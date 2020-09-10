using System.Web.Mvc;
using BookStore.Context;
using BookStore.Repositorios;
using BookStore.Repositorios.Interfaces;
using Unity;
using Unity.Mvc5;

namespace BookStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<BookStoreDataContext, BookStoreDataContext>();
            container.RegisterType<IAutorRepositorio, AutorRepositorio>();
            container.RegisterType<ILivroRepositorio, LivroRepositorio>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}