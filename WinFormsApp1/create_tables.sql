
-- Utwórz nową bazę danych (jeśli jeszcze nie została utworzona)
CREATE DATABASE mydatabase;

-- Po utworzeniu bazy, połącz się z nią
\c mydatabase;

-- Tworzenie tabeli customers (klienci)
CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone VARCHAR(20),
    address TEXT,
    registered_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tworzenie tabeli orders (zamówienia)
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    customer_id INT REFERENCES customers(id) ON DELETE CASCADE,
    order_date TIMESTAMP NOT NULL,
    status VARCHAR(20) DEFAULT 'Nowe',
    total_amount DECIMAL(10, 2) NOT NULL,
    note TEXT
);

-- Wstawienie przykładowych danych do tabeli customers
INSERT INTO customers (name, email, phone, address)
VALUES
('Jan Kowalski', 'jan.kowalski@example.com', '123-456-789', 'Warszawa, ul. Długa 1'),
('Anna Nowak', 'anna.nowak@example.com', '987-654-321', 'Kraków, ul. Krótka 5'),
('Piotr Zieliński', 'piotr.zielinski@example.com', '555-123-555', 'Gdańsk, ul. Morza 9');


-- Wstawienie przykładowych danych do tabeli orders
INSERT INTO orders (customer_id, order_date, status, total_amount, note)
VALUES
(1, '2025-05-01 10:00:00', 'Nowe', 150.00, 'Zamówienie telefoniczne'),
(1, '2025-05-03 14:30:00', 'Zrealizowane', 220.00, 'Dostawa ekspresowa'),
(1, '2025-05-05 09:00:00', 'Anulowane', 90.00, 'Klient zrezygnował'),
(1, '2025-05-10 11:15:00', 'Nowe', 180.00, ''),
(1, '2025-05-12 12:00:00', 'Zrealizowane', 310.00, 'Opłacone gotówką'),

(2, '2025-04-01 13:00:00', 'Zrealizowane', 250.00, ''),
(2, '2025-04-04 15:30:00', 'Nowe', 130.00, ''),
(2, '2025-04-07 16:45:00', 'Zrealizowane', 470.00, 'Faktura wystawiona'),
(2, '2025-04-11 10:15:00', 'Anulowane', 110.00, 'Błąd adresu'),
(2, '2025-04-15 08:50:00', 'Nowe', 200.00, ''),

(3, '2025-03-01 12:00:00', 'Zrealizowane', 300.00, ''),
(3, '2025-03-05 17:20:00', 'Zrealizowane', 150.00, ''),
(3, '2025-03-08 11:30:00', 'Nowe', 200.00, ''),
(3, '2025-03-12 14:10:00', 'Zrealizowane', 400.00, ''),
(3, '2025-03-15 16:00:00', 'Nowe', 190.00, 'Opóźniona płatność'),

(1, '2025-05-15 10:30:00', 'Zrealizowane', 275.00, ''),
(2, '2025-04-18 11:45:00', 'Nowe', 120.00, 'Pilne'),
(3, '2025-03-20 09:30:00', 'Zrealizowane', 600.00, 'Zamówienie hurtowe'),
(1, '2025-05-20 13:10:00', 'Nowe', 330.00, ''),
(2, '2025-04-21 15:00:00', 'Anulowane', 80.00, 'Brak kontaktu z klientem');
