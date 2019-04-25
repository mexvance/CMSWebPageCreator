using CMSWebPageCreator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSWebPageCreator
{
    public class CmsUrlConstraint : IRouteConstraint
    {
        private readonly IConfiguration configuration;

        public CmsUrlConstraint(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

            
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[routeKey] != null)
            {
                var permalink = values[routeKey].ToString();
                var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
                optionsBuilder.UseSqlite(configuration.GetConnectionString("DBContext"));
                var dbContext = new DBContext(optionsBuilder.Options);
                var page = dbContext.PageCreate.FirstOrDefault(p => p.Title == permalink);
                if(page != null)
                {
                    httpContext.Items["cmspage"] = page;
                    return true;
                }
            }
            return false;
        }
    }
}
