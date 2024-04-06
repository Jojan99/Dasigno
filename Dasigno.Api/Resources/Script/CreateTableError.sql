CREATE TABLE Error (
    Id SERIAL PRIMARY KEY,
    Source VARCHAR(255),
    Message TEXT,
    MessageDetail TEXT
);