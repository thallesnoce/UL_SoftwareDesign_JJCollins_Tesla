using AutoMapper;
using SoftwareDesign.ControllerLayer.Business.Interceptor;
using SoftwareDesign.ControllerLayer.Business.Interceptor_Client;
using SoftwareDesign.DTO;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SoftwareDesign.ControllerLayer.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            MainClientClass.RegisterClientClass();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClientEntity, ClientDTO>();
                cfg.CreateMap<DestinationEntity, DestinationDTO>();

                cfg.CreateMap<EnquireEntity, EnquireDTO>();
                cfg.CreateMap<HotelEntity, HotelDTO>();

                cfg.CreateMap<PackageEntity, PackageDTO>();
                cfg.CreateMap<ReportEntity, ReportDTO>();

                cfg.CreateMap<TransportEntity, TransportDTO>();
                cfg.CreateMap<UserEntity, UserDTO>();
            });
        }
    }
}