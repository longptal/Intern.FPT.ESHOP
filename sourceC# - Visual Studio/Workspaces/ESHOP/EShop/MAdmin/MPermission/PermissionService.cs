using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MPermission
{
    public interface IPermissionService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, PermissionSearchEntity PermissionSearchEntity);
        List<PermissionEntity> Get(EmployeeEntity EmployeeEntity, PermissionSearchEntity PermissionSearchEntity);
        PermissionEntity Get(EmployeeEntity EmployeeEntity, Guid PermissionId);
        PermissionEntity Create(EmployeeEntity EmployeeEntity, PermissionEntity PermissionEntity);
        PermissionEntity Update(EmployeeEntity EmployeeEntity, Guid PermissionId, PermissionEntity PermissionEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid PermissionId);
    }
    public class PermissionService : CommonService, IPermissionService
    {
        public PermissionService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, PermissionSearchEntity PermissionSearchEntity)
        {
            return UnitOfWork.PermissionRepository.Count(PermissionSearchEntity);
        }
        public List<PermissionEntity> Get(EmployeeEntity EmployeeEntity, PermissionSearchEntity PermissionSearchEntity)
        {
            List<Permission> Permissions = UnitOfWork.PermissionRepository.List(PermissionSearchEntity);
            return Permissions.ToList().Select(c => new PermissionEntity(c)).ToList();
        }

        public PermissionEntity Get(EmployeeEntity EmployeeEntity, Guid PermissionId)
        {
            Permission Permission = UnitOfWork.PermissionRepository.Get(PermissionId);
            return new PermissionEntity(Permission);
        }
        public PermissionEntity Create(EmployeeEntity EmployeeEntity, PermissionEntity PermissionEntity)
        {
            if (PermissionEntity == null)
                throw new NotFoundException();
            Permission Permission = new Permission(PermissionEntity);
            UnitOfWork.PermissionRepository.AddOrUpdate(Permission);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Permission.Id);
        }
        public PermissionEntity Update(EmployeeEntity EmployeeEntity, Guid PermissionId, PermissionEntity PermissionEntity)
        {
            PermissionEntity.Id = PermissionId;
            Permission Permission = new Permission(PermissionEntity);
            UnitOfWork.PermissionRepository.AddOrUpdate(Permission);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Permission.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid PermissionId)
        {
            UnitOfWork.PermissionRepository.Delete(PermissionId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
