## ASP.NET_EF_PSQL

## Задача
Необходимо реализовать функциональность сбора заявок на конференцию от потенциальных докладчиков. <br>Заявка представляет из себя тему и описание доклада, данные докладчика и контакты для обратной связи. <br>
Каждая заявка уникальна и крайне ценна, то есть заявки никак нельзя терять, что означает необходимость сохранять все поданные заявки в долговременное хранилище - в некую базу данных.



## About
При запуске будет отображена страница Swagger, где есть несколько видов запросов: <br>
-GET/api/Application - получение всех заявок <br>
-POST/api/Application/applications - создание заявок<br>
-PUT/api/Application/applications - редактирование завки<br>
-DELETE/api/Application/applications/{id} - удаление заявки по индексу<br>
-GET/api/Application/applications/{id} -  получение текущей не поданной заявки для указанного пользователя<br>
-POST/api/Application/applications/{id}/submit - отправка заявки на рассмотрение программным комитетом<br>
-GET/api/Application/applicationSubmittedAfter - получение заявок поданных после указанной даты<br>
-GET/api/Application/applicationsSubmittedOlder - получение заявок не поданных и старше определенной даты<br>
-GET/api/Application/activities - получение списка возможных типов активности<br>


## Технологии:
-asp.net web api<br>
-asp.net dependency injection framework<br>
-Entity Framework<br>
-postgresql и npgsql<br>

## Developers

- [Plyusnina Valeria]

