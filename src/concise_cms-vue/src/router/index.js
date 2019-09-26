import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

/* Layout */
import Layout from '@/layout'

/**
 * Note: sub-menu only appear when route children.length >= 1
 * Detail see: https://panjiachen.github.io/vue-element-admin-site/guide/essentials/router-and-nav.html
 *
 * hidden: true                   if set true, item will not show in the sidebar(default is false)
 * alwaysShow: true               if set true, will always show the root menu
 *                                if not set alwaysShow, when item has more than one children route,
 *                                it will becomes nested mode, otherwise not show the root menu
 * redirect: noRedirect           if set noRedirect will no redirect in the breadcrumb
 * name:'router-name'             the name is used by <keep-alive> (must set!!!)
 * meta : {
    roles: ['admin','editor']    control the page roles (you can set multiple roles)
    title: 'title'               the name show in sidebar and breadcrumb (recommend set)
    icon: 'svg-name'             the icon show in the sidebar
    noCache: true                if set true, the page will no be cached(default is false)
    affix: true                  if set true, the tag will affix in the tags-view
    breadcrumb: false            if set false, the item will hidden in breadcrumb(default is true)
    activeMenu: '/example/list'  if set path, the sidebar will highlight the path you set
  }
 */

/**
 * constantRoutes
 * a base page that does not have permission requirements
 * all roles can be accessed
 */
export const constantRoutes = [
  {
    path: '/redirect',
    component: Layout,
    hidden: true,
    children: [
      {
        path: '/redirect/:path*',
        component: () => import('@/views/redirect/index')
      }
    ]
  },
  {
    path: '/login',
    component: () => import('@/views/login/index'),
    hidden: true
  },

  {
    path: '/404',
    component: () => import('@/views/404'),
    hidden: true
  },

  {
    path: '/',
    component: Layout,
    redirect: '/dashboard',
    children: [{
      path: 'dashboard',
      name: 'Dashboard',
      component: () => import('@/views/dashboard/index'),
      meta: { title: '首页', icon: 'dashboard', affix: true }
    }]
  },
  {
    path: '/error-log',
    component: Layout,
    children: [
      {
        path: 'log',
        component: () => import('@/views/error-log/index'),
        name: 'ErrorLog',
        meta: { title: 'Error Log', icon: 'bug' }
      }
    ]
  },
  {
    path: '/example',
    component: Layout,
    redirect: '/example/table',
    name: 'Example',
    meta: { title: 'Example', icon: 'example' },
    children: [
      {
        path: 'table',
        name: 'Table',
        component: () => import('@/views/table/index'),
        meta: { title: 'Table', icon: 'table' }
      },
      {
        path: 'tree',
        name: 'Tree',
        component: () => import('@/views/tree/index'),
        meta: { title: 'Tree', icon: 'tree' }
      }
    ]
  },

  {
    path: '/form',
    component: Layout,
    children: [
      {
        path: 'index',
        name: 'Form',
        component: () => import('@/views/form/index'),
        meta: { title: 'Form', icon: 'form' }
      }
    ]
  }
]

/**
 * asyncRoutes
 * the routes that need to be dynamically loaded based on user roles
 */
export const asyncRoutes = [
  {
    name: 'rbac',
    path: '/rbac',
    hidden: false,
    component: Layout,
    redirect: '/rbac/tenant',
    meta: {
      title: '权限管理',
      icon: 'rbac'
    },
    routeName: '权限管理',
    description: '权限管理，设置用户权限等',
    children: [
      {
        name: 'tenant',
        path: 'tenant',
        hidden: false,
        component: () => import('@/views/rbac/tenant/index'),
        meta: { title: '租户管理', icon: 'peoples', roles: ['ADMIN'] },
        routeName: '租户管理',
        description: '添加，编辑，删除租户'
      },
      {
        name: 'user',
        path: 'user',
        hidden: false,
        component: () => import('@/views/rbac/user/index'),
        meta: { title: '用户管理', icon: 'user', roles: ['ADMIN'] },
        routeName: '用户管理',
        description: '添加，编辑，删除租户用户'
      },
      {
        name: 'role',
        path: 'role',
        hidden: false,
        component: () => import('@/views/rbac/role/index'),
        meta: { title: '角色管理', icon: 'role', roles: ['ADMIN'] },
        routeName: '角色管理',
        description: '添加，编辑，删除租户角色'
      },
      {
        name: 'menu',
        path: 'menu',
        hidden: false,
        component: () => import('@/views/rbac/asyncRouter/index'),
        meta: { title: '菜单管理', icon: 'menu', roles: ['ADMIN'] },
        routeName: '菜单管理',
        description: '设置菜单的顺序，权限'
      }
    ]
  },
  // 404 page must be placed at the end !!!
  {
    name: '404',
    path: '*',
    redirect: '/404',
    hidden: true,
    meta: { title: '404页面', icon: 'menu', roles: ['ADMIN'] },
    routeName: '404',
    description: ''
  }
]

const createRouter = () => new Router({
  // mode: 'history', // require service support
  scrollBehavior: () => ({ y: 0 }),
  routes: constantRoutes
})

const router = createRouter()

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter() {
  const newRouter = createRouter()
  router.matcher = newRouter.matcher // reset router
}

export default router
