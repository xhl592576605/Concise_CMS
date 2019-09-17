import { login, getInfo, getUser } from '@/api/user' // logout
import { isTenantAvailable } from '@/api/tenant'
import { getToken, setToken, removeToken } from '@/utils/auth'
import { resetRouter } from '@/router'

import { Message } from 'element-ui' // MessageBox

const state = {
  token: getToken(),
  id: '',
  name: '',
  avatar: '',
  roles: [],
  tenant: {}
}

const mutations = {
  SET_TOKEN: (state, token) => {
    state.token = token
  },
  SET_ID: (state, id) => {
    state.id = id
  },
  SET_NAME: (state, name) => {
    state.name = name
  },
  SET_AVATAR: (state, avatar) => {
    state.avatar = avatar
  },
  SET_ROLES: (state, roles) => {
    state.roles = roles
  },
  SET_TENANT: (state, tenant) => {
    state.tenant = tenant
  }
}

const actions = {
  // user login
  login({ commit }, userInfo) {
    const { tenancyName, usernameOrEmailAddress, password } = userInfo
    return new Promise((resolve, reject) => {
      const login_data = { tenancyName: tenancyName, usernameOrEmailAddress: usernameOrEmailAddress.trim(), password: password }
      // 有租户需先验证租户
      if (tenancyName !== '' && tenancyName !== undefined) {
        isTenantAvailable(tenancyName).then(response => {
          const { result } = response
          /**
           * Available = 1,
           * InActive = 2,
           * NotFound =3
           */
          if (result.state !== '1') {
            Message({
              message: '租户不存在或已被停用',
              type: 'error',
              duration: 5 * 1000
            })
            reject()
            return
          }
          login(login_data).then(response => {
            const { result } = response
            commit('SET_TOKEN', result.accessToken)
            setToken(result.accessToken,
              {
                expires: new Date(new Date().getTime() + result.expireInSeconds * 1000) // 取现在的时间毫秒数+失效的秒数*1000=>失效日期
              })
            resolve()
          }).catch(error => {
            reject(error)
          })
        })
      } else {
        login(login_data).then(response => {
          const { result } = response
          commit('SET_TOKEN', result.accessToken)
          setToken(result.accessToken,
            {
              expires: new Date(new Date().getTime() + result.expireInSeconds * 1000) // 取现在的时间毫秒数+失效的秒数*1000=>失效日期
            })
          resolve()
        }).catch(error => {
          reject(error)
        })
      }
    })
  },

  // get user info
  getInfo({ commit, state }) {
    return new Promise((resolve, reject) => {
      getInfo(state.token).then(response => {
        const { result } = response

        if (!result) {
          reject('Verification failed, please Login again.')
        }

        const { id } = result.user
        commit('SET_TENANT', result.tenant)
        getUser(id).then(response => {
          const { id, userName, roleNames, avatar } = response.result
          if (!roleNames || roleNames.length <= 0) {
            reject('getInfo: roles must be a non-null array!')
          }
          commit('SET_ID', id)
          commit('SET_ROLES', roleNames)
          commit('SET_NAME', userName)
          commit('SET_AVATAR', avatar || 'https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif')
          resolve(response.result)
        }).catch(error => {
          reject(error)
        })
      }).catch(error => {
        reject(error)
      })
    })
  },

  // user logout
  logout({ commit, state }) {
    return new Promise((resolve, reject) => {
      commit('SET_ID', '')
      commit('SET_TOKEN', '')
      commit('SET_ROLES', [])
      commit('SET_TENANT', {})
      removeToken()
      resetRouter()
      resolve()
      // logout(state.token).then(() => {

      // }).catch(error => {
      //   reject(error)
      // })
    })
  },

  // remove token
  resetToken({ commit }) {
    return new Promise(resolve => {
      commit('SET_TOKEN', '')
      removeToken()
      resolve()
    })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

