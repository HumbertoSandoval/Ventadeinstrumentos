using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using C8ProyectoFinalPorEquipos.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace C8ProyectoFinalPorEquipos
{
    public class Program
    {
        public static void Main(string[] args)
    {
      CrearBaseDeDatos();
      CreateWebHostBuilder(args).Build().Run();
    }

    private static void CrearBaseDeDatos()
    {
      using (var db = new SqliteDbContext())
      {
        db.Database.EnsureCreated();
      }
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
