CREATE PROCEDURE TarefaInserir
	@nome nvarchar(200),
	@prioridade tinyint,
	@concluida bit,
	@observacoes nvarchar(1000)
AS

BEGIN
INSERT INTO [dbo].[Tarefa]
           ([Nome]
           ,[Prioridade]
           ,[Concluida]
           ,[Observacoes])
	OUTPUT inserted.Id
     VALUES
           (@nome 
           ,@prioridade 
           ,@concluida 
           ,@observacoes)

END
