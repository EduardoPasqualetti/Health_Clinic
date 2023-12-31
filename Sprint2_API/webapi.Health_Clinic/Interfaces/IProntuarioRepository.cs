﻿using webapi.Health_Clinic.Domains;

namespace webapi.Health_Clinic.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);
        void Atualizar(Guid id, Prontuario prontuario);
        void Deletar(Guid id);
        List<Prontuario> BuscarPorConsulta(Guid id);
        List<Prontuario> Listar();
    }
}
