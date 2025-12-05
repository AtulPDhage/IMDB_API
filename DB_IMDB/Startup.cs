using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB_IMDB.Repository.Interface;
using DB_IMDB.Repository;
using DB_IMDB.Service.Interface;
using DB_IMDB.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using DB_IMDB.Model.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DB_IMDB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

  
        public void ConfigureServices(IServiceCollection services)
        {
  
            services.AddControllers();
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));

            services.AddSingleton<SupabaseService>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var url = configuration["Supabase:Url"];
                var key = configuration["Supabase:Key"];
                return new SupabaseService(url, key);
            });

         
            services.AddSingleton<IGenreRepository, GenreRepository>();
            services.AddSingleton<IGenreService, GenreService>();
           

            
            services.AddSingleton<IActorRepository, ActorRepository>();
            services.AddSingleton<IActorService, ActorService>();

           
            services.AddSingleton<IMovieRepository, MovieRepository>();
            services.AddSingleton<IMovieService, MovieService>();

      
            services.AddSingleton<IProducerRepository, ProducerRepository>();
            services.AddSingleton<IProducerService, ProducerService>();

            
            services.AddSingleton<IReviewRepository, ReviewRepository>();
            services.AddSingleton<IReviewService, ReviewService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DB_IMDB", Version = "v1" });
     
            });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DB_IMDB v1"));
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
