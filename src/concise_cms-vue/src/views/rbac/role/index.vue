<template>
  <div class="app-container">
    <div class="filter-container">
      <el-input v-model="listQuery.keyWord" placeholder="关键词" style="width: 200px;" class="filter-item" />
      <el-button v-waves class="filter-item" type="success" icon="el-icon-search" @click="handleFilter">搜索</el-button>
      <el-button class="filter-item" style="margin-left: 10px;" type="primary" icon="el-icon-edit"
        @click="handleCreate">添加</el-button>
    </div>
    <el-table :key="tableKey" v-loading="listLoading" :data="list" border fit highlight-current-row
      style="width: 100%;">
      <el-table-column label="ID" prop="id" sortable="custom" align="center" width="80">
        <template slot-scope="scope">
          <span>{{ scope.row.id }}</span>
        </template>
      </el-table-column>
      <el-table-column label="角色名称" align="center">
        <template slot-scope="{row}">
          <span>{{ row.name }}</span>
        </template>
      </el-table-column>
      <el-table-column label="显示名称" align="center">
        <template slot-scope="{row}">
          <span>{{ row.displayName }}</span>
        </template>
      </el-table-column>
      <el-table-column label="角色描述" align="left" :show-overflow-tooltip="true">
        <template slot-scope="{row}">
          <span>{{ row.description }}</span>
        </template>
      </el-table-column>
      <el-table-column label="静态" class-name="status-col" width="100">
        <template slot-scope="{row}">
          <el-tag :type="row.isStatic?'success':'danger'">
            {{ row.isStatic?'静态':'非静态' }}
          </el-tag>
        </template>
      </el-table-column>
      <el-table-column label="操作" align="center" width="350" class-name="small-padding fixed-width">
        <template slot-scope="{row}">
          <el-button type="primary" size="mini" @click="handleUpdate(row)">
            编辑
          </el-button>
          <el-button v-if="row.status!='deleted'" size="mini" type="danger" @click="handleDelete(row)">
            删除
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination v-show="total>0" :total="total" :float-right="true" :page.sync="listQuery.page"
      :limit.sync="listQuery.maxResultCount" @pagination="getAllRoles" />

    <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialogFormVisible">
      <el-form ref="dataForm" :rules="rules" :model="temp" label-position="left" label-width="100px"
        style="width: 500px; margin-left:50px;">
        <el-form-item label="角色名称" prop="name">
          <el-input v-model="temp.name" :disabled="dialogStatus==='update'" />
        </el-form-item>
        <el-form-item label="显示名称" prop="displayName">
          <el-input v-model="temp.displayName" />
        </el-form-item>
        <el-form-item label="预定义" prop="isStatic">
          <el-select v-model="temp.isStatic" class="filter-item" placeholder="请选择">
            <el-option v-for="item in isStaticOption" :key="item.key" :label="item.label" :value="item.value" />
          </el-select>
        </el-form-item>
        <el-form-item label="角色描述" prop="description">
          <el-input v-model="temp.description" type="textarea" :autosize="{ minRows: 2, maxRows: 5}" />
        </el-form-item>
        <el-form-item label="权限级别">
          <el-tree ref="premissionsTree" :data="allPermissions" :props="defaultProps" show-checkbox node-key="name"
            class="permission-tree" />
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">
          取消
        </el-button>
        <el-button type="primary" @click="dialogStatus==='create'?createData():updateData()">
          确认
        </el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import waves from '@/directive/waves' // waves directive
import Pagination from '@/components/Pagination' // secondary package based on el-pagination
import {
  getAllRoles,
  deleteRole,
  createRole,
  updateRole,
  getRole,
  getAllPermissions
} from '@/api/role'
import { mapGetters } from 'vuex'
export default {
  name: 'Role',
  components: { Pagination },
  directives: { waves },
  data() {
    return {
      tableKey: 0,
      list: null,
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        skipCount: undefined,
        maxResultCount: 10,
        keyWord: undefined
      },
      isStaticOption: [
        {
          value: true,
          label: '预定义'
        },
        {
          value: false,
          label: '非预定义'
        }
      ],
      temp: {
        id: undefined,
        name: undefined,
        displayName: undefined,
        normalizedName: undefined,
        isStatic: true,
        description: undefined,
        permissions: []
      },
      allPermissions: [],
      permissionData: [],
      defaultProps: {
        label: 'displayName'
      },
      rules: {
        name: [
          { required: true, message: '角色名称是必须的', trigger: 'change' },
          {
            pattern: /^[a-z]+$/i,
            message: '只能由小写字母组成'
          }
        ],
        displayName: [
          { required: true, message: '角色显示名称是必须的', trigger: 'change' }
        ]
      },
      textMap: {
        update: '编辑',
        create: '创建'
      },
      dialogFormVisible: false,
      dialogStatus: ''
    }
  },
  computed: {
    ...mapGetters(['user', 'roles'])
  },
  watch: {
    /** 监听skipCount */
    listQuery: {
      handler(val) {
        val.skipCount = (val.page - 1) * val.maxResultCount
      },
      deep: true
    }
  },
  created() {
    this.getAllRoles()
    this.getAllPermissions()
  },
  methods: {
    getAllRoles() {
      this.listLoading = true
      getAllRoles(this.listQuery)
        .then(response => {
          const { totalCount, items } = response.result
          this.list = items
          this.total = totalCount

          // Just to simulate the time of the request
          setTimeout(() => {
            this.listLoading = false
          }, 1.5 * 1000)
        })
        .catch(() => {
          this.listLoading = false
        })
    },
    /** 过滤查询租户 */
    handleFilter() {
      this.listQuery.skipCount = 0
      this.getAllRoles()
    },
    resetTemp() {
      this.temp = (() => {
        return {
          id: undefined,
          name: undefined,
          displayName: undefined,
          isStatic:true,
          normalizedName: undefined,
          description: undefined,
          permissions: []
        }
      })()
    },
    /** 创建处理 */
    handleCreate() {
      this.dialogStatus = 'create'
      this.resetTemp()
      this.dialogFormVisible = true
      this.$nextTick(() => {
        this.$refs['premissionsTree'].setCheckedNodes([])
        this.$refs['dataForm'].clearValidate()
      })
    },
    /** 修改处理 */
    handleUpdate(row) {
      this.temp = Object.assign({}, row) // copy obj
      this.dialogStatus = 'update'
      this.dialogFormVisible = true
      this.$nextTick(() => {
        this.$refs['dataForm'].clearValidate()
        this.setEditRolePermissions(row.id)
      })
    },
    /** 删除处理 */
    handleDelete(row) {
      this.$confirm('此操作将删除角色, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          deleteRole(row.id).then(response => {
            const that = this
            this.$message({
              type: 'success',
              message: '删除成功!',
              onClose: function() {
                that.getAllRoles()
              }
            })
          })
        })
        .catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          })
        })
    },
    createData() {
      this.$refs['dataForm'].validate(valid => {
        if (valid) {
          this.temp.normalizedName = this.temp.name.toUpperCase()
          this.temp.permissions=this.$refs['premissionsTree'].getCheckedKeys()
          createRole(this.temp).then(response => {
            const { result } = response
            this.list.unshift(result)
            this.dialogFormVisible = false
            this.$message({
              type: 'success',
              message: '创建成功!'
            })
          })
        }
      })
    },
    updateData() {
      this.$refs['dataForm'].validate(valid => {
        if (valid) {
          const tempData = Object.assign({}, this.temp)
          updateRole(tempData).then(response => {
            const { result } = response
            for (const v of this.list) {
              if (v.id === result.id) {
                const index = this.list.indexOf(v)
                this.list.splice(index, 1, result)
                break
              }
            }
            this.dialogFormVisible = false
            this.$message({
              type: 'success',
              message: '修改成功!'
            })
          })
        }
      })
    },
    getAllPermissions() {
      getAllPermissions().then(response => {
        const { items } = response.result
        this.allPermissions = items
      })
    },
    setEditRolePermissions(id) {
      getRole(id).then(response => {
        const { permissions } = response.result
        let res = []
        for (let pName of permissions) {
          res.push({
            name: pName
          })
        }
        this.$refs['premissionsTree'].setCheckedNodes(res)
      })
    }
  }
}
</script>
<style lang="scss" scoped>
.app-container {
  .roles-table {
    margin-top: 30px;
  }
  .permission-tree {
    margin-bottom: 30px;
  }
}
</style>