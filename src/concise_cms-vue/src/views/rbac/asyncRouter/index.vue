<template>
  <div class="app-container">
    <div v-loading="treeLoading" class="aysncRoute-tree">
      <vue-nestable v-model="nestableItems" :max-depth="3" :hooks="{'beforeMove': beforeMove}" key-prop="name">
        <div slot="placeholder" class="text-center">
          <p>暂无数据</p>
        </div>
        <vue-nestable-handle slot-scope="{ item }" :item="item">
          <svg-icon icon-class="list" /> &nbsp;
          {{ item.routeName }}{{ !item.hidden?'':'(非菜单)' }} &nbsp;&nbsp;&nbsp;
          <el-button size="mini" type="primary">权限设置 </el-button>
        </vue-nestable-handle>
      </vue-nestable>
    </div>
    <div class="text-center">
      <el-button type="primary" @click="UpdateAsyncRoutesMapOrder()"><i class="el-icon-sort" />保存菜单排序</el-button>
    </div>
  </div>
</template>
<script>
import {
  getAllAsyncRoutersMap,
  UpdateAsyncRoutersMapOrder
} from '@/api/asyncRouter'

import { VueNestable, VueNestableHandle } from 'vue-nestable'
import { resetRouter, asyncRoutes } from '@/router'
import { deepOrderBy } from '@/utils'
import { completeAssignmentAsyncRoute } from '@/store/modules/permission'
import store from '@/store'
export default {
  name: 'AsyncRouter',
  components: { VueNestable, VueNestableHandle },
  data() {
    return {
      treeLoading: true,
      nestableItems: []
    }
  },
  created() {
    const that = this
    that.$message({
      type: 'warning',
      message:
        '该模块为超级管理员或开发人员配置，请勿随意配置，导致系统崩溃！！！',
      duration: 5000,
      onClose: function() {
        that.buildAsyncRouteMenus()
        that.$message({
          type: 'info',
          message: '只允许同级进行上下排序'
        })
      }
    })
  },
  methods: {
    /** 创建菜单树 */
    buildAsyncRouteMenus() {
      this.treeLoading = true
      this.dealAsynRoutes()
      setTimeout(() => {
        this.treeLoading = false
      }, 1.5 * 1000)
    },
    /** 处理菜单树 */
    dealAsynRoutes() {
      const that = this
      // 1. 获取排序，角色映射
      getAllAsyncRoutersMap()
        .then(response => {
          const { items } = response.result
          // 2.整理赋值
          completeAssignmentAsyncRoute(asyncRoutes, items)
        })
        .then(res => {
          // 3. 排序
          that.nestableItems = deepOrderBy(asyncRoutes, ['order'], ['children'])
        })
    },
    /** 更新菜单顺序 */
    UpdateAsyncRoutesMapOrder() {
      const that = this
      that
        .$confirm('确定要保存菜单顺序吗？', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        })
        .then(() => {
          const orderArray = that.getOrder([], that.nestableItems)
          if (orderArray) {
            UpdateAsyncRoutersMapOrder(orderArray).then(response => {
              that.$message({
                type: 'success',
                message: '排序成功!',
                onClose: function() {
                  // 重新生成菜单树以及重置路由
                  that.buildAsyncRouteMenus()
                  that.resetRouter()
                }
              })
            })
          }
        })
    },
    /** 排序返回id数组 */
    getOrder(arr, items) {
      const that = this
      items.forEach(item => {
        arr.push({
          name: item.name,
          children: that.getOrder([], item.children || [])
        })
      })
      return arr
    },
    /** 重置 网站左边的菜单 */
    resetRouter() {
      resetRouter()
      store.dispatch('user/getInfo').then(res => {
        const { roleNames } = res
        store.dispatch('permission/generateRoutes', roleNames) // .then(res => {
      })
    },
    /**
     * 拖拽钩子 这个钩子有个问题，有子集不能往下拉
     */
    beforeMove({ dragItem, pathFrom, pathTo }) {
      // 404 不能拖拽，并只能保持在最后
      if (
        dragItem.name === '404' ||
        pathTo[0] === this.nestableItems.length - 1
      ) {
        return false
      }
      // 由于vue路由的特殊，只允许同级更换，不允许上下级更换，不然会导致没办法正确进入到页面
      if (pathFrom.length === pathTo.length) {
        // 最后一位不比较
        for (var i = 0; i <= pathFrom.length - 2; i++) {
          if (pathFrom[i] !== pathTo[i]) {
            return false
          }
        }
        return true
      }
      return false
    }
  }
}
</script>
<style  lang="scss" scoped>
.aysncRoute-tree {
  min-height: 120px;
  max-height: 600px;
  min-width: 800px;
  margin: 10px auto;
  padding: 5px 15px;
}
.aysncRoute-path {
  color: #f8f8ff;
}
</style>
