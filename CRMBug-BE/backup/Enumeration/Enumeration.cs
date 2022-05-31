using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Enumeration
{
  public class Enumeration
  {
    /// <summary>
    /// Trạng thái của object
    /// </summary>
    public enum EntityState
    {
      /// <summary>
      /// Thêm mới
      /// </summary>
      Add = 1,
      /// <summary>
      /// Cập nhật
      /// </summary>
      Edit = 2,
      /// <summary>
      /// Xóa
      /// </summary>
      Delete = 3,
      /// <summary>
      /// Xem
      /// </summary>
      View = 4
    }

    /// <summary>
    /// Code để xác định phản hồi của request
    /// </summary>
    public enum Code
    {
      /// <summary>
      /// Dữ liệu hợp lệ
      /// </summary>
      IsValid = 100,
      /// <summary>
      /// Dữ liệu chưa hợp lệ
      /// </summary>
      NotValid = 900,
      /// <summary>
      /// Thành công
      /// </summary>
      Ok = 200,
      /// <summary>
      /// Thất bại
      /// </summary>
      BadRequest = 400,
      /// <summary>
      /// Đăng nhập thất bại
      /// </summary>
      Authentication = 401,
      /// <summary>
      /// Thêm thành công
      /// </summary>
      Created = 201,
      /// <summary>
      /// Có lỗi xảy ra
      /// </summary>
      Exception = 500,
    }

    /// <summary>
    /// Loại vấn đề
    /// </summary>
    public enum IssueType
    {
      Task = 0,
      Bug = 1,
      Request = 2,
      Orther = 3
    }

    public enum Priority
    {
      Low = 0,
      Normal = 1,
      High = 2
    }

    public enum IssueStatus
    {
      New = 0,
      Approved = 1,
      Commited = 2,
      Done = 3,
      Removed = 4,
    }

    public enum RoleEmployee
    {
      Guest = 1,
      Member = 2,
      Admin = 3,
    }

    public enum Operator
    {
      Equal = 1,
      Like = 2
    }

    public enum Addition
    {
      And = 1,
      Or = 2
    }
  }
}
