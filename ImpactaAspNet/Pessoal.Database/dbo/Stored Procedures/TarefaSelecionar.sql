CREATE PROCEDURE TarefaSelecionar
	@id int = null
AS
BEGIN

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacoes]
FROM [dbo].[Tarefa]
WHERE Id = isnull(@id,id)
ORDER BY Concluida, Prioridade

END
