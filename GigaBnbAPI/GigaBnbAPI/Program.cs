using GigaBnB.Business.Filters;
using GigaBnB.Business.Validation;
using GigaBnB.DataAccess;
using GigaBnbAPI.Extensions;
using GigaBnbAPI.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLog4Net();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationExceptionFilterAttribute>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddRepository();
builder.Services.AddServices();
builder.Services.AddTransient<ExceptionHandlerMiddleware>();
builder.Services.AddScoped<IValidation, ValidationDictionary>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionHandlerMiddleware();

app.MapControllers();

app.Run();
