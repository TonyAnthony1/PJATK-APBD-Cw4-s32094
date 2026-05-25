using ComputerComponentManagementSystem.DTO;
namespace ComputerComponentManagementSystem.Services;

public interface IService
{
    Task<IEnumerable<ListItem>> GetAllAsync();
    Task<Details?> GetWithComponentsAsync(int id);
    Task<Response> CreateAsync(CreateUpdate dto);
    Task<bool> UpdateAsync(int id, CreateUpdate dto);
    Task<bool> DeleteAsync(int id);
}