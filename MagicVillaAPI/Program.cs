using MagicVillaAPI.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//// create a logger, minimum level is debug and we write log into file also give path of file and rolling interval
////is every day means when new file should be created and at last create logger
////configuring the logger configuration using serilog 
//Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File
//    ("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
////tell applivation that we use serilog logger not use buildin logger
//builder.Host.UseSerilog();



// here we add AddNewtonsoftJson because we use patch method in Controller. that why support is added to the service.
builder.Services.AddControllers(option =>
{ //this means if format(json, xml) is not acceptable then we will return apopropiate error message
    //so for this code only accept json format
   // option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();//use AddXmlData..() when we want api to support XML



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////use when we add custom logger..
//builder.Services.AddSingleton<ILogging, Logging>();

var app = builder.Build();

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
