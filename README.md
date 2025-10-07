# 🧩 API HESOL (.NET ASP.NET Core)

> API RESTful desenvolvida em **ASP.NET Core** funcionando na nuvem como App Service.

---


## 🧪 Integrantes do Projeto

André Luís Mesquita de Abreu- RM558159

Maria Eduarda Brigidio - RM558575 

Rafael Bompadre Lima - RM556459

---


## 🚀 Tecnologias Utilizadas

- .NET 8.0 (ASP.NET Core)
- Swagger
- Entity Framework Core
- AZURE SQL SERVER

---
## ⚙️ Como subir o Projeto

### 1. Fork do Repositório:
Faça um Fork desse repositório.

### 2. Download do arquivo `deploy-hesolapi.sh`:
No novo repositório, procure pelo arquivo `deploy-hesolapi.sh`. Clique nele e depois, na direita da tela, clique no ícone com 3 pontos (...) chamado `More Actions`. Em seguida, clique em Download e salve o arquivo no seu computador. Este arquivo possui o script para criar o Seviço de Aplicativo completo.

### 3. Portal Azure:
Faça login no Portal da Microsoft Azure e abra o `Cloud Shell`.

### 4. Subir o Script:
Quando o terminal do Cloud Shell abrir, aperte em `Gerenciar Arquivos` e, em seguida, Carregar. Selecione o arquivo `deploy-hesolapi.sh`, que acabou de ser baixado.

### 5. Alterar o Script
No terminal Cloud Shell, altere para a versão clássica e abra o editor. Selecione o Script e altere a variável `GITHUB_REPO_NAME` (Linha 22) para o nome do seu usuário do Github:
```bash
export GITHUB_REPO_NAME="<seu_usuario_github>/API-HESOL"
```

### 6. Rodar o Script:
No Cloud Shell, conceda o privilégio de execução no Script:
```bash
chmod +x deploy-hesol.sh
```
Agora execute o Script com o seguinte comando:
```bash
 ./deploy-hesol.sh 
```
⚠️ Ao executar a criação do banco de dados, o Cloud Shell vai pedir para confirmar o procedimento. Digite `y` e pressione `Enter`

### 7. Ativar o Github Actions:
- 7.1. Copie o código e acesse o link fornecidos pelo Cloud Shell.
- 7.2. Acesse sua conta do Github, cole o código e conceda as permissões necessárias.
- 7.3. Retorne ao Cloud Shell e pressione `y` para substituir o WorkFlow existente

### 8. Build e Deploy:
Na aba Actions do seu repositório, aguarde o build e deploy automático da aplicação. Quando estiver concluído, acesse o link abaixo.
```bash
http://hesol-api-app.azurewebsites.net/swagger/index.html
```

### 9. Testes
Utilize os seguintes JSONs para fazer testes simples:<br/>

**POST**
```bash
{
  "latitude": -23.550520,
  "longitude": -46.633308,
  "descricao": "Centro de monitoramento ambiental de São Paulo",
  "pais": "Brasil"
}

```
```bash
{
  "latitude": 40.712776,
  "longitude": -74.005974,
  "descricao": "Estação meteorológica urbana de Nova York",
  "pais": "Estados Unidos"
}

```

<br/>

**PUT**
```bash
{
  "idLocal": 1,
  "latitude": -23.547500,
  "longitude": -46.635000,
  "descricao": "Centro ambiental atualizado - São Paulo",
  "pais": "Brasil"
}
```
```bash
{
  "idLocal": 2,
  "latitude": 40.713800,
  "longitude": -74.006500,
  "descricao": "Estação meteorológica principal - Nova York",
  "pais": "Estados Unidos"
}
```

### 10. Acessando Azure SQL Server
Ao tentar realizar o primeiro login no banco de dados criado na Azure, provavelmente vai dar um erro de IP. Bastar clicar no texto azul do próprio erro que o problema será solucionado. Então é só fazer login novamente! 



