# Plano de Testes de Usabilidade
Testes de usabilidade são formas de verificar as funcionalidades da interface de uma plataforma digital. Observando interações de voluntários reais com a aplicação sob estudo, é possível diagnosticar erros e identificar problemas relacionados à clareza, eficiência e eficácia da navegação.
O plano de testes será composto respectivamente pelos seguintes itens: Método de teste, objetivos do teste, perfil dos usuários, requisitos do teste, método de mensura e roteiro detalhado a ser seguido pelos usuários voluntários.

Para o projeto em questão, será utilizado o modelo de **Testes Remotos Não Moderados de Usabilidade**.

## Testes Remotos Moderados de Usabilidade
Nesse teste os participantes realizam os estudos diretamente em seus próprios dispositivos, como tablets, smartphones e notebooks sem o acompanhamento de um auxiliar. Por se tratar de um teste online, custa um valor significativamente mais baixo, além de permitir que o usuário voluntário se sinta confortável e mais propício a agir naturalmente.
Serão utilizados dois métodos para otimizar a busca de eventuais problemas de interface: Descoberta de Problemas e Teste de Aprendizado. Os mesmos serão tratados como os principais objetivos do projeto.

## Objetivos
### Descoberta de Problemas
O teste incentiva o usuário a buscar brechas e falhas que acabem gerando inconsistência no funcionamento da aplicação.

### Teste de Aprendizado
O teste busca averiguar o desempenho de um usuário novato em aprender a navegar pela aplicação corretamente, relacionando a curva de aprendizado com a clareza e intuitividade da interface.

Principais perguntas a serem respondidas:
-	Quais obstáculos impedem a navegação contínua na aplicação?
-	O tempo de resposta gera frustação do usuário?
-	O usuário consegue entender a interface e navegar com facilidade?


### Perfil de Usuários
Os usuários serão escolhidos de acordo com as características das personas pré-estabelecidas nas especificações do projeto, sendo elas pessoas que buscam maior organização e melhor gerenciamento de seus planos e tarefas de forma concisa a partir de um ambiente virtual.

### Requisitos do Teste
Para que o teste seja corretamente executado, os usuários precisam cumprir as seguintes condições:
-	Possuir computador para acessar a aplicação.
-	Possuir um navegador de internet – Opera, Chrome, Firefox, Safari ou Microsoft Edge;
-	Possuir conectividade de internet para navegação;
-	Possuir ferramentas de compartilhamento de tela - Zoom, Discord, Google Meet, Teams, Webcam.

### Método de Mensura
O teste contará com cinco participantes que avaliarão o desempenho e clareza da aplicação. A partir da identidade e finalidade do projeto, os usuários poderão não só efetuar os testes quantitativos, como também darão uma métrica de satisfação e feedback livre.
A partir dos dados coletados será possível analisar e otimizar o atual desempenho da aplicação.
As 3 mensuras principais serão de Eficácia, Eficiência e Satisfação.
#### Eficácia
Tem como foco a capacidade da aplicação de executar suas tarefas corretamente, ela avalia:
-	Quantidade de erros ao executar tarefa.
-	Quantidade de tarefas executadas sem erros.
-	Frequência de pedidos de auxílio para entendimento da plataforma.
#### Eficiência
Tem como foco a capacidade da aplicação de executar suas tarefas com qualidade e tempo otimizados, ela avalia:
-	Tempo de execução de uma tarefa.
-	Tempo de curva de aprendizado.
#### Satisfação
A satisfação tem como foco a avaliação pessoal do usuário quanto à utilização da plataforma, a escala de avaliação vai de 1 a 5, e avalia:
-	Satisfação da execução de uma tarefa.
-	Satisfação do teste em sua totalidade.



Segue o roteiro das tarefas de teste                                        


| **Caso de Teste** 	| **CTU-01 – Cadastro Usuário** 	|
|:---:	|:---:	|
| **Perfil** 	| Usuário (todos)	|
| **Objetivo do Teste** 	| Avaliar a tela de cadastro de usuário 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Clicar em “Cadastrar”;<br>5. Preencher os campos obrigatórios (e-mail, usuário e senha);<br>6. Clicar em "Cadastrar". 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-02 – Login de usuário** 	|
| **Perfil** 	| Usuário (todos) 	|
| **Objetivo do Teste** 	| Avaliar a tela de Login de usuário 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Preencher os campos obrigatórios (Usuário e senha);<br>5. Clicar em "Entrar". 	|
|  	|  	|
| Caso de Teste 	| **CTU-03 – Editar Usuário**	|
| Objetivo do Teste 	| Avaliar o processo de alteração das informações de perfil |
| Passos 	| - Acessar navegador <br> - Informar o endereço do site<br> - Preencher corretamente os campos obrigatórios (Nome de usuário e senha) <br> - Clicar em "Entrar" <br> - Clicar no ícone de perfil no canto superior direito <br> - Selecionar "Editar" <br> - Efetuar as mudanças desejadas na conta <br> - Clicar em "Salvar" |
|  	|  	|
| Caso de Teste 	| **CTU-04 – Remover usuário**	|
| Objetivo do Teste 	| Avaliar o processo de exclusão do usuário |
| Passos 	| - Acessar navegador <br> - Informar o endereço do site<br> - Preencher corretamente os campos obrigatórios (Nome de usuário e senha) <br> - Clicar em "Entrar" <br> - Clicar no ícone de perfil no canto superior direito <br> - Selecionar "Apagar" <br> - Clicar em "Apagar" |
|  	|  	|
| **Caso de Teste** 	| **CTU-05 – Visualizar Projetos** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar o acesso à tela principal de visualização de projetos 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Visualizar página inicial contendo todos os projetos. 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-06 – Gerenciamento de Projetos**|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar acesso à função de gerenciamento de projetos 	|
| **Passos** 	| 1. Acessar Navegador;<br>2. Informar o endereço do Site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Visualizar página inicial contendo todos os projetos.;<br>6. Clicar no projeto desejado 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-07 – Criar Projetos** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar se os projetos estão sendo criados 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Visualizar página inicial contendo todos os projetos;<br>6. Clicar no botão “Novo" 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-08 – Dados do Projeto(Relatório)** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar se o relatório dos projetos está sendo corretamente exibido 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Visualizar página inicial contendo todos os projetos;<br>6. Clicar no projeto desejado;<br>7. Clicar no botão de relatório. 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-09 – Gerenciar Tarefas** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar o acesso ao gerenciamento de tarefas dentro da coluna 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Clicar no projeto desejado;<br>6. Interagir com as tarefas do projeto 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-10 – Gerenciar Colunas** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar o acesso ao gerenciamento de colunas dentro do projeto 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Clicar no projeto desejado;<br>6. Interagir com a coluna desejada. 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-11 - Adicionar Tarefas** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar se a tarefa foi adicionada corretamente 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Clicar no projeto desejado;<br>6. Clicar na coluna desejada;<br>7. Clicar no botão de adicionar tarefa.	|
|  	|  	|
| **Caso de Teste** 	| **CTU-12 – Dados da tarefa** 	|
| **Perfil** 	| Usuário 	|
| **Objetivo do Teste** 	| Avaliar se os dados da tarefa estão corretamente exibidos 	|
| **Passos** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br>5. Clicar no projeto desejado;<br>3. Visualizar os dados da tarefa desejada. 	|
|  	|  	|
| **Caso de Teste** 	| **CTU-13 – Alterar tarefas entre colunas** 	|
| **Perfil** 	| Avaliar o fluxo de tarefas entre as colunas	|
| **Objetivo do Teste** 	| Verificar se os usuários conseguem movimentar as tarefas entre colunas 	|
| **Ações necessárias** 	| 1. Acessar navegador;<br>2. Informar o endereço do site;<br>3. Acessar página inicial;<br>4. Efetuar Login;<br> 5. Clicar no projeto desejado; <br> 6.Clicar na tarefa desejada; <br> 7. clicar para mover tarefa para outra coluna. 	|
