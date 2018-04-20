# azurebc2018
Azure Global Bootcamp presentation and code samples

#### Prereqs:
1. [.NET Core 2.0](https://www.microsoft.com/net/core) 
2. [VS Code](https://code.visualstudio.com/)
3. Azure Functions Ext for Visual Studio Code 
4. [Node.js](https://nodejs.org/en/download/current/)
5. Azure Function Tools for Core 
    1. (Windows) npm install -g azure-functions-core-tools@core
    2. (Mac) sudo npm install -g azure-functions-core-tools@core --unsafe-perm true

#### Run Locally:
1. Clone repo
2. func host start

#### Publish
1. Create FunctionApp in Azure Portal or Azure CLI (using BETA 2.x runtime)
2. Get Subscription List (func azure subscriptions list)
3. Set Subscription (func azure subscriptions set [GUID])
4. Get FunctionApp List (func azure functionapp list)
5. Publish (func azure functionapp publish [FunctionAppName])

