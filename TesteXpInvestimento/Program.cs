
// Classe de entrada da aplica��o
var builder = WebApplication.CreateBuilder(args);// Cria o builder da aplica��o

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();
// Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte a controladores
builder.Services.AddSwaggerGen(); // Configura gera��o de documenta��o da API com Swagger.

var app = builder.Build();// Cria a aplica��o

// Habilita o Swagger e sua interface na fase de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Ativa a gera��o de documenta��o Swagger para a API.
    app.UseSwaggerUI(); // Configura a interface do usu�rio do Swagger para interagir com a API.
}

app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS

app.UseAuthorization(); // Habilita autoriza��o

app.MapControllers(); // Mapeia os controladores

app.Run(); // Inicia a aplica��o


