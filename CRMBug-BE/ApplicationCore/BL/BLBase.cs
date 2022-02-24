using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.BL;
using ApplicationCore.Interfaces.DL;
using static ApplicationCore.Enumeration.Enumeration;

namespace ApplicationCore.BL
{
    public class BLBase<T> : IBLBase<T> where T : BaseEntity
    {
        #region Declare
        IDLBase<T> DLBase;
        protected ServiceResult serviceResult;
        private bool isValid;
        #endregion

        #region Constructor 
        public BLBase(IDLBase<T> dlBase)
        {
            DLBase = dlBase;
            serviceResult = new ServiceResult();
            serviceResult.Code = Code.Ok;
            isValid = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách thực thể
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// Author: HHDang 23.2.2022
        public IEnumerable<T> GetEntities()
        {
            return DLBase.GetEntities();
        }

        public virtual ServiceResult Save(T entity)
        {
            entity.EntityState = EntityState.Add;
            // Thêm mới dữ liệu khi đã hợp lệ:
            //if(isValid)
            //{
            //    isValid = ValidateCustom(entity);
            //}
            if (isValid)
            {
                var rowAffects = DLBase.Save(entity);
                if (rowAffects >= 1)
                {
                    serviceResult.Code = Code.Created;
                    serviceResult.Data = rowAffects;
                }
                else
                {
                    serviceResult.Code = Code.Exception;
                    serviceResult.Data = rowAffects;
                }
            }
            return serviceResult;
        }
        #endregion

    }
}
