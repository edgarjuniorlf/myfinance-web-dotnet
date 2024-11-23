using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.infrastructure;

namespace myfinance_web_dotnet.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private MyFinanceDbContext _myFinanceDbContext;

        public PlanoContaService(MyFinanceDbContext myFinanceDbContext)
        {
            _myFinanceDbContext = myFinanceDbContext;
        }
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<PlanoConta> ListarRegistros()
        {
            var lista = _myFinanceDbContext.PlanoConta.ToList();
            return lista;
        }

        public PlanoConta RetornarRegistro(int id)
        {
            return new PlanoConta();
        }

        public void Salvar(PlanoConta item)
        {
            var dbSet = _myFinanceDbContext.PlanoConta;
            if (item.Id == null)
                dbSet.Add(item);
            else    
            {
                dbSet.Attach(item);
                _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
    }
}