using Blog.Business.Abstract;
using Blog.Business.Concrate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Blog.WebAPI;
using Blog.DataAccess.Concrete.EntityFramework;
using Blog.DataAccess.Abstract;
using FluentValidation.AspNetCore;
using Blog.Business.ValidationRules;

namespace Blog.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {services.AddAutoMapper(typeof(Startup));
            
            services.AddControllers();
            services.AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<AuthorAddValidator>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.WebAPI", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IAuthorService, AuthorManager>();
            services.AddTransient<IAuthorDal, EfAuthorRepository>();

            services.AddTransient<IPostService, PostManager>();
            services.AddTransient<IPostDal, EfPostRepository>();

            services.AddTransient<ICommentService, CommentManager>();
            services.AddTransient<ICommentDal, EfCommentRepository>();

            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICategoryDal, EfCategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
