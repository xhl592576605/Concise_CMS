import request from '@/utils/request'

export function createRole(data) {
  return request({
    url: '/services/app/Role/Create',
    method: 'post',
    data
  })
}

export function getRolesAsync(permission) {
  return request({
    url: `/services/app/Role/GetRolesAsync`,
    method: 'get',
    params: {
      permission: permission
    }
  })
}

export function updateRole(data) {
  return request({
    url: '/services/app/Role/Update',
    method: 'put',
    data
  })
}

export function deleteRole(id) {
  return request({
    url: `/services/app/Role/Delete`,
    method: 'delete',
    params: {
      id: id
    }
  })
}

export function getAllPermissions() {
  return request({
    url: `/services/app/Role/GetAllPermissions`,
    method: 'get'
  })
}

export function getRoleForEdit(id) {
  return request({
    url: `/services/app/Role/GetRoleForEdit`,
    method: 'get',
    params: {
      id: id
    }
  })
}

export function getRole(id) {
  return request({
    url: `/services/app/Role/Get`,
    method: 'get',
    params: {
      id: id
    }
  })
}

export function getAllRoles(params) {
  return request({
    url: `/services/app/Role/GetAll`,
    method: 'get',
    params: params
  })
}
