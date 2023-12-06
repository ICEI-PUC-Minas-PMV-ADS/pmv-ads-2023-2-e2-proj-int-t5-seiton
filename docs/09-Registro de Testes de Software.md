# Registro de Testes de Software


| Testes 	| CT-01 – Cadastrar perfil	|
|:---:	|:---:	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/e6e4b00d-f88d-40c4-af1e-e2e0d98057f4">|
| Testes 	| CT-02 – Login perfil	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/e2debab0-a547-4e53-a0b8-2734b5c10da3">|
| Testes 	| CT-03 – Editar Usuário	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/b6e1b905-8e7a-48e5-ab69-942659180ad3">|
| Testes 	| CT-04 – Criação de Projetos	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/7dc1859d-28b6-4866-8a94-b1e8fb49a815">|
| Testes 	| CT-05 – Visualização de Projetos	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/efa3ee3f-4061-40e8-999b-98d9e50e914f">|
| Testes 	| CT-06 – Gerenciamento de Projetos	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/c5b02587-ca2c-42ed-a563-1f2d1783d2bb">|
| Testes 	| CT-07 e 08 – Gerenciamento de Tarefas e Visualização de detalhes das tarefas	|
|	Vídeo 	|  <video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t5-seiton/assets/131215140/34bd43c0-fb96-486d-a324-20b8ebc258be">|



<h2>Relatório de Testes de Software</h2>
  
O objetivo deste relatório é indicar se a aplicação atende aos requisitos propostos previamente e sugerir correções.

<br> 
  
| 1 | Gerenciamento de Usuários |
|:---:	|:---:	|
|	Requisito	| RF-01 - A aplicação deve oferecer gerenciamento de usuários. 	<br> RF-02 - A aplicação deve permitir que usuários pré-cadastrados realizem login. |
| Observação | Na página inicial, a funcionalidade de cadastro pode ser acionada ao clicar no botão "cadastrar". Após o preenchimento das informações de cadastro (Nome de usuário, e-mail e senha), o usuário é encaminhado para a tela de Login para que possa acessar a aplicação. É possível fazer alterações às informações de cadastro usando a funcionalidade "editar" disponível no menu suspenso ao selecionar o ícone no canto superior direito. Com essa análise, é possível atestar que a aplicação Seiton atende ao requisito de <b> Gerenciamento de Usuários. |
|  	|  	|
| 2 | Gerenciamento de Projetos |
|	Requisito	| RF-03 - A aplicação deve permitir o gerenciamento de projetos. Quando um projeto for criado, a esse projeto serão associadas 5 colunas fixas, nas quais será possível alterar o nome e a cor. |
| Observação | Na página de projetos, a funcionalidade de criação de projetos pode ser acionada ao clicar no botão "+ Novo". Após inserir o nome do projeto, o usuário é encaminhado para a página com o projeto aberto no modelo padrão, com 5 colunas com cores e nomes customizáveis. Com essa análise, é possível atestar que a aplicação Seiton atende ao requisito de <b> Gerenciamento de Projetos. |
|  	|  	|
| 3 | Gerenciamento de Tarefas |
|	Requisito	| RF-04 - A aplicação deve permitir o gerenciamento das tarefas dentro do projeto, no qual toda tarefa criada deverá obrigatoriamente ser associada a uma coluna. 	<br> RF-05 - As tarefas deverão ter campo de titulo, descrição, cor referente a prioridade e nome da pessoa a quem a mesma foi atribuída. 	<br> RF-06 - A aplicação deve permitir que seja alterado o status das tarefas entre as colunas. <br> RF-07 - A aplicação deverá permitir aos que os usuários vejam os detalhes da tarefa para ter acesso a descrição completa e as demais informações inseridas. |
| Observação | Na página de projetos, a funcionalidade de criação de tarefas pode ser acionada ao clicar no botão "+ Nova Tarefa". Após inserir os dados desejados da tarefa(Nome da tarefa, descrição, prioridade e responsável) a tarefa é criada na coluna desejada, podendo ser editada e movida para diferentes colunas. Com essa análise, é possível atestar que a aplicação Seiton atende ao requisito de <b> gerenciamento de tarefas. |
|  	|  	|
| 4 | Vizualização de Status das Tarefas |
|	Requisito	| RF-08 - A aplicação deverá permitir a visualização do andamento do projeto por meio de informações como a porcentagem de progresso e o total geral de tarefas. |
| Observação | O usuário consegue conferir o andamento das tarefas através dos status das colunas e os contadores de tarefas. Com essa análise, é possível atestar que a aplicação Seiton atende ao requisito de <b> Vizualização de Status das Tarefas. |
|  	|  	|

<br>

**Possíveis pontos de correção:**
  
- O cadastro não apresenta notificação de "cadastro efetuado com sucesso"
- Não é possível criar ou excluir colunas, mantendo sempre o padrão de 5 colunas.
- Sem responsividade para pequenos aparelhos.
