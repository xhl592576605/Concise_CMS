import request from '@/utils/request'

export function isTenantAvailable(tenancyName) {
  return request({
    url: `/services/app/Account/IsTenantAvailable`,
    method: 'post',
    data: { tenancyName: tenancyName }
  })
}

export function createTenant(data) {
  return request({
    url: `/services/app/Tenant/Create`,
    method: 'post',
    data: data
  })
}
export function deleteTenant(id) {
  return request({
    url: `/services/app/Tenant/Delete`,
    method: 'delete',
    params: {
      id: id
    }
  })
}

export function getTenant(id) {
  return request({
    url: `/services/app/Tenant/Get`,
    method: 'get',
    params: {
      id: id
    }
  })
}
export function getAllTenants(params) {
  return request({
    url: `/services/app/Tenant/GetAll`,
    method: 'get',
    params: params
  })
}

export function updateTenant(data) {
  return request({
    url: `/services/app/Tenant/Update`,
    method: 'put',
    data: data
  })
}
