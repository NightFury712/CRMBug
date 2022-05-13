using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.BL;
using Library;
using Library.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static Library.Enumeration.Enumeration;

namespace BugTracking.API.Base
{
  [EnableCors("MyPolicy")]
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
    [Authorize]
    public IActionResult GetAll()
    {
      try
      {
        var datas = _baseService.GetEntities();
        if (datas != null && datas.Count() > 0)
        {
          _serviceResult.Data = datas;
          _serviceResult.Success = true;
          return Ok(_serviceResult);

        }
        return NoContent();
      }
      catch (Exception ex)
      {
        _serviceResult.Success = false;
        _serviceResult.Data = ex;
        return StatusCode(500, _serviceResult);
      }
    }

    /// <summary>
    /// Thêm mới thực thể
    /// </summary>
    /// <param name="entity">Obj chứa thông tin thực thể thêm mới</param>
    /// <returns>Thông điệp</returns>
    /// Author: HHDang 23.2.2022
    [HttpPost]
    [Authorize]
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
    [Authorize]
    public IActionResult Delete(int entityID)
    {
      try
      {
        _serviceResult = _baseService.Delete(entityID);
        return Ok(_serviceResult);
        
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpGet]
    [Route("Dictionary")]
    [Authorize]
    public IActionResult GetDictionaryByLayoutCode()
    {
      try
      {
        _serviceResult = _baseService.GetDictionaryByLayoutCode();
        return Ok(_serviceResult);
        
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }


    [HttpPost]
    [Route("Grid")]
    [Authorize]
    public IActionResult Grid(ParamGrid paramGrid)
    {
      try
      {
        var oWhere = BuildFilterClause.BuildFilter(paramGrid);
        var columns = Utils.Base64Decode(paramGrid.Columns);
        _serviceResult.Code = Code.Ok;
        _serviceResult.Data = _baseService.Grid(oWhere, columns);

        return Ok(_serviceResult);
        
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }
    #endregion
  }
}
