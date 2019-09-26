import { asyncRoutes, constantRoutes } from '@/router'
import { deepOrderBy } from '@/utils'
import { getAllAsyncRoutersMap } from '@/api/asyncRouter'

/**
 * Use meta.role to determine if the current user has permission
 * @param roles
 * @param route
 */
function hasPermission(roles, route) {
  if (route.meta && route.meta.roles) {
    return roles.some(role => route.meta.roles.includes(role))
  } else {
    return true
  }
}

/**
 * order asyncRoute and give 'asyncRoute.meta.roles' value
 * @param {*} asyncRoutes
 * @param {*} allMap
 */
export function completeAssignmentAsyncRoute(asyncRoutes, allMap) {
  asyncRoutes.forEach(item => {
    const mapInfo = allMap.find(value => {
      return value.name === item.name
    })
    if (mapInfo) {
      item.order = mapInfo.order || 0
      item.meta.roles = mapInfo.roles || []
    } else {
      item.order = 0
      item.meta.roles = []
    }
    completeAssignmentAsyncRoute(item.children || [], allMap)
  })
}

/**
 * Filter asynchronous routing tables by recursion
 * @param routes asyncRoutes
 * @param roles
 */
export function filterAsyncRoutes(routes, roles) {
  const res = []

  routes.forEach(route => {
    const tmp = { ...route }
    if (hasPermission(roles, tmp)) {
      if (tmp.children) {
        tmp.children = filterAsyncRoutes(tmp.children, roles)
      }
      res.push(tmp)
    }
  })

  return res
}

const state = {
  routes: [],
  addRoutes: []
}

const mutations = {
  SET_ROUTES: (state, routes) => {
    state.addRoutes = routes
    state.routes = constantRoutes.concat(routes)
  }
}

const actions = {
  generateRoutes({ commit }, roles) {
    return new Promise(resolve => {
      // 1. 获取异步路由
      let accessedRoutes = asyncRoutes || []
      // 2. 获取排序与角色映射
      getAllAsyncRoutersMap().then(response => {
        const { items } = response.result
        // 3. 讲获取的排序与角色赋值异步路由
        completeAssignmentAsyncRoute(accessedRoutes, items)
      }).then(res => {
        // 4. 根据排序的进行异步路由排序
        accessedRoutes = deepOrderBy(accessedRoutes, ['order'], ['children'])
        // 5. 角色过滤
        if (roles.includes('admin'.toUpperCase())) {
          accessedRoutes = accessedRoutes || []
        } else {
          accessedRoutes = filterAsyncRoutes(accessedRoutes, roles)
        }
        commit('SET_ROUTES', accessedRoutes)
        resolve(accessedRoutes)
      })
    })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
