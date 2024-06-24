# eStore ChatBot Finder

## Description
This project integrates a conversational AI assistant to help users search and find products in an eStore. The chatbot leverages SignalR for real-time communication and an OpenAI language model for understanding and processing user queries. It aims to research how AI can help automate and improve different business processes.

## Features
- Real-time chat functionality using SignalR
- Product search and filtering based on user queries
- Provides descriptions for products or materials
- User-friendly interface with a floating chat window
- SQLite3 database with test information for development purposes

## Requirements
- .NET 8.0.301 SDK
- ASP.NET Core MVC
- SignalR
- OpenAI API key

## Installation
1. **Clone the repository:**
    ```bash
    git clone https://github.com/Jcarchboldd/eStoreChatBotFinder.git
    ```

2. **Set up the environment variables:**
    Modify the `appsettings.json` and `appsettings.Development.json` files, or set up environment variables as follows:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "YOUR_SQLITE_CONNECTION_STRING_HERE",
        "AzureSqlConnection": "YOUR_AZURE_SQL_CONNECTION_STRING_HERE"
      }
    }
    ```
    ```json
    {
      "LanguageService": {
        "Key": "YOUR_API_KEY_HERE",
        "Endpoint": "YOUR_ENDPOINT_HERE"
      }
    }
    ```

3. **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```

4. **Run the application:**
    ```bash
    dotnet run
    ```

## Usage
1. **Open your browser and navigate to:** `http://localhost:5000`
2. **Click on the chat icon** to open the chatbot.
3. **Interact with the chatbot** by asking questions about products or materials. The chatbot will provide descriptions and search the store's inventory based on your queries.

## Switching Database Connections
By default, the application uses an Azure SQL database. To switch to using an SQLite3 database, update the `Program.cs` file:

1. **Comment out the Azure SQL connection code:**
    ```csharp
    builder.Services.AddDbContext<StoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlConnection"), sqlOptions => sqlOptions.EnableRetryOnFailure()));
    ```

2. **Uncomment and configure the SQLite connection:**
    ```csharp
    // var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
    // if (defaultConnection != null)
    // {
    //     builder.Services.AddDbContext<StoreDbContext>(options =>
    //         options.UseSqlite(defaultConnection));
    // }
    ```
