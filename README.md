# SimpleWebService
 
Требования
   - .NET SDK 8.0
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

- Проект можно открыть по пути: SimpleWebService\ProductStore.Web\Task.sln

- После клонирования проекта перейдите в папку ProductStore.DataAccess и выполните команду для применения миграций и обновления базы данных:
   dotnet ef database update --project ../ProductStore.DataAccess

 Готово! Можно запускать проект. 
 Swagger для тестирования API: 
               По умолчанию Swagger позволит тестировать конечные точки напрямую через веб-интерфейс.
