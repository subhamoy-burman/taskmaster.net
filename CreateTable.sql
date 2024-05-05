CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY,
    Type NVARCHAR(50),
    Payload NVARCHAR(MAX),
    Command NVARCHAR(MAX),
    ScheduledAt DATETIME,
    PickedAt DATETIME,
    StartedAt DATETIME,
    CompletedAt DATETIME,
    FailedAt DATETIME,
    Status NVARCHAR(50),
    CreatedAt DATETIME,
    DeletedAt DATETIME,
    ReceiptHandle NVARCHAR(255)
);
