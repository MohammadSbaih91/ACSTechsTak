using ACSTechs.Common;
using ACSTechs.Common.DTO;
using ACSTechs.DAL.Entities;
using ACSTechs.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSTechs.DAL.CustomRepositories
{
   public class UsersRepository : Repository<User>
    {
        public UsersRepository(UnitOfWork uow) : base(uow) { }
        public List<UsersDTO> GetUsers()
        {
            try
            {
                var record = GetQuerable(x => x.Id > 0).Select(u => new UsersDTO()
                {
                    Id=u.Id,
                    Usrename=u.Usrename
                }).ToList();
                if (record != null && record.Count > 0)
                {
                    return record;
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetUsers ", "An error occurred while trying to GetUsers records  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
        public bool AddUser(UsersDTO dto)
        {
            try
            {
                var record = new User()
                {
                    Id=dto.Id,
                    Usrename=dto.Usrename
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddUser", "An error occurred while trying to  AddUser Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool EditUser(UsersDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.Id == dto.Id).FirstOrDefault();

                record.Usrename = dto.Usrename;
                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EditUser", "An error occurred while trying to Edit User Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteUser(int UserId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == UserId).FirstOrDefault();

                if (record != null)
                {
                    Delete(record);
                    _uow.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteUser", "An error occurred while trying to Delete User Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }

        public UsersDTO GetUser(int UserId)
        {

            try
            {
                var record = GetQuerable(x => x.Id == UserId).Select(u => new UsersDTO()
                {
                    Id = u.Id,
                    Usrename = u.Usrename
                }).FirstOrDefault();

                if (record != null)
                {
                    return record;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetUser", "An error occurred while trying to Get User Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }

        }
    }
}
