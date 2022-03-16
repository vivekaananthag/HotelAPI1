using Hotel.Models.DTO;

namespace Hotel.Interface.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetRooms();
        Task<RoomDTO> AddRoom(RoomDTO roomDto);
    }
    //public interface IEmployeeRepository
    //{
    //    Task<IEnumerable<Employee>> GetEmployees();
    //    Task<Employee> GetEmployee(int employeeId);
    //    Task<Employee> AddEmployee(Employee employee);
    //    Task<Employee> UpdateEmployee(Employee employee);
    //    void DeleteEmployee(int employeeId);
    //}
}
