
-- Utwórz nową bazę danych (jeśli jeszcze nie została utworzona)
CREATE DATABASE mydatabase;

-- Po utworzeniu bazy, połącz się z nią
\c mydatabase;

-- Tworzenie tabeli customers (klienci)
CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL
);

-- Tworzenie tabeli orders (zamówienia)
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    customer_id INT REFERENCES customers(id) ON DELETE CASCADE,
    order_date TIMESTAMP NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL
);

-- Wstawienie przykładowych danych do tabeli customers
INSERT INTO customers (name, email) VALUES
('Jan Kowalski', 'jan.kowalski@example.com'),
('Anna Nowak', 'anna.nowak@example.com'),
('Piotr Zielinski', 'piotr.zielinski@example.com');

-- Wstawienie przykładowych danych do tabeli orders
INSERT INTO orders (customer_id, order_date, total_amount) VALUES
(1, '2025-04-01 12:00:00', 150.00),
(1, '2025-04-02 14:00:00', 220.00),
(2, '2025-04-03 15:00:00', 300.00),
(3, '2025-04-04 16:00:00', 100.00);
