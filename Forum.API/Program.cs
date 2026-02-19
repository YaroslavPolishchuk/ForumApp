using Forum.Application;
using Forum.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();
builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration.GetConnectionString("DefCon")!);




//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
//app.UseHttpsRedirection(); 

//app.UseAuthentication();
app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseAuthorization();
//app.UseMiddleware<DummyMiddleWare>();
//app.UseMiddleware<JwtProviderMiddleware>();

app.MapGet("/", () => "Forum API is running...");
app.MapHealthChecks("/health");
app.UsePathBase("/api");
app.MapControllers();

app.Run();
