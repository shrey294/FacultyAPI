using FacultyAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddDbContext<Ang_CrudContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// this code to allow angular app to request resourse.
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAngularApp", policy =>
	{
		policy.WithOrigins("http://localhost:4200", "https://shrey294.github.io")
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// this code to allow angular app to request resourse. 

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();