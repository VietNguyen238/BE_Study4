using be_study4.Dtos.Advise;
using be_study4.Models;

namespace be_study4.Mappers
{
    public static class AdviseMappers
    {
        public static AdviseDto ToAdviseDto(this Advise AdviseModel)
        {
            return new AdviseDto
            {
                Id = AdviseModel.Id,
                Name = AdviseModel.Name,
                Phone = AdviseModel.Phone,
                Subject = AdviseModel.Subject,
                UserId = AdviseModel.UserId
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