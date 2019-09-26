import request from '@/utils/request'

export function createAsyncRoute(data) {
  return request({
    url: '/services/app/AsyncRoute/Create',
    method: 'post',
    data
  })
}

export function updateAsyncRoute(data) {
  return request({
    url: '/services/app/AsyncRoute/Update',
    method: 'put',
    data
  })
}

export function deleteAsyncRoute(id) {
  return request({
    url: `/services/app/AsyncRoute/Delete`,
    method: 'delete',
    params: {
      id: id
    }
  })
}

export function buildAsyncRouteMenus() {
  return request({
    url: `/services/app/AsyncRoute/BuildAsyncRouteMenus`,
    method: 'get'
  })
}

export function updateAsyncRoutesOrder(data) {
  return request({
    url: '/services/app/AsyncRoute/UpdateAsyncRoutesOrder',
    method: 'put',
    data
  })
}

export function getAllAsyncRoutersMap() {
  return request({
    url: `/services/app/AsyncRouterMapService/GetAll`,
    method: 'get'
  })
}

export function UpdateAsyncRoutersMapOrder(data) {
  return request({
    url: '/services/app/AsyncRouterMapService/UpdateAsyncRoutersMapOrder',
    method: 'put',
    data
  })
}
