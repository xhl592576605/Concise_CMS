import request from '@/utils/request'

export function login(data) {
  return request({
    url: `/TokenAuth/Authenticate`, // '/user/login',
    method: 'post',
    data
  })
}

export function getInfo() {
  return request({
    url: `/services/app/Session/GetCurrentLoginInformations`, // '/user/info',
    method: 'get'
  })
}

export function getUser(id) {
  return request({
    url: `/services/app/User/Get`,
    method: 'get',
    params: {
      id: id
    }
  })
}

export function logout() {
  return request({
    url: '/user/logout',
    method: 'post'
  })
}
