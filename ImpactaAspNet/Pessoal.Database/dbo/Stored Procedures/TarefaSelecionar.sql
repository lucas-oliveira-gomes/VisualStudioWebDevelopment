CREATE PROCEDURE TarefaSelecionar
@id				int = null
as
SELECT [ID]
      ,[NOME]
      ,[PRIORIDADE]
      ,[CONCLUIDA]
      ,[OBSERVACOES]
  FROM [dbo].[TAREFA]
WHERE [ID] = ISNULL(@id, [ID])
ORDER BY [CONCLUIDA], [PRIORIDADE]