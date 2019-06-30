CREATE TABLE [dbo].[tb_services_balances]
(
	[service_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NCHAR(200) NOT NULL, 
    [active] BIT NULL, 
    [date_post] DATETIME NOT NULL DEFAULT getutcdate(), 
     
)
