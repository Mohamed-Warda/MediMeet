using DoctorAvailability.DataAccess.Entities;

namespace DoctorAvailability.DataAccess.IRepository;

public interface ISlotRepository
{
    List<Slot> GetAll();
    List<Slot> GetAllAvailable();
    void DeleteById(Guid slotId);
    void Create(Slot slot);
}