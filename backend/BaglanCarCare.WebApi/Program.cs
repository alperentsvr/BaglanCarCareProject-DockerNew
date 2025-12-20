using BaglanCarCare.Application;
using BaglanCarCare.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models; // <-- BU EKLENDÝ (Swagger Modelleri Ýçin)
using System.Text;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. KATMANLAR
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

// 2. JWT TOKEN AYARLARI
var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// =========================================================================
// 3. SWAGGER AYARLARI (KÝLÝT BUTONU ÝÇÝN BURASI DEÐÝÞTÝ)
// =========================================================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Baglan Car Care API", Version = "v1" });

    // Kilit (Authorize) Butonunu Tanýmlýyoruz
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                      "Kullanýmý: Kutucuða 'Bearer' yazýp boþluk býrakýn ve token'ý yapýþtýrýn. \r\n\r\n" +
                      "Örnek: 'Bearer eyJhbGciOiJIUzI1Ni...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Bu güvenliði tüm endpointlere uyguluyoruz
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
// =========================================================================

builder.Services.AddCors(o => o.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Seed (Otomatik Veri Yükleme)
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<BaglanCarCare.Persistence.Contexts.BaglanCarCareDbContext>();

    // EKLENECEK SATIR: Veritabaný yoksa oluþturur, varsa eksik tablolarý günceller.
    ctx.Database.Migrate();

    await BaglanCarCare.Persistence.Seeds.ContextSeed.SeedAsync(ctx);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication(); // Kimlik Doðrulama
app.UseAuthorization();  // Yetkilendirme

app.MapControllers();

app.Run();