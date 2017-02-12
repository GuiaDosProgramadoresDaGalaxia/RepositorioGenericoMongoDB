# RepositorioGenericoMongoDB
Repositorio génerico criado no molde do repositorio para Entity Framework, mantendo a principal estrutura e um sistema de indentificação de coleções, contem um simples UnityOfWork para manter apenas um objeto de acesso ao banco de dados.

#Como usar a biblioteca
- Instale pelo nuget (Install-Package BibliotecaSubeta.Mongo) em todas as suas camadas.

**Em suas entidades**

Você deve herdar da classe 'Entidade' e usar o atributo 'Colecao' para especificar o nome da coleção onde os dados serão salvos no DB.
```csharp
[Colecao("Clientes")]
public class Cliente
{
  public string Nome { get; set; }
  .
  .
  .
}
```
Em seguida coloque a connection string no seu arquivo App.Congif
```xml
<connectionStrings>
    <add name="MongoContexto" connectionString="mongodb://localhost/databaseName" />
</connectionStrings>
```
Agora crie uma classe de contexto para seu programa e passe o nome da conexão, basta herdar da classe Contexto que está na biblioteca
```csharp
public class ProgramaContexto : Contexto
{
  public ProgramaContexto() : base("MongoContexto")
  {
  }
}
```
Agora é só utilizar a classe Repositorio ou a interface IRepositorio (para injeção de dependencia)
```csharp
var repositorio = new Repositorio<ProgramaContexto>(new ProgramaContexto());
var cliente = new Cliete { Nome = "Subeta" };
repositorio.Criar(cliente); //Já foi salvo no banco.
```
# Documentação
- Metodos de escrita
  * Criar(entidade)
  * Atualizar(entidade)
  * Remover(id)

- Metodos de query
  * ObterXXX(filtro, ordernacao, skip, take) //Expressões lambdas

A biblioteca possui suporte para ações assincronas, basta acrescentar 'Async' nos metodos:
```csharp
await repositorio.CriarAsync(cliente);
await repositorio.ObterTodosAsync(c => c.Idade > 18);
```

# Estrutura
O projeto está organizado segundo o DDD e a camada de teste (apresentação) de acordo com o MVVM.

#Requisitos
MongoDB rodando em LocalHost, .Net 4.5, Visual Studio 2015.

#Referencias
Não deixe de olhar o projeto do Repositorio Generico para Entity Framework e comparar as interfaces e codigos dos dois repositorios, 70% da mecanica foi deixada igual. É muito facil mudar de banco utilizando esses repositorio.

https://github.com/GuiaDosProgramadoresDaGalaxia/RepositorioGenerico
