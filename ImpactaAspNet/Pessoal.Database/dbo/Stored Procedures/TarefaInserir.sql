CREATE PROCEDURE TarefaInserir
@nome			nvarchar(200),
@prioridade		tinyint,
@concluida		bit,
@observacoes	nvarchar(1000)
as
INSERT INTO [dbo].[TAREFA]
           ([NOME]
           ,[PRIORIDADE]
           ,[CONCLUIDA]
           ,[OBSERVACOES])
	output inserted.ID
    VALUES
           (@nome
           ,@prioridade
           ,@concluida
           ,@observacoes)