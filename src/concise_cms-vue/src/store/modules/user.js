import { login, getInfo, getUser } from '@/api/user' // logout
import { getToken, setToken, removeToken } from '@/utils/auth'
import { resetRouter } from '@/router'

const state = {
  token: getToken(),
  name: '',
  avatar: '',
  roles: []
}

const mutations = {
  SET_TOKEN: (state, token) => {
    state.token = token
  },
  SET_NAME: (state, name) => {
    state.name = name
  },
  SET_AVATAR: (state, avatar) => {
    state.avatar = avatar
  },
  SET_ROLES: (state, roles) => {
    state.roles = roles
  }
}

const actions = {
  // user login
  login({ commit }, userInfo) {
    const { usernameOrEmailAddress, password } = userInfo
    return new Promise((resolve, reject) => {
      login({ usernameOrEmailAddress: usernameOrEmailAddress.trim(), password: password }).then(response => {
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

        getUser(id).then(response => {
          const { userName, roleNames, avatar } = response.result
          if (!roleNames || roleNames.length <= 0) {
            reject('getInfo: roles must be a non-null array!')
          }
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
      commit('SET_TOKEN', '')
      commit('SET_ROLES', [])
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

