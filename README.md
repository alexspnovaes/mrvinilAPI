# MrVinil 1.0

O MrVinil API 1.0 foi desenvolvido para atender requisitos básicos de uma aplição de compra e cashback(valor calculado a partir de um determinado percentual para calcular o valor recebido de volta na conta)
Suas funções são:
 - Consultar o catálogo de discos de forma paginada, filtrando por gênero e  ordenando de forma crescente pelo nome do disco; 
 - Consultar o disco pelo seu identificador; 
 - Consultar todas as vendas efetuadas de forma paginada, filtrando pelo range de datas (inicial e final) da venda e ordenando de forma decrescente pela data da venda; 
 - Consultar uma venda pelo seu identificador; 
 - Registrar uma nova venda de discos calculando o valor total de cashback  considerando a tabela. 
 

## Requisitos

Possuir a versão 2.2 do DOT NET Core (https://dot.net/core)
Possuir o SQL Server express instalado (https://go.microsoft.com/fwlink/?linkid=853017)
Criar uma base de dados com o nome de mrvinil
Adicionar um usuário com o nome de mrvinil com funções de leitura e escrita na base, setar a senha @2789hl123456 ou alterar para uma de preferencia no app.config do projeto de data
Rodar os migrations no projeto de infra - data (setar ele como inicial ao rodar) (Update-Database)


### Como Rodar a Aplicação
Utilizar o visual studio 2017, ao buildar pela primeira vez serão carregados suas dependências automaticamente via NUGET
Na primeira vez que o serviço for rodado, serão rodados scripts para criação de discos e alguns clientes fictícios


### Observações

Para acessar a documentação gerada pelo swagger, utilizar o seguinte link:
https://localhost:5001/swagger/index.html