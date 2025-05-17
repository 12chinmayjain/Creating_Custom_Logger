
namespace Checking_Logger_Checking_Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var instance = FileLogger.Logger.Instance;
            instance.Log("Starting");
            // Add services to the container.
            instance.Log("AddController");
            builder.Services.AddControllers();
            instance.Log("AddSwagger");
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            var instance1 = FileLogger.Logger.Instance; // creating intance don't matter singleton same instance working
            instance1.Log("After build");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            instance1.Log("After Redirection");
            app.UseAuthorization();
            instance1.Log("After Authorization");

            app.MapControllers();
            instance1.Log("After Mapping controllers");
            app.Run();

            var instance2 = FileLogger.Logger.Instance;
            instance2.Log("After run");
        }
    }
}
