using AIA_Tranning.Contracts;
using AIA_Tranning.Data;
using AIA_Tranning.IService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Service
{
    public class LeaveTypesService : ILeaveTypesService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveTypesService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool create(LeaveType collection)
        {
            LeaveType leaveType = _mapper.Map<LeaveType>(collection);
            leaveType.DateCreated = DateTime.Now;
            return _unitOfWork.leaveTypes.create(leaveType);
        }

        public bool delete(LeaveType collection)
        {
            LeaveType leaveType = _mapper.Map<LeaveType>(collection);
            return _unitOfWork.leaveTypes.delete(leaveType);
        }

        public ICollection<LeaveType> getAll()
        {
            List<LeaveType> leaveTypes = _unitOfWork.leaveTypes.findAll().ToList();
            return _mapper.Map<List<LeaveType>, List<LeaveType>>(leaveTypes);
        }

        public LeaveType getById(int id)
        {
            LeaveType leaveType = _unitOfWork.leaveTypes.findById(id);
            return _mapper.Map<LeaveType, LeaveType>(leaveType);
        }

        public bool isExist(int id)
        {
            return _unitOfWork.leaveTypes.isExist(id);
        }

        public bool update(LeaveType collection)
        {
            LeaveType leaveType = _mapper.Map<LeaveType>(collection);
            return _unitOfWork.leaveTypes.update(leaveType);
        }

    }
}
