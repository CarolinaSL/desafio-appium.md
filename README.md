# Desafio Appium

Construir um teste básico do login do aplicativo.

Será necessário realizar no mínimo a autenticação no app.

Usuário: testedasilva1@grr.la
Senha: qee123

## Começando

* Plataforma utilizada : .Net Core 3.1
* Appium Server : 1.18.2  
Comando para instalação via prompt  -> `npm install -g appium `
* A apk estará disponível no repositório.
* AWS Device Farm não pode ser usado para execução dos testes, pois não há suporte para C# aparentemente.
* Verificar se o caminho para ANDROID_HOME e JAVA_HOME estão ok.

## Configurações de emulador para criação no Android Studio

* Name : Pixel 3 API 28
* Android: Android 9.0
* CPU: X86
* Utilizar Cold Boot na configuração do emulador

## Capabilities( disponível no appSettings.json do projeto)

* AppiumServer: http://localhost:4723/wd/hub
* deviceName : emulator-5554
* platformName : android
* avd: Pixel_3_API_28

## Características

* Uso de Specflow para uso de metodologia BDD
* Uso de XUnit
* Uso de Page Objects Pattern
* A execucação é gráfica, portanto as ações aparecerão na tela.


### Foram implementados 3 testes com diferentes Cenários:
  1. Usuário deseja fazer login a partir do usuário e senha repassados
  2. Usuário deseja fazer login, porém não lembra nenhuma informação de login
  3. Usuário deseja fazer login, porém não coloca um e-mail válido


## Como rodar?

* Para rodar localmente basta abrir o Test Explorer no Visual Studio e clicar em Run em cima da suíte de testes ou de algum teste em específico.(É possível que haja problema de conexão com o appium e este feche o socket causando erro no teste, portanto recomenda-se que se execute individidualmente caso o suíte dê algum erro de conexão.)
* O Appium será iniciado junto com avd a partir do código, portanto, para que funcione basta que o emulador esteja corretamente configurado de acordo com as especificações citadas anteriormente.
* Caso o emulador abra, mas o teste quebre é possível que tenha dado timetout, recomenda-se rodar novamente sem fechar o emulador, pois dependerá do tempo que o emulador abra e se conecte com o servidor appium.


