![Alt text](architecture.jpg "Архитектура")

## SendService
Выполнен на базе REST WCF.
Собирает данные из БД и отправляет на другой сервер в формате XML.

Параметры:
1. getServiceUrl - URL сервиса, куда необходимо отослать данные о выбросах. Значение по умолчанию: http://localhost:7892

## TimerService
Выполнен на базе ConsoleApplication.
По таймеру вызывает API-метод SendService.

Параметры: 
1. pollingInterval - Частота опроса сервиса SendService в милисекундах. Значение по умолчанию: 60000
2. sendServiceUrl - URL SendService. Значение по умолчанию: http://localhost:30000

## GetService
Выполнен на базе REST WCF.
Принимающий модуль. Является посредником для пользователя.

Не параметризован.

## RenderService
Выполнен на базе ASP.NET MVC.
Отображает пользователю каждые 5 секунд актуальную информацию из GetService.

Параметры:
1. getServiceUrl - URL сервиса GetService. Значение по умолчанию: http://localhost:7892