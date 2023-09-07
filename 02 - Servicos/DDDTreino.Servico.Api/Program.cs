using DDDTreino.Aplicao;
using DDDTreino.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
InjetorDependencias.Registrar(builder.Services);
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntidade()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseCors(a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseMvc();
app.MapControllers();

app.Run();
