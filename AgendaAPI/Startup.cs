using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AgendaContext>(options => options.UseInMemoryDatabase("Agenda"));
            services.AddCors();
            services.AddMvc();


        }

        private void AddTesteData(AgendaContext context)
        {
            context.Professores.Add(new Professor { Nome = "Charles", Email = "charles@agenda.com" });
            context.Professores.Add(new Professor { Nome = "Carreiro", Email = "carreiro@carreiro.com" });

            context.Cursos.Add(new Curso { Nome = "C#", CargaHoraria = 8, Descricao = "Curso de C#" });
            context.Cursos.Add(new Curso { Nome = "Angular", CargaHoraria = 8, Descricao = "Curso de Angular" });

          

            context.Turmas.Add(new Turma
            {
                Nome = "Turma 2017",
                Local = "Ventutus",
                CursoId = 1,
                ProfessorId = 1
            });

            context.Turmas.Add(new Turma
            {
                Nome = "Turma 2018",
                Local = "Ventutus",
                CursoId = 1,
                ProfessorId = 1
            });

              context.SaveChanges();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AgendaContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AddTesteData(context);

            app.UseMvc();
        }
    }
}
