-- DML DATABASE MANIPULATION LANGUAGE

-- PROJETO HEALTH CLINIC


USE Health_Clinic_Manha


INSERT INTO TipoUsuario(Titulo) VALUES ('Administrador'),('Medico'),('Paciente')


INSERT INTO Especialidade(Titulo) VALUES ('Cardiologista'),('Ortopedista'),('Dermatologista'),('Clinico Geral')


INSERT INTO [Status](StatusDaConsulta) VALUES ('Agendada'),('Realizada'),('Cancelada')


INSERT INTO Clinica(CNPJ,NomeFantasia,RazaoSocial,Endereco,HorarioAbertura,HorarioFechamento) 
VALUES ('49165109241645','ISSP','Instituto de Saude Sao Paulo','R. Sen. Flaquer, 145 Santo Andre','08:00:00','18:00:00'),
('38165091634134','Clinica Sao Luis','Clinica de Saude do hospital sao luis','Rua Walter Figueira, 205 Sao Caetano Do Sul','09:30:00','20:00:00')


INSERT INTO Usuario(IdTipoUsuario,Nome,Email,Senha,CPF,Telefone) 
VALUES ('2','Jorge Alves','jorge@gmail.com','jj123','48640129815','11965398120'),
('1','Vinicius Santos','adm@gmail.com','adm09','39081209653','11985103417'),
('3','Carlos Augusto','carlos@gmail.com','carlos321','20841471093','11990891290'),
('2','Roger Guedes','roger@gmail.com','010110','30814372619','11963992134'),
('3','Matheus Rocha','matheus@gmail.com','ma123','40913276845','11999344053')


INSERT INTO Medico(IdUsuario,IdClinica,IdEspecialidade,CRM) VALUES ('1','1','3','PR-37141'), ('4','1','4','PR-39810')


INSERT INTO Paciente(IdUsuario,DataNascimento) VALUES ('3','1990-04-20'),('5','2005-06-30')


INSERT INTO Consulta(IdMedico,IdPaciente,IdStatus,[Data],Horario) VALUES ('2','1','1','19-08-2023','14:00:00'),
('1','2','2','14-08-2023','11:00:00')


INSERT INTO Prontuario(IdConsulta,HistoricoMedico,Medicamento,PlanoTratamento) 
VALUES ('1','Alergia: Frutos do mar. Possui Hipertensao','Losartana 50mg - 1 vez ao dia','Continuar com a medicação prescrita.'),
('2','Alergias: Nenhuma conhecida','Roacutan','Continuar com a medicação prescrita.')


INSERT INTO Comentario(IdConsulta,Descricao,Exibir) VALUES ('2','Medico excelente, muito atencioso','1'),('1','Medico Horrivel','0')
