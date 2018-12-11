CREATE PROCEDURE TarefaAtualizar
@id				int,
@nome			nvarchar(200),
@prioridade		tinyint,
@concluida		bit,
@observacoes	nvarchar(1000)
as
UPDATE [dbo].[TAREFA]
   SET [NOME] = @nome
      ,[PRIORIDADE] = @prioridade
      ,[CONCLUIDA] = @concluida
      ,[OBSERVACOES] = @observacoes
 WHERE [ID] = @id