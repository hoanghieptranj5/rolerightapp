using AutoMapper;
using RoleRightApp.Logics.Abstractions;
using RoleRightApp.Repositories.Abstractions;
using RoleRightApp.Repositories.Models;
using RoleRightApp.RequestModels;

namespace RoleRightApp.Logics.Implementations
{
    public class RightLogic : IRightLogic
    {
        private readonly IRightRepository _rightRepository;
        private readonly IMapper _mapper;
        public RightLogic(IRightRepository rightRepository, IMapper mapper)
        {
            this._rightRepository = rightRepository;
            this._mapper = mapper;
        }
        public async Task<List<RightModel>> GetAllRight()
        {
            return await _rightRepository.GetAllRight();
        }

        public Task<RightModel> GetRight(string rightId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveRight(RightRequestModel rightModel)
        {
            var mapped = _mapper.Map<RightRequestModel, RightModel>(rightModel);
            mapped.RightId = Guid.NewGuid().ToString();
            mapped.CreatedAt = DateTime.Now;
            var result = await _rightRepository.SaveRight(mapped);
            return result;
        }
    }
}
