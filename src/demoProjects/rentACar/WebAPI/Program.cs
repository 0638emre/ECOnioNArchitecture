using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
#region servisregistration IOC yap�lanmas�
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddSecurityServices();
//builder.Services.AddInfrastructureServices();

#endregion
//builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region middleware olarak �al���yor ve d�nen hata mesaj�n� config etti�imiz �ekilde d�nd�r�yor development taraf�nda hatalar� g�rmek i�in kapat�r�z.
if (!app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
