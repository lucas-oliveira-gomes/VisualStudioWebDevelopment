CREATE PROCEDURE TarefaExcluir
	@id int
AS
BEGIN

DELETE FROM [dbo].[Tarefa]
WHERE Id = @id

END
