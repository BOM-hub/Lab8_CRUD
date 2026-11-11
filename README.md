# Lab8_CRUD — Учёт студентов (C# WinForms + MS SQL Server)

Учебный проект по дисциплине **«Разработка кода информационных систем» (МДК 05.02)**.

## Функциональность
- Просмотр списка студентов из базы данных `StudentDB` (`DataGridView`)
- Добавление новых записей (`INSERT INTO`) с проверкой заполнения и защитой от дубликатов по ФИО
- Редактирование данных выбранного студента (`UPDATE ... WHERE Id = @id`)
- Удаление записей (`DELETE FROM ... WHERE Id = @id`) с подтверждением через `MessageBox`
- Быстрый поиск по ФИО в реальном времени (`feature/search`)
- Экспорт таблицы студентов в CSV-файл в кодировке UTF-8 с BOM (`feature/export`)
- Отображение актуального счётчика студентов и кнопка «Отмена»

## Технологии
- C# / .NET 10 (`net10.0-windows`, Windows Forms)
- ADO.NET (`System.Data.SqlClient` 4.9.1)
- MS SQL Server LocalDB (`(localdb)\MSSQLLocalDB`)

## Запуск проекта
1. Убедитесь, что экземпляр `(localdb)\MSSQLLocalDB` запущен и развёрнута база данных `StudentDB`.
2. Откройте решение `Labs_MDK0502.slnx` в Visual Studio 2026 или выполните в терминале:
```bash
dotnet build
dotnet run
```
