using ProductManagement.Models;

namespace ProductManagement.IService
{
    public interface IDecentrlizationService
    {
        public Decentralization AddDecentralization(Decentralization decentralization);
        public List<Decentralization> GetDecentralizations();
        public Decentralization GetDecentralizationById(int id);
        public Decentralization UpdateDecentralization(int id,Decentralization decentralization);
        public string DeleteDecentralization(int decentralizationId);
    }
}
