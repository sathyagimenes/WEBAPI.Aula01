# WEBAPI.Aula01

Este repositório contém minha solução para os exercícios propostos durante o módulo Web API. Estes exercícios foram propostos para a fixação do conteúdo de API Controller, decorators, filter, injeção de dependência. <br/>

### Enunciado <br/>
1. Construa um cadastro completo (CRUD) de clientes. Neste cadastro, o cliente deve possuir cpf, nome, data de nascimento e idade.
2. Implemente na API existente de cliente toda a documentação da API utilizando os decorators visto em sala. Adicione também statuscode de retorno específicos para cada método. Realize uma validação básica nos dados recebidos do Cliente.
3. Modifique a API de Clientes trabalhada nos outros exercícios para implementar a conexão com o banco de dados. Remova as listas fixas de todos os métodos da controller e substitua pelas informações do banco de dados. Utilize a base de dados disponibilizada em sala de aula, tabela clientes já criada conforme a classe existente.
4. Filtros - Web III
 - Realize um log na APIClientes para registrar quantos segundos a ação está demorando para ser executada.

- Implemente na APIClientes uma validação de CPF na inserção. Caso o CPF já exista na base, retorne Status de Conflito.

- Implemente na APIClientes uma validação no update. Caso o registro a ser atualizado não exista, retorne status de BadRequest. Caso o registro exista e o update não consiga ser efetivado, retorne Internal Server Error.

- Implemente na APIClientes a seguintes tratativas de exceção:
```
SqlException: retorne status serviço indisponível e a mensagem: "Erro inesperado ao se comunicar com o banco de dados"
NullReferenceException: retorne status 417 e a mensagem: "Erro inesperado no sistema"
Caso não seja nenhum erro: retorne status 500 e a mensagem: "Erro inesperado. Tente novamente"
```

<br/>
<br/>

## :hammer: Como executar o programa
- Clone o repositório em uma pasta local: `git clone https://github.com/sathyagimenes/WEBAPI.Aula01.git` <br/>
- Abra a solução do projeto com o Visual Studio: arquivo `WEBAPI.Aula01.sln` <br/>
- Abra o arquivo `appsettings.json` e informe a senha para acessar o repositório e a secret key para gerar o token.
```
  "ConnectionStrings": {
        "DefaultConnection": "Server=vps40251.publiccloud.com.br;Database=base854; User Id=turma854; Password= <Digite a senha aqui> ; Encrypt=False"
        }
    "SecretKey": "<chave secreta>"
```
- Execute o projeto com `CTRL + F5`
