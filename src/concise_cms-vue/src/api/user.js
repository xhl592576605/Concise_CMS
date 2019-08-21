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

export function logout() {
  return request({
    url: '/user/logout',
    method: 'post'
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

export function createUser(data) {
  return request({
    url: '/services/app/User/Create',
    method: 'post',
    data
  })
}

export function updateUser(data) {
  return request({
    url: '/services/app/User/Update',
    method: 'post',
    data
  })
}

export function deleteUser(id) {
  return request({
    url: `/services/app/User/Delete`,
    method: 'delete',
    params: {
      id: id
    }
  })
}


export function changePassword(data) {
  return request({
    url: '/services/app/User/ChangePassword',
    method: 'post',
    data
  })
}

export function resetPassword(data) {
  return request({
    url: '/services/app/User/ResetPassword',
    method: 'post',
    data
  })
}

export function GetAllUsers(params) {
  return request({
    url: `/services/app/User/GetAll`,
    method: 'get',
    params: params
  })
}