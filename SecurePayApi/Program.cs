using System.Reflection;
using Microsoft.EntityFrameworkCore;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		builder.Services.AddDbContext<SecurePayDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "SecurePayDb"));
		builder.Services.AddScoped<ISecurePayDbContext>(pro => pro.GetService<SecurePayDbContext>());
		builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();
		
		using(var scope = app.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			DataGenerator.Initialize(services);
		}

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}