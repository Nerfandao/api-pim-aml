using TESTE_API.Entities;

namespace TESTE_API.Model
{
    public interface IFuncionariosRepository
    {
        void Add(Entities.Funcionarios funcionarios);
        void Delete(int id);
        List<Entities.Funcionarios> Get();
        void Update(Entities.Funcionarios funcionario);
    }
}
