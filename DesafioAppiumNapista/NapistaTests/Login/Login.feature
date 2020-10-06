
Funcionalidade: Login
	Como usuário desejo me logar no aplicativo
	A partir de um usuário e senha
	Para que eu possa acessar as diversas funcionalidades da plataforma

Cenário: Realizar Login com sucesso no primeiro acesso já tendo conta
	Dado que o Usuário acesse o aplicativo dando as permissões necessárias
	E visualize as telas inicias de apresentação
	E Visualize tela de Login
	Quando o usuário clicar em Já tenho Conta
	E Preencher os dados do formulário do login
		| Dados  |
		| E-mail |
		| Senha  |
	E Clicar no botão Acessar Conta
	Então será redirecionado para tela inicial do aplicativo
