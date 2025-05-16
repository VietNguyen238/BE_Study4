using be_study4.Dtos.Advise;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class AdviseMappers
    {
        public static AdviseDto ToAdviseDto(this Advise adviseModel)
        {
            return new AdviseDto
            {
                Id = adviseModel.Id,
                Name = adviseModel.Name,
                Phone = adviseModel.Phone,
                Subject = adviseModel.Subject,
                UserId = adviseModel.UserId,
                CreateOn = adviseModel.CreateOn
            };
        }

        public static Advise ToCreateAdviseDto(this CreateAdviseDto createAdviseDto, int UserId)
        {
            return new Advise
            {
                Name = createAdviseDto.Name,
                Phone = createAdviseDto.Phone,
                Subject = createAdviseDto.Subject,
                UserId = UserId
            };
        }
    }
}