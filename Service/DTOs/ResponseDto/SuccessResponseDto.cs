using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Service.DTOs.ResponseDto
{
    public class SuccessResponseDto:IResponseDto
    {
        public bool Succeeded { get; set; } = true;
        public IEnumerable<IEntityDto> Entities { get; set; }

        private SuccessResponseDto()
        {
            
        }
        public static SuccessResponseDto Create(IEntityDto entity)
        {
            return new SuccessResponseDto()
            {
                Entities = new List<IEntityDto>() { entity}
            };
        }
        public static SuccessResponseDto Create(IEnumerable<IEntityDto> entities)
        {
            return new SuccessResponseDto()
            {
                Entities = new List<IEntityDto>(entities) 
            };
        }
    }
}

