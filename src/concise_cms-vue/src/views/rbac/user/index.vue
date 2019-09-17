<template>
  <div class="app-container">
    <div class="filter-container">
      <el-input v-model="listQuery.keyWord" placeholder="关键词" style="width: 200px;" class="filter-item" />
      <el-select v-model="listQuery.isActive" placeholder="是否激活" clearable class="filter-item" style="width: 130px">
        <el-option v-for="item in isActiveOption" :key="item.value" :label="item.label" :value="item.value" />
      </el-select>
      <el-button v-waves class="filter-item" type="success" icon="el-icon-search" @click="handleFilter">搜索</el-button>
      <el-button
        class="filter-item"
        style="margin-left: 10px;"
        type="primary"
        icon="el-icon-edit"
        @click="handleCreate"
      >添加</el-button>
    </div>

    <el-table
      :key="tableKey"
      v-loading="listLoading"
      :data="list"
      border
      fit
      highlight-current-row
      style="width: 100%;"
    >
      <el-table-column label="ID" prop="id" sortable="custom" align="center" width="80">
        <template slot-scope="scope">
          <span>{{ scope.row.id }}</span>
        </template>
      </el-table-column>
      <el-table-column label="用户账号" align="center">
        <template slot-scope="{row}">
          <span>{{ row.userName }}{{ row.id==user.id?'(目前登录)':'' }}</span>
        </template>
      </el-table-column>
      <el-table-column label="用户名称" align="center">
        <template slot-scope="{row}">
          <span>{{ row.surname }}{{ row.name }}</span>
        </template>
      </el-table-column>
      <el-table-column label="邮箱地址" align="center">
        <template slot-scope="{row}">
          <span>{{ row.emailAddress }}</span>
        </template>
      </el-table-column>
      <el-table-column label="状态" class-name="status-col" width="100">
        <template slot-scope="{row}">
          <el-tag :type="row.isActive?'success':'danger'">
            {{ row.isActive?'激活':'停用' }}
          </el-tag>
        </template>
      </el-table-column>
      <el-table-column label="最后登录时间" align="center" width="150">
        <template slot-scope="{row}">
          <span>{{ row.lastLoginTime | parseTime('{y}-{m}-{d} {h}:{i}') }}</span>
        </template>
      </el-table-column>
      <el-table-column label="创建时间" align="center" width="150">
        <template slot-scope="{row}">
          <span>{{ row.creationTime | parseTime('{y}-{m}-{d} {h}:{i}') }}</span>
        </template>
      </el-table-column>
      <el-table-column label="操作" align="center" width="350" class-name="small-padding fixed-width">
        <template slot-scope="{row}">
          <el-button type="primary" size="mini" @click="handleUpdate(row)">
            编辑
          </el-button>
          <el-button
            v-if="row.status!='deleted'"
            size="mini"
            type="danger"
            :disabled="row.id==user.id"
            @click="handleDelete(row)"
          >
            删除
          </el-button>
          <el-button
            v-if="user.name=='admin'"
            size="mini"
            type="primary"
            style="width:80px;"
            :disabled="row.id==user.id"
            @click="handleResetPassWord(row)"
          > 重置密码
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination
      v-show="total>0"
      :total="total"
      :float-right="true"
      :page.sync="listQuery.page"
      :limit.sync="listQuery.maxResultCount"
      @pagination="getAllUsers"
    />

    <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialogFormVisible">
      <el-form
        ref="dataForm"
        :rules="rules"
        :model="temp"
        label-position="left"
        label-width="100px"
        style="width: 500px; margin-left:50px;"
      >
        <el-form-item label="用户账号" prop="userName">
          <el-input v-model="temp.userName" :disabled="dialogStatus==='update'" />
        </el-form-item>
        <el-form-item label="用户名称" prop="name">
          <el-input v-model="temp.name" />
        </el-form-item>
        <el-form-item label="用户姓氏" prop="surname">
          <el-input v-model="temp.surname" />
        </el-form-item>
        <el-form-item v-if="dialogStatus==='create'" label="邮箱地址" prop="emailAddress">
          <el-input v-model="temp.emailAddress" type="email" placeholder="邮箱地址" />
        </el-form-item>
        <el-form-item v-if="dialogStatus==='create'" label="默认密码" prop="password">
          <el-input v-model="temp.password" show-password placeholder="默认密码" />
        </el-form-item>
        <el-form-item label="是否激活" prop="isActive">
          <el-select v-model="temp.isActive" class="filter-item" placeholder="请选择">
            <el-option
              v-for="item in isActiveOption.filter(function(el){
                // 过滤全选
                return el.value!=undefined
              })"
              :key="item.key"
              :label="item.label"
              :value="item.value"
            />
          </el-select>
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
    <el-dialog title="重置密码" :visible.sync="resetPassDialogFormVisible">
      <el-form
        ref="dataResetPassForm"
        :rules="resetPassTempRules"
        :model="resetPassTemp"
        label-position="left"
        label-width="100px"
        style="width: 500px; margin-left:50px;"
      >
        <el-form-item label="管理员密码" prop="adminPassword">
          <el-input v-model="resetPassTemp.adminPassword" show-password placeholder="管理员密码" />
        </el-form-item>
        <el-form-item label="新密码" prop="newPassword">
          <el-input v-model="resetPassTemp.newPassword" show-password placeholder="新密码" />
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="resetPassDialogFormVisible = false">
          取消
        </el-button>
        <el-button type="primary" @click="resetPassword()">
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
  createUser,
  deleteUser,
  getAllUsers,
  updateUser,
  resetPassword
} from '@/api/user'
import { mapGetters } from 'vuex'

export default {
  name: 'User',
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
        keyWord: undefined,
        isActive: undefined
      },
      isActiveOption: [
        {
          value: undefined,
          label: '--'
        },
        {
          value: true,
          label: '激活'
        },
        {
          value: false,
          label: '停用'
        }
      ],
      temp: {
        id: undefined,
        userName: undefined,
        name: undefined,
        surname: undefined,
        emailAddress: undefined,
        isActive: true,
        password: undefined
      },
      rules: {
        userName: [
          { required: true, message: '租户账户是必须的', trigger: 'change' },
          {
            pattern: /^[a-zA-Z][a-zA-Z0-9_-]{1,}$/,
            message: '由字母，数字组成,首字符为字母'
          }
        ],
        name: [
          { required: true, message: '租户名称是必须的', trigger: 'change' }
        ],
        surname: [
          { required: true, message: '租户姓氏是必须的', trigger: 'change' }
        ],
        emailAddress: [
          { required: true, message: '邮箱地址是必须的', trigger: 'change' },
          { type: 'email', message: '邮箱地址不符合规范' }
        ],
        password: [
          {
            required: true,
            message: '默认密码是必须的',
            trigger: 'change'
          },
          {
            pattern: /^.*(?=.{6,})(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*? ]).*$/,
            message:
              '最少6位，包括至少1个大写字母，1个小写字母，1个数字，1个特殊字符',
            trigger: 'change'
          }
        ]
      },
      textMap: {
        update: '编辑',
        create: '创建'
      },
      dialogFormVisible: false,
      dialogStatus: '',
      resetPassTemp: {
        adminPassword: undefined,
        userId: undefined,
        newPassword: undefined
      },
      resetPassTempRules: {
        adminPassword: [
          {
            required: true,
            message: '重置用户密码必须输入管理员密码',
            trigger: 'change'
          }
        ],
        newPassword: [
          { required: true, message: '新密码必须填写', trigger: 'change' },
          {
            pattern: /^.*(?=.{6,})(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*? ]).*$/,
            message:
              '最少6位，包括至少1个大写字母，1个小写字母，1个数字，1个特殊字符',
            trigger: 'change'
          }
        ]
      },
      resetPassDialogFormVisible: false
    }
  },
  computed: {
    ...mapGetters(['user'])
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
    this.getAllUsers()
  },
  methods: {
    /** 根据条件获取所有租户信息 */
    getAllUsers() {
      this.listLoading = true
      getAllUsers(this.listQuery)
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
      this.getAllUsers()
    },
    resetTemp() {
      this.temp = (() => {
        return {
          id: undefined,
          userName: undefined,
          name: undefined,
          surname: undefined,
          emailAddress: undefined,
          isActive: true,
          password: '@aA123456'
        }
      })()
    },
    resetResetPassTemp() {
      this.resetPassTemp = (() => {
        return {
          adminPassword: undefined,
          userId: undefined,
          newPassword: undefined
        }
      })()
    },
    /** 创建处理 */
    handleCreate() {
      this.dialogStatus = 'create'
      this.resetTemp()
      this.dialogFormVisible = true
      this.$nextTick(() => {
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
      })
    },
    /** 删除处理 */
    handleDelete(row) {
      this.$confirm('此操作将删除用户, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          deleteUser(row.id).then(response => {
            const that = this
            this.$message({
              type: 'success',
              message: '删除成功!',
              onClose: function() {
                that.getAllUsers()
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
    /** 重置密码 */
    handleResetPassWord(row) {
      this.resetResetPassTemp()
      this.resetPassTemp.userId = row.id
      this.resetPassDialogFormVisible = true
      this.$nextTick(() => {
        this.$refs['dataResetPassForm'].clearValidate()
      })
    },
    createData() {
      this.$refs['dataForm'].validate(valid => {
        if (valid) {
          createUser(this.temp).then(response => {
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
          updateUser(tempData).then(response => {
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
    resetPassword() {
      this.$refs['dataResetPassForm'].validate(valid => {
        if (valid) {
          resetPassword(this.resetPassTemp).then(response => {
            this.resetPassDialogFormVisible = false
            this.$message({
              type: 'success',
              message: '重置密码成功!'
            })
          })
        }
      })
    }
  }
}
</script>
