using AIA_Tranning.Data;
using AIA_Tranning.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Mappings
{
    public class Maps : Profile
    {
        MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            cfg.CreateMap<LeaveHistory, LeaveRequestVM>().ReverseMap();
            cfg.CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            cfg.CreateMap<LeaveAllocation, EditLeaveAllocationVM>().ReverseMap();
            cfg.CreateMap<Employee, EmployeeVM>().ReverseMap();
        });
    }
}
