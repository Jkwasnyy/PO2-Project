
# Aplikacja WinForms – System zarządzania klientami i zamówieniami

To prosta aplikacja desktopowa napisana w C# (WinForms), korzystająca z bazy danych PostgreSQL. Umożliwia zarządzanie klientami i ich zamówieniami – w tym dodawanie, edytowanie, usuwanie oraz filtrowanie danych.

---

## Funkcje aplikacji

- Dodawanie klientów oraz zamówień
- Edycja i usuwanie istniejących rekordów
- Filtrowanie po nazwie klienta oraz statusie zamówienia
- Obsługa bazy danych PostgreSQL (ADO.NET + Npgsql)
- Przeglądanie danych w tabeli `DataGridView`
- Wczytywanie danych testowych z pliku `.sql`

---

## Struktura bazy danych

Baza danych nazywa się `mydatabase` i zawiera 2 tabele:

### Tabela `customers`
| Kolumna        | Typ           | Uwagi                    |
|----------------|----------------|--------------------------|
| `id`           | SERIAL         | Klucz główny            |
| `name`         | VARCHAR(100)   | Wymagane                |
| `email`        | VARCHAR(100)   | Wymagane                |
| `phone`        | VARCHAR(20)    | Opcjonalne              |
| `address`      | TEXT           | Opcjonalne              |
| `registered_at`| TIMESTAMP      | Domyślnie `NOW()`       |

### Tabela `orders`
| Kolumna        | Typ             | Uwagi                                |
|----------------|------------------|---------------------------------------|
| `id`           | SERIAL           | Klucz główny                         |
| `customer_id`  | INT              | Klucz obcy → `customers(id)`        |
| `order_date`   | TIMESTAMP        | Wymagane                             |
| `status`       | VARCHAR(20)      | Domyślnie `"Nowe"`                   |
| `total_amount` | DECIMAL(10,2)    | Wymagane                             |
| `note`         | TEXT             | Opcjonalne                           |

---

## Plik SQL

Plik `create_tables.sql` zawiera:

- Tworzenie bazy `mydatabase`
- Tworzenie tabel `customers` i `orders`
- Wstawianie przykładowych danych

Aby użyć:

1. Otwórz pgAdmin lub `psql`
2. Wykonaj cały plik `create_tables.sql` (przed uruchomieniem aplikacji)

---

## Konfiguracja i uruchomienie

### 1. Zainstaluj PostgreSQL

- Upewnij się, że masz zainstalowaną bazę PostgreSQL i użytkownika `postgres` z hasłem `qwer1234` (domyślnie).

### 2. Wykonaj plik SQL

- Otwórz pgAdmin
- Wykonaj zawartość pliku `create_tables.sql`

### 3. Skonfiguruj połączenie

Jeśli zmieniasz nazwę bazy/hasło, zaktualizuj w kodzie (np. w `Form1.cs`, `Form2.cs`):

```csharp
string connectionString = "Host=localhost;Username=postgres;Password=qwer1234;Database=mydatabase";
```

### 4. Dołącz bibliotekę Npgsql

Zainstaluj pakiet NuGet:

```bash
Install-Package Npgsql
```

---

## Uruchamianie aplikacji

1. Otwórz projekt w Visual Studio
2. Uruchom aplikację
3. Główne okno (`Form1`) pokaże dane z bazy
4. Kliknij „Edit”, aby przejść do zarządzania rekordami
