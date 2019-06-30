CREATE TABLE [dbo].[tb_services_balances_sums]
(
	[service_id] INT NULL,  
    [sum] DECIMAL(18, 2) NULL, 
    [date_post] DATETIME NOT NULL PRIMARY key, 
    [limit] DECIMAL NULL, 
    CONSTRAINT [FK_tb_services_balances_sums_ToTb_services_balances] FOREIGN KEY (service_id) REFERENCES [tb_services_balances] (service_id), 
)

