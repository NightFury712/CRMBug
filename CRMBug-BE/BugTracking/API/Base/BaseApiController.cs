using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using static ApplicationCore.Enumeration.Enumeration;

namespace BugTracking.API.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase
    {
        #region Declare
        private readonly IBLBase<T> _baseService;
        protected ServiceResult _serviceResult;
        string _entityName = string.Empty;
        #endregion

        #region Constructor
        public BaseApiController(IBLBase<T> baseService)
        {
            _baseService = baseService;
            _entityName = typeof(BaseEntity).Name;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _baseService.GetEntities();
                if (employees != null)
                {
                    if (employees.Count() > 0)
                    {
                        _serviceResult.Data = employees;
                        _serviceResult.Success = true;
                        return Ok(_serviceResult);
                    }
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }

        /// <summary>
        /// Thêm mới thực thể
        /// </summary>
        /// <param name="entity">Obj chứa thông tin thực thể thêm mới</param>
        /// <returns>Thông điệp</returns>
        /// Author: HHDang 23.2.2022
        [HttpPost]
        public IActionResult Post(T entity)
        {
            try
            {
                _serviceResult = _baseService.Save(entity);
                if (_serviceResult.Code == Code.Created && (int)_serviceResult.Data > 0)
                {
                    return Created("Create successfully! ", _serviceResult);
                }
                else if (_serviceResult.Code == Code.NotValid)
                {
                    return Ok(_serviceResult);
                }
                else
                {
                    _serviceResult.Code = Code.Exception;
                    return StatusCode(500, _serviceResult);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{entityID}")]
        public IActionResult Delete(int entityID)
        {
            try
            {
                _serviceResult = _baseService.Delete(entityID);

                if (_serviceResult.Code == Code.Ok)
                {
                    return Ok(_serviceResult);
                }
                else
                {
                    return Ok(_serviceResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    #endregion
  }
}
