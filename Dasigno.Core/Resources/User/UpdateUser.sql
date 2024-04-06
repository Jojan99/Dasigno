UPDATE Users
SET
    firstName = @firstName,
    secondName = @secondName,
    surname = @surname,
    secondSurname = @secondSurname,
    birthdayDate = @birthdayDate,
    salary = @salary,
    updateOn = CURRENT_TIMESTAMP
WHERE
    Id = @id;