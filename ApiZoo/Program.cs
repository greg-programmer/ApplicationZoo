using ApiZoo.Repository;
using ApiZoo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using ZooLibrary.Data;
using ZooLibrary.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "zooApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
        }
    });
});
// on r�cup�re la cl� et on l'encode
var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true, // utilisation d'une cl� crypt�e pour la s�curit� du token
            IssuerSigningKey = new SymmetricSecurityKey(key), // cl� crypt�e en elle m�me
            ValidateLifetime = true, // v�rification du temps d'expiration du Token
            ValidateAudience = true, // v�rification de l'audience du token
            ValidAudience = "http",
            ValidateIssuer = true, // v�rification du donneur du token
            ValidIssuer = "zoo", // le donneur
            ClockSkew = TimeSpan.Zero // d�callage possible de l'expiration du token
        };
    });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("User", policy =>
//    {
//        policy.RequireClaim(ClaimTypes.Role, "User");
//    });
//    options.AddPolicy("User", policy =>
//    {
//        policy.RequireClaim(ClaimTypes.Role, "User");
//        //ClaimTypes nous permet d'avoir des valeur normalis�es pour nos claims (pr�d�finies par des conventions)
//        //policy.RequireClaim("EstUnDresseurPokemon", "true"); 
//        // on peut ajouter la v�rification d'autres claims si n�cessaire
//    });
//});
string connectionstring = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
builder.Services.AddScoped<IRepository<Specie>, SpecieRepository>();
builder.Services.AddScoped<IServiceAnimal, ServiceAnimal>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddScoped<IUserService, UserService>();
// ajouter le service IMapper de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
