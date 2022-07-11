using AutoMapper;
using FinalProject.Core.Commercial;
using FinalProject.Core.DTOs;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialActivitiesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<CommercialActivity> _service;

        public CommercialActivitiesController(IService<CommercialActivity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm Hizmetleri Listeler
        /// </summary>
        /// <returns>List of Commercial Activities döndürür.</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var commercial = await _service.GetAllAsync();
            var commercialsDto = _mapper.Map<List<CommercialActivityDto>>(commercial.ToList());
            return CreateActionResult(CustomResponseDto<List<CommercialActivityDto>>.Success(200, commercialsDto));
        }

        /// <summary>
        /// Seçili Hizmeti Getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommercialById(int id)
        {
            var commercial = await _service.GetByIdAsync(id);
            var commercialsDto = _mapper.Map<CommercialActivityDto>(commercial);
            return CreateActionResult(CustomResponseDto<CommercialActivityDto>.Success(200, commercialsDto));

        }

        /// <summary>
        /// Hizmet Ekler
        /// </summary>
        /// <param name="commercial"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Save(CommercialActivityDto customerDto)
        {
            var commercial = await _service.AddAsync(_mapper.Map<CommercialActivity>(customerDto));
            var commercialsDto = _mapper.Map<CommercialActivityDto>(commercial);
            return CreateActionResult(CustomResponseDto<CommercialActivityDto>.Success(201, commercialsDto));//201 created

        }

        /// <summary>
        /// Müşteriyi Günceller
        /// </summary>
        /// <param name="commercial"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> Update(CommercialActivityDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<CommercialActivity>(customerDto));
            return CreateActionResult(CustomResponseDto<CommercialActivityDto>.Success(204));

        }

        /// <summary>
        /// Müşteriyi Siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/customers/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var commercial = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(commercial);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
