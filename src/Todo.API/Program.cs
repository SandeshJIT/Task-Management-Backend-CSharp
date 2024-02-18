using FluentValidation.AspNetCore;
using System.Reflection;
using Todo.API;
using Todo.API.Controllers;
 
namespace Todo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = Startup.CreateWebApplication(args);
            app.Run();
        }
    }
}

