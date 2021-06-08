using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorManager>().As<IDoctorService>();
            builder.RegisterType<EfDoctorDal>().As<IDoctorDal>();

            builder.RegisterType<HospitalManager>().As<IHospitalService>();
            builder.RegisterType<EfHospitalDal>().As<IHospitalDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AppointmentManager>().As<IAppointmentService>();
            builder.RegisterType<EfAppointmentDal>().As<IAppointmenDal>();

            builder.RegisterType<BranchManager>().As<IBranchService>();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>();

            builder.RegisterType<DoctorImageManager>().As<IDoctorImageService>();
            builder.RegisterType<EfDoctorImageDal>().As<IDoctorImageDal>();

            builder.RegisterType<HotelManager>().As<IHotelService>();
            builder.RegisterType<EfHotelDal>().As<IHotelDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //builder.RegisterType<FileHelper>().As<IHelper>();

            //builder.RegisterType<EfUserImage>().As<IUserImageDal>();
            //builder.RegisterType<UserImageManger>().As<IUserImageService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
