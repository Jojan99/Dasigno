UPDATE Users
SET
    remove = true,
    updateOn = CURRENT_TIMESTAMP
WHERE
    Id = @id;