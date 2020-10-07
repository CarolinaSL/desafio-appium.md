
Funcionalidade: Login
	Como usuário desejo me logar no aplicativo
	A partir de um usuário e senha
	Para que eu possa acessar as diversas funcionalidades da plataforma

Cenário: Realizar Login com sucesso no primeiro acesso já tendo conta
	Dado que o Usuário acesse o aplicativo dando as permissões necessárias
	E visualize as telas iniciais de apresentação
	E Visualize tela de Login
	Quando o usuário clicar em Já tenho Conta
	E Preencher os dados do formulário do login
		| Dados  |
		| E-mail |
		| Senha  |
	E Clicar no botão Acessar Conta
	Então será redirecionado para tela inicial do aplicativo

Cenário: Usuário esquece a senha do login e deseja resetar senha com email não válido
	Dado que o Usuário acesse o aplicativo dando as permissões necessárias
	E visualize as telas iniciais de apresentação
	E Visualize tela de Login
	E o usuário clicar em Já tenho Conta
	Quando Clicar em esqueci minha senha
	Então será redirecionado para tela de recuperação de senha para preencher email
	E Preencherá email não válido no formulário
	E Clicará em em Resetar senha, recebendo mensagem de erro

Cenario: Usuário não lembra nem email e nem senha para login
	Dado que o Usuário acesse o aplicativo dando as permissões necessárias
	E visualize as telas iniciais de apresentação
	E Visualize tela de Login
	E o usuário clicar em Já tenho Conta
	Quando Clicar em esqueci minha senha
	Então será redirecionado para tela de recuperação de senha para preencher email
	E clicará em não sei meu login, recendo mensagem para entrar em contato com o administrador
	