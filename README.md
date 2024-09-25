# Планировщик задач
## Цели и задачи приложения
Приложение предназначено для планировки повседневных и/или рабочих задач в стиле Kanban-доски. Может использоваться как одним пользователем, так и в многопользовательском режиме общего доступа.
## Функциональные требования
### 1. Регистрация пользователя
* Пользователь должен иметь возможность создать аккаунт, введя:
     - Имя пользователя
     - Адрес электронной почты
     - Пароль
* После успешной регистрации пользователь должен получать уведомление и перенаправляться на страницу логина.

------------------------------
Пользователи приложения могут иметь различные роли: 
|Название роли|Возможности и полномочия|Кем создаётся|
|-|--------|---|
|Незарегистрированный пользователь|Создать аккаунт в сервисе; <br/> Просматривать страницу входа|—|
|Зарегистрированный пользователь|Войти в аккаунт в сервисе; <br/> Просматривать страницу входа; <br/> Просматривать страницу личного кабинета; <br/> Создавать "доску" с задачами; <br/> Создавать задачу в рамках "доски"|Незарегистрированный пользователь|
|Администратор группы||Зарегистрированный пользователь|
-------------------------------

### 2. Login/Logout
* При открытии приложения пользователь должен видеть страницу регистрации/авторизации с кратким описанием функциональности и задач сервиса;
* Форма входа в приложение должна позволять выбирать опцию входа в существующую учётную запись или создание новой;
* При успешном входе в систему должно осуществляться перенаправление в личный кабинет;
* У пользователя должна быть возможность в любое время выйти из системы.
### 3. (INDEX) Просмотр списка записей
После входа в систему пользователь должен:
* Видеть список всех "досок", к которым он имеет доступ;
* Иметь возможность открывать каждую "доску" и просматривать сведения о задачах;
* Перемещать задачи по столбцам в рамках одной "доски".
### 4. (CREATE) Создание записи
Пользователь должен иметь возможность создания новой "доски" задач в личном кабинете, а также новой задачи в рамках одной выбранной "доски". Параметры "доски" и задачи различаются и должны включать:
* Для "доски":
    * Название
    * Описание (опционально)
    * Доступность для других пользователей (приватная/публичная)
* Для задачи:
    * Название задачи
    * Срочность (несрочная, срочная, неотложная; выбирается из выпадающего списка) 
    * Дедлайн задачи (для ввода используется виджет календаря)
    * Описание задачи (text area; опционально)
    * Столбец "доски", в который попадёт задача после создания (в идеале выбор из существующих в выпадающем списке; по умолчанию — первый столбец)
### 5. (READ) Просмотр деталей записи
Пользователь должен иметь возможность просмотреть название, сложность и дедлайн задачи в кратком формате без нажатия на неё, а также вызвать модальное окно с описанием задачи (если есть) и расширенной информацией.
### 6. (UPDATE) Редактирование записи
Пользователь должен иметь возможность
* редактировать задачу путём нажатия специальной кнопки в модальном окне с расширенными сведениями, включая: 
    * изменение сложности
    * изменение дедлайна
    * изменение описания
* иметь возможность перемещать задачу внутри "доски" путём drag-and-drop'а
### 7. (DELETE) Удаление записи
Пользователь должен иметь возможность удалить задачу посредством нажатия специальной кнопки в модальном окне с расширенными сведениями, а также удалить "доску" путём нажатия специальной кнопки на ней в личном кабинете.



