--  DQL  DATA QUERY LANGUAGE

-- PROJETO HEALTH CLINIC

-- USANDO O BD
USE  Health_Clinic_Manha


-- LISTAR OS DADOS PEDIDO PELO PROFESSOR:

SELECT
	Consulta.IdConsulta,
	CONCAT(Consulta.[Data],'  ',Consulta.Horario) AS [Data],
	Clinica.NomeFantasia AS Clinica,
	PacienteUsario.Nome AS Paciente,
	MedicoUsuario.Nome AS Medico,
	Especialidade.Titulo AS Especialidade,
	Medico.CRM AS [CRM do Medico],
	Prontuario.HistoricoMedico,
	Prontuario.Medicamento,
	Prontuario.PlanoTratamento,
	CASE WHEN Comentario.Exibir = '1'
	THEN Comentario.Descricao ELSE 'Nao Exibir' END AS Comentario
FROM
	Consulta
JOIN Paciente ON Paciente.IdPaciente = Consulta.IdConsulta 
JOIN Medico ON Medico.IdMedico = Consulta.IdMedico
JOIN Clinica ON Clinica.IdClinica = Medico.IdClinica
JOIN Especialidade ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
JOIN Usuario AS PacienteUsario ON PacienteUsario.IdUsuario = Paciente.IdUsuario 
JOIN Usuario AS MedicoUsuario ON MedicoUsuario.IdUsuario = Medico.IdUsuario
JOIN Prontuario ON Prontuario.IdConsulta = Consulta.IdConsulta
JOIN Comentario ON Comentario.IdConsulta = Consulta.IdConsulta;


-- FUNCAO PARA RETORNAR OS MEDICOS DE UMA DETERMINADA ESPECIALIDADE

CREATE FUNCTION BuscarMedicos
(
    @especialidadeBuscada NVARCHAR(100)
)
RETURNS TABLE
AS
RETURN
(
    SELECT Usuario.Nome AS Medico
    FROM Medico 
    INNER JOIN Usuario  ON Medico.IdUsuario = Usuario.IdUsuario
    INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
    WHERE Especialidade.Titulo = @especialidadeBuscada
);

-- EXECUTAR A FUNCAO
SELECT Medico
FROM dbo.BuscarMedicos('Dermatologista');




-- PROCEDURE PARA RETORNAR AS IDADES DOS PACIENTES

CREATE PROCEDURE IdadePacientes
AS
BEGIN
    SELECT 
        Nome, 
        DATEDIFF(YEAR, DataNascimento, GETDATE()) - 
            CASE 
                WHEN DATEADD(YEAR, DATEDIFF(YEAR, DataNascimento, GETDATE()), DataNascimento) > GETDATE() THEN 1
                ELSE 0
            END AS Idade
    FROM Usuario
	join Paciente on Paciente.IdUsuario = Usuario.IdUsuario
END;

-- EXECUTAR A PROCEDURE
EXEC IdadePacientes

