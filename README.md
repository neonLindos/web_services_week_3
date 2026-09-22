# CSE5032 · Модуль 03 — Dependency Injection и логирование

**Работу выполнил:** Рябинин Максим

Третья тема курса **«Разработка веб-сервисов»**: интерфейсы и сервисы, регистрация зависимостей в DI-контейнере ASP.NET Core (`AddTransient`/`AddScoped`/`AddSingleton`), Constructor Injection, встроенное логирование (`ILogger<T>`).

## Все работы по курсу CSE5032

| Неделя | Тема | Репозиторий |
|---|---|---|
| 1 | Введение в ASP.NET Core | [web_services_week_1](https://github.com/neonLindos/web_services_week_1) |
| 2 | Web API + CRUD | [web_services_week_2](https://github.com/neonLindos/web_services_week_2) |
| 3 | Dependency Injection и логирование | **этот репозиторий** |
| 4 | EF Core, Repository, DTO и AutoMapper | [web_services_week_4](https://github.com/neonLindos/web_services_week_4) |

| Работа | Проект | Ресурс | Что показано |
|--------|--------|--------|-----------|
| [homework/](homework/) | `StudentsDiApi` | Student | `IStudentService`/`StudentService`, `AddTransient`, `ILogger` (Information/Warning/Error) |
| [lab/](lab/) | `ProductsLabApi` | Product | `IProductService`/`ProductService` (GetAll/GetById/Add/Delete), `AddScoped`, `ILogger`, обработка исключения с `LogError` |
| [prac/](prac/) | `ProductsApi` | Product | переход от `new` к DI, `AddScoped`, `ILogger` |

## Как запустить

Нужен [.NET 8 SDK](https://dotnet.microsoft.com/download):

```bash
cd homework   # или lab, prac
dotnet run
```

Откройте Swagger UI по адресу из вывода консоли.

## Структура

Каждая подпапка — самостоятельный проект:

- `.docx` — методичка от преподавателя, как выдана;
- `Модуль_03_*.md` — та же методичка в Markdown;
- `README.md` — решение: что реализовано, ответы на контрольные вопросы, итоговая таблица endpoint'ов.

Данные во всех решениях — in-memory, без базы данных.
