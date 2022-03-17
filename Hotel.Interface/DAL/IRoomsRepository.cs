using Hotel.Models.DTO;

namespace Hotel.Interface.DAL
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<RoomDto>> GetRooms();
        Task<RoomDto> AddRoom(RoomDto roomDto);
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
