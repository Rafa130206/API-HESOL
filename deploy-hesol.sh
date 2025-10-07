#!/bin/bash

# FIAP 2025 | DEVOPS & CLOUD COMPUTING | 2TDSPH
# CP5 - Web App e Banco PaaS
# André Luís Mesquita de Abreu  | RM: 558159
# Maria Eduarda Brigidio        | RM: 55857
# Rafael Bompadre Lima          | RM: 556459

# Registrar os serviços necessários
az provider register --namespace Microsoft.Web
az provider register --namespace Microsoft.Sql
az provider register --namespace Microsoft.Insights
az provider register --namespace Microsoft.OperationalInsights
az extension add --name application-insights
az provider register --namespace Microsoft.ServiceLinker

# Variáveis do projeto challenge
export RESOURCE_GROUP_NAME="rg-hesol"
export WEBAPP_NAME="hesol-api-app"
export APP_SERVICE_PLAN="hesol-api"
export LOCATION="brazilsouth"
export RUNTIME="DOTNETCORE:8.0"
export GITHUB_REPO_NAME="Rafa130206/API-HESOL"
export BRANCH="main"
export APP_INSIGHTS_NAME="ai-hesol"
export SQLSERVER="hesolsqlserver123"
export DBNAME="Hesol"
export DBUSER="dbadmin"
export DBPASS="SenhaForte123!"

# Criar Grupo de Recursos
az group create \
  --name $RESOURCE_GROUP_NAME \
  --location "$LOCATION"

# Criar Application Insights
az monitor app-insights component create \
  --app "$APP_INSIGHTS_NAME" \
  --location "$LOCATION" \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --application-type web

# Criar o SQL Server
az sql server create \
    --name "$SQLSERVER" \
    --resource-group "$RESOURCE_GROUP_NAME" \
    --location "$LOCATION" \
    --admin-user "$DBUSER" \
    --admin-password "$DBPASS"

# Criar o Banco de Dados
az sql db create \
    --resource-group "$RESOURCE_GROUP_NAME" \
    --server "$SQLSERVER" \
    --name "$DBNAME" \
    --service-objective S0

# Criar Firewall do Banco
az sql server firewall-rule create \
    --resource-group "$RESOURCE_GROUP_NAME" \
    --server "$SQLSERVER" \
    --name AllowAllAzureIps \
    --start-ip-address 0.0.0.0 \
    --end-ip-address 0.0.0.0

# Criar o Plano de Serviço
az appservice plan create \
  --name "$APP_SERVICE_PLAN" \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --location "$LOCATION" \
  --sku F1 \
  --is-linux

# Criar o Serviço de Aplicativo
az webapp create \
  --name "$WEBAPP_NAME" \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --plan "$APP_SERVICE_PLAN" \
  --runtime "$RUNTIME"

# Habilita a autenticação Básica (SCM)
az resource update \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --namespace Microsoft.Web \
  --resource-type basicPublishingCredentialsPolicies \
  --name scm \
  --parent sites/"$WEBAPP_NAME" \
  --set properties.allow=true

# Recuperar a String de Conexão do Application Insights
CONNECTION_STRING=$(az monitor app-insights component show \
  --app "$APP_INSIGHTS_NAME" \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --query connectionString \
  --output tsv)

# Configurar as Variáveis de Ambiente necessárias do nosso App e do Application Insights
az webapp config appsettings set \
  --name "$WEBAPP_NAME" \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --settings \
    APPLICATIONINSIGHTS_CONNECTION_STRING="$CONNECTION_STRING" \
    ApplicationInsightsAgent_EXTENSION_VERSION="~3" \
    XDT_MicrosoftApplicationInsights_Mode="Recommended" \
    XDT_MicrosoftApplicationInsights_PreemptSdk="1" \
    ConnectionStrings__DefaultConnection="Server=tcp:$SQLSERVER.database.windows.net,1433;Initial Catalog=$DBNAME;Persist Security Info=False;User ID=$DBUSER@$SQLSERVER;Password=$DBPASS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" \
    ASPNETCORE_ENVIRONMENT="Production" \
    DB_HOST="$SQLSERVER.database.windows.net" \
    DB_PORT="1433" \
    DB_NAME="$DBNAME" \
    DB_USER="$DBUSER@$SQLSERVER" \
    DB_PASSWORD="$DBPASS"

# Reiniciar o Web App
az webapp restart \
  --name "$WEBAPP_NAME" \
  --resource-group "$RESOURCE_GROUP_NAME"

# Criar a conexão do nosso Web App com o Application Insights
az monitor app-insights component connect-webapp \
  --app "$APP_INSIGHTS_NAME" \
  --web-app "$WEBAPP_NAME" \
  --resource-group "$RESOURCE_GROUP_NAME"

# Configurar GitHub Actions para Build e Deploy automático
az webapp deployment github-actions add \
  --name "$WEBAPP_NAME" \
  --resource-group "$RESOURCE_GROUP_NAME" \
  --repo "$GITHUB_REPO_NAME" \
  --branch "$BRANCH" \
  --login-with-github
