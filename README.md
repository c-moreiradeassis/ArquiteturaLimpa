# ArquiteturaLimpa
Projeto desenvolvido com base na arquitetura limpa.

Antes de executar o projeto, será necessário executar os comandos para criar a base de dados. Acesse o projeto ArquiteturaLimpa.Infra.Repositorio no Visual Studio Code. Após isso, execute os comandos:

dotnet ef --startup-project ..\ArquiteturaLimpa.API\ migrations add init

dotnet ef --startup-project ..\ArquiteturaLimpa.API\ database update
