﻿using DoctorAvailability.Business.DomainModels;
using DoctorAvailability.Business.Extentions;
using DoctorAvailability.DataAccess.IRepository;
using DoctorAvailability.DataAccess.Repository;

namespace DoctorAvailability.Business.Services;


public class SlotServices
{
    private readonly ISlotRepository _slotRepository;

    public SlotServices(ISlotRepository slotRepository)
    {
        _slotRepository = slotRepository;
    }

    public void CreateSlot(SlotDto slotDto)
    {
        var slot = slotDto.MapToModule();
        _slotRepository.Create(slot);
    }


    public List<SlotDto> GetAllAvailable()
    {
        return _slotRepository.GetAllAvailable().Select(s=>s.MapToDto()).ToList();
    }

    public List<SlotDto> GetAll()
    {
        return  _slotRepository.GetAll().Select(s => s.MapToDto()).ToList();
    }
}