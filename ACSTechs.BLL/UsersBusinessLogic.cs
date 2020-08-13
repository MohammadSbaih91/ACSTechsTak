using ACSTechs.Common;
using ACSTechs.Common.DTO;
using ACSTechs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSTechs.BLL
{
    public class UsersBusinessLogic
    {
        public List<UsersDTO> GetUsers()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var users = uow.Users.GetUsers();
                    if (users != null)
                    {
                        return users;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetUsers", "An error occurred while trying to  GetUsers Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public bool AddUser(UsersDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var users = uow.Users.AddUser(dto);
                    if (users != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddUser", "An error occurred while trying to  AddUser Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool EditUser(UsersDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var users = uow.Users.EditUser(dto);
                    if (users != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditUser", "An error occurred while trying to  EditUser Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool DeleteUser(int UserId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var users = uow.Users.DeleteUser(UserId);
                    if (users != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteUser", "An error occurred while trying to  DeleteUser Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }


        public bool AddUsers(List<UsersDTO> dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    foreach(var user in dto)
                    {
                        var users = uow.Users.AddUser(user);
                       
                    }
                    return true;
                    
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddUsers", "An error occurred while trying to  AddUsers Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }


        public bool EditUsers(List<UsersDTO> dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    foreach (var user in dto)
                    {
                        uow.Users.EditUser(user);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditUsers", "An error occurred while trying to  Edit Users Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
    }
}
