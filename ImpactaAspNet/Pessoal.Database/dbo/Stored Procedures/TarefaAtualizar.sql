CREATE PROCEDURE TarefaAtualizar
	@id int,
	@nome nvarchar(200),
	@prioridade tinyint,
	@concluida bit,
	@observacoes nvarchar(1000)
AS

BEGIN
UPDATE [dbo].[Tarefa] set
            Nome = @nome
           ,Prioridade = @prioridade
           ,Concluida = @concluida
           ,Observacoes = @observacoes 
WHERE Id = @id

END
