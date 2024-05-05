DECLARE @i INT = 1;
WHILE @i <= 1000
BEGIN
    INSERT INTO Tasks (TaskID, Type, Payload, Command, ScheduledAt, PickedAt, StartedAt, CompletedAt, FailedAt, Status, CreatedAt, DeletedAt, ReceiptHandle)
    VALUES (@i, 'Type' + CAST(@i AS NVARCHAR), 'Payload' + CAST(@i AS NVARCHAR), 'Command' + CAST(@i AS NVARCHAR), DATEADD(MINUTE, @i, GETDATE()), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
    SET @i = @i + 1;
END
