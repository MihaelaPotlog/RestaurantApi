using System;
using System.Collections.Generic;
using System.Text;
using Service.DTOs.RequestDTOs;

namespace Service.DTOs.ResponseDto
{
    public class ErrorResponseDto : IResponseDto
    {
        public bool Succeeded { get; set; } = false;
        public IList<string> ErrorMessages { get; set; }

        private ErrorResponseDto()
        {

        }
        public static ErrorResponseDto Create(string errorMessage)
        {
            return new ErrorResponseDto()
            {
                ErrorMessages = new List<string>() { errorMessage}
            };
        }

        public static ErrorResponseDto Create(IList<string> errorMessages)
        {
            return new ErrorResponseDto()
            {
                ErrorMessages = new List<string>(errorMessages)
            };
        }

    }
}


