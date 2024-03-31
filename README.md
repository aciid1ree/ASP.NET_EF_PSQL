ASP.NET_EF_PSQL


Задача: необходимо реализовать функциональность сбора заявок на конференцию от потенциальных докладчиков.Заявка представляет из себя тему и описание доклада, данные докладчика и контакты для обратной связи.
Каждая заявка уникальна и крайне ценна, то есть заявки никак нельзя терять, что означает необходимость сохранять все поданные заявки в долговременное хранилище - в некую базу данных.

При запуске будет отображена страница Swagger, где есть несколько видов запросов: 
-GET/api/Application - получение всех заявок 
-POST/api/Application/applications - создание заявок
-PUT/api/Application/applications - редактирование завки
-DELETE/api/Application/applications/{id} - удаление заявки по индексу
-GET/api/Application/applications/{id} -  получение текущей не поданной заявки для указанного пользователя
-POST/api/Application/applications/{id}/submit - отправка заявки на рассмотрение программным комитетом
-GET/api/Application/applicationSubmittedAfter - получение заявок поданных после указанной даты
-GET/api/Application/applicationsSubmittedOlder - получение заявок не поданных и старше определенной даты
-GET/api/Application/activities - получение списка возможных типов активности


Технологии:
-asp.net web api
-asp.net dependency injection framework
-Entity Framework
-postgresql и npgsql
