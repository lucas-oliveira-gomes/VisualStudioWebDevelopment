CREATE PROCEDURE TarefaExcluir
@id				int
as
DELETE [dbo].[TAREFA]
WHERE [ID] = @id