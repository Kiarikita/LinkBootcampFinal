using FinalProject.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {

        [NonAction] //swagger action olarak algılamasın
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };


        }
    }
}
