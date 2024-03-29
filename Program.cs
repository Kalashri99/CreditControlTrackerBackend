using CreditContolTrackerAPIs.Interface;
using CreditContolTrackerAPIs.Models;
using CreditContolTrackerAPIs.Repository;
using CreditControlTrackerAPIs.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
    //.
    //AddNewtonsoftJson(options =>
    //{
    //    options.SerializerSetting.RefernceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    //});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddScoped<ApplicationDbContextFactory>((provider) =>
{
    var dbContextOptions = provider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
    return new ApplicationDbContextFactory(dbContextOptions);
});
builder.Services.AddScoped<excelGrid>();
builder.Services.AddScoped<IDropdownRepository,DropdownRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin", p =>
    {
        p.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

//builder.Services.AddCors();
//app.UseCors(x => x

//.AllowAnyMethod()

//.AllowAnyHeader()

//.SetIsOriginAllowed(origin => true) // allow any origin

//                .AllowCredentials()); // allow credentials




// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseCors("AllowMyOrigin");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
