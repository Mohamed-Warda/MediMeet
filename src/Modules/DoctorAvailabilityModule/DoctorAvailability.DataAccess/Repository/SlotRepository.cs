using DoctorAvailability.DataAccess.Database;
using DoctorAvailability.DataAccess.Entities;
using DoctorAvailability.DataAccess.IRepository;

namespace DoctorAvailability.DataAccess.Repository;

public class SlotRepository: ISlotRepository
{
    public List<Slot> GetAll()
    {
        return InMemoryDb.Slots;
    }
    public List<Slot> GetAllAvailable()
    {
        return InMemoryDb.Slots.Where(s =>  !s.IsReserved).ToList();
    }

    public void DeleteById(Guid slotId)
    {
        var slot = InMemoryDb.Slots.FirstOrDefault(s => s.Id == slotId);
        if (slot != null)
        {
            InMemoryDb.Slots.Remove(slot);
        }
    }
    public void Create(Slot slot)
    {
        InMemoryDb.Slots.Add(slot);
    }
    
    public Slot GetById(Guid slotId)
    {
     return   InMemoryDb.Slots.FirstOrDefault(s=>s.Id==slotId);
    }
    
    public void Update(Slot slot)
    {
        var slotToUpdate = InMemoryDb.Slots.FirstOrDefault(s => s.Id == slot.Id);
        if (slotToUpdate is  null)
        {
            return;
        }
        InMemoryDb.Slots.Remove(slotToUpdate);
        InMemoryDb.Slots.Add(slot);
    }
}