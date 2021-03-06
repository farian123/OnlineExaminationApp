﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using OnlineExamination.Models.Models;
using OnlineExaminationAppp.Models;

namespace OnlineExaminationAppp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(c =>
            {
                c.CreateMap<CourseCreateViewModel, Course>();
                c.CreateMap<Course, CourseCreateViewModel>();
                c.CreateMap<SearchOrganizationViewModel, Organization>();
                c.CreateMap<BatchViewModel, Batch>();
                c.CreateMap<TraineeViiewModel, Trainee>();
                c.CreateMap<ExamViewModel, Exam>();
            });
        }
    }
}
