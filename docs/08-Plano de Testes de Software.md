# Plano de Testes de Software

Os requisitos para realização dos testes são:

- Navegador da Internet - Chrome, Firefox, Edge, Opera e Safari.
- Conectividade de Internet para acesso à plataforma.


Os testes funcionais a serem realizados no aplicativo são descritos a seguir.
 
| **Caso de Teste** 	| **CT-01 – Cadastro de Usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 - A aplicação deve oferecer gerenciamento de usuários. |
| Objetivo do Teste 	| Verificar se o usuário consegue efetuar cadastro na aplicação. |
| Passos 	| - Acessar navegador <br> - Informar o endereço do site<br> - Preencher os campos obrigatórios (e-mail, usuário e senha) <br> - Clicar em "Login" |
|Critério de Êxito | - O usuário se cadastra com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-02 – Login de Usuário	|
|Requisito Associado | RF-02	- A aplicação deve permitir que usuários pré-cadastrados realizem login. |
| Objetivo do Teste 	| Verificar se o usuário consegue efetuar Login na aplicação. |
| Passos 	| - Acessar navegador <br> - Informar o endereço do site<br> - Preencher corretamente os campos obrigatórios (Nome de usuário e senha) <br> - Clicar em "Login" |
|Critério de Êxito | - O login foi realizado com sucesso. |
|  	|  	|
| Caso de Teste 	| CT-03 – Editar Usuário	|
|Requisito Associado | RF-01	- A aplicação deve oferecer gerenciamento de usuários. |
| Objetivo do Teste 	| Verificar se o usuário consegue editar suas informações de perfil(Nome de usuário, e-mail e senha. |
| Passos 	| - Acessar navegador <br> - Informar o endereço do site<br> - Preencher corretamente os campos obrigatórios (Nome de usuário e senha) <br> - Clicar em "Login" <br> - Clicar no ícone de perfil no canto superior esquerdo <br> - Selecionar "Editar" <br> - Efetuar as mudanças desejadas na conta <br> - Clicar em "Salvar" |
|Critério de Êxito | - O usuário conseguiu alterar os dados desejados. |
|  	|  	|
|  	|  	|
| Caso de Teste 	| CT-04 – Criação de Projetos	|
|Requisito Associado | RF-03	- A aplicação deve permitir o gerenciamento de projetos. Quando um projeto for criado, a esse projeto serão associadas 5 colunas fixas, nas quais será possível alterar o nome e a cor. |
| Objetivo do Teste 	| Verificar se o usuário consegue criar projetos. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Realizar login <br> - Acessar tela principal de projetos <br> - Clicar em "+Novo" na barra lateral esquerda <br> - Preencher os dados do projeto <br> - Clicar em novo |
|Critério de Êxito | - O usuário consegue criar o projeto desejado. |
|  	|  	|
| Caso de Teste 	| CT-05 – Visualização de Projetos	|
|Requisito Associado | RF-03	- A aplicação deve permitir o gerenciamento de projetos. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar seus projetos. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Realizar login <br> - Acessar tela principal de projetos |
|Critério de Êxito | - O usuário consegue acessar a tela inicial e visualizar todos os seus projetos. |
|  	|  	|
| Caso de Teste 	| CT-06 – Gerenciamento de Projetos	|
|Requisito Associado | RF-03	- A aplicação deve permitir o gerenciamento de projetos. |
| Objetivo do Teste 	| Verificar se o usuário consegue acessar seus projetos para possíveis edições. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Realizar login <br> - Acessar tela principal de projetos <br> - Selecionar projeto desejado <br> - Renomear projeto desejado <br> - Excluir o projeto |
|Critério de Êxito | - O usuário consegue acessar a tela inicial alterar/excluir o projeto desejado. |
|  	|  	|
| Caso de Teste 	| CT-07 – Gerenciamento de Tarefas	|
|Requisito Associado | - RF-04	- A aplicação deve permitir o gerenciamento das tarefas dentro do projeto, no qual toda tarefa criada deverá obrigatoriamente ser associada a uma coluna. <br> - RF-06	- A aplicação deve permitir que seja alterado o status das tarefas entre as colunas. |
| Objetivo do Teste 	| Verificar se o usuário consegue manipular as tarefas do projeto. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Realizar login <br> - Acessar tela principal de projetos <br> - Selecionar projeto desejado <br> - Excluir ou adicionar tarefa |
|Critério de Êxito | - O usuário consegue manipular as tarefas do projeto. |
|  	|  	|
| Caso de Teste 	| CT-08 – Visualização de detalhes das tarefas	|
|Requisito Associado | - RF-05 – As tarefas deverão ter campo de título, descrição, cor referente a prioridade e nome da pessoa a quem a mesma foi atribuída. <br> - RF-07 – A aplicação deverá permitir aos que os usuários vejam os detalhes da tarefa para ter acesso a descrição completa e as demais informações inseridas. |
| Objetivo do Teste 	| Verificar se o usuário tem acesso a todas as informações vinculadas às tarefas. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Realizar login <br> - Acessar tela principal de projetos <br> - Selecionar projeto desejado <br> - Visualizar a tarefa desejada |
|Critério de Êxito | - O usuário consegue acessar e visualizar todos os detalhes das tarefas desejadas. |
|  	|  	|
| Caso de Teste 	| CT-09 – Alteração de Status de Tarefas	|
|Requisito Associado | RF-08	- A aplicação deverá permitir a visualização do andamento do projeto por meio de informações como a porcentagem de progresso, total geral de tarefas e total de tarefas em cada coluna. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar os dados gerais do projeto desejado. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site<br> - Realizar login <br> - Acessar tela principal de projetos <br> - Selecionar projeto desejado <br> - Selecionar tarefa desejada <br> - Movimentar a tarefa entre colunas |
|Critério de Êxito | - O usuário consegue alterar os status da tarefa desejada. |
