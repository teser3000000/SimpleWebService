# SimpleWebService
 
Требования
   - .NET SDK 7.0 или новее
   - SQLite
    Необходимые пакеты:
       - Microsoft.EntityFrameworkCore
       - Microsoft.EntityFrameworkCore.Sqlite
       - Microsoft.EntityFrameworkCore.Design
       - Microsoft.EntityFrameworkCore.Tools
       - Swashbuckle.AspNetCore (для Swagger)
    
Инструкция по установке: 
- Установите проект с использованием GitHub Desktop, выбрав опцию "Open with GitHub Desktop" на странице проекта или
  клонируйте проект с GitHub с помощью следующей команды:
   git clone https://github.com/teser3000000/SimpleWebService

- После клонирования проекта перейдите в папку ProductStore.DataAccess и выполните команду для применения миграций и обновления базы данных:
   dotnet ef database update --project ../ProductStore.DataAccess
