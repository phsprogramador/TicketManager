using Application.Services;
using Autofac;
using TicketManager.Application.Interfaces;
using TicketManager.Application.Services;
using TicketManager.Domain.Interfaces;
using TicketManager.Infrastructure.Repositories;

namespace TicketManager.CrossCutting.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region SERVICE
            builder.RegisterType<StatusService>().As<IStatusService>();
            builder.RegisterType<TicketService>().As<ITicketService>();
            builder.RegisterType<UserService>().As<IUserService>();
            #endregion

            #region IOC REPOSITORY
            builder.RegisterType<StatusRepository>().As<IStatusRepository>();
            builder.RegisterType<TicketRepository>().As<ITicketRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            #endregion
        }
    }
}
