CREATE TABLE Users (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(), 
    Username VARCHAR(100) NOT NULL UNIQUE,    
    PasswordHash VARCHAR(255) NOT NULL    
);

INSERT INTO Users (Username, PasswordHash)
VALUES ('test_user', 'thisispassword');