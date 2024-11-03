
// Classe de entrada da aplicação
var builder = WebApplication.CreateBuilder(args);// Cria o builder da aplicação

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
// Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte a controladores
builder.Services.AddSwaggerGen(); // Configura geração de documentação da API com Swagger.

var app = builder.Build();// Cria a aplicação

// Habilita o Swagger e sua interface na fase de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Ativa a geração de documentação Swagger para a API.
    app.UseSwaggerUI(); // Configura a interface do usuário do Swagger para interagir com a API.
}

app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS

app.UseAuthorization(); // Habilita autorização

app.MapControllers(); // Mapeia os controladores

app.Run(); // Inicia a aplicação


