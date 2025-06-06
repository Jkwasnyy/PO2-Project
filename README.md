# Aplikacja WinForms: System zarządzania klientami i zamówieniami

To prosta aplikacja Windows Forms w języku C# z bazą PostgreSQL. Pozwala na:
- dodawanie klientów i ich zamówień,
- przeglądanie danych w tabeli,
- automatyczne połączenie z bazą danych PostgreSQL.
- operacje CRUD na rekordach bazy danych
- filtracje poprzez statusy zamówień


## O aplikacji

Po uruchomieniu aplikacji wyświetla nam się okno startowe zawierające komplet zamówień, wraz z możliwością filtracji poprzez kryterium "Imię i Nazwisko" klienta, oraz opcjami sortowania według każdego dostępnego pola

Przycisk "Edit" przenosi nas do okna edycji danych znajdujących się w bazie. Możemy tam swobodnie dodawać klientów, usuwać ich oraz przeprowadzać edycje.

Po każdej operacji baza jest natychmiastowo aktualizowana.

Aplikacja ta jest narzędziem do szybkiego wprowadzania klientów i zamówień do bazy, z prostym i czytelnym interfejsem. Idealna np. do testów lub jako baza do dalszej rozbudowy, np. o logowanie.


## Wymagane pakiety

Pakiet NuGet

```bash
Install-Package Npgsql
```
