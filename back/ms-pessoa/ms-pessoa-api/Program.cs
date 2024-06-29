using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ms_pessoa_domain.Interfaces.Services;
using ms_pessoa_domain.Services;
using ms_pessoa_infra.Contexts;
using ms_pessoa_infra.Interfaces.Repositories;
using ms_pessoa_infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MsPessoaContexto>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IPessoaService, PessoaService>();
builder.Services.AddTransient<ILoginService, LoginService>();

builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MS - Pessoa API",
        Version = "v1",
        Description = "API REST criada com o ASP.NET Core 6.0 para gerenciar pessoa"
    });
});

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
