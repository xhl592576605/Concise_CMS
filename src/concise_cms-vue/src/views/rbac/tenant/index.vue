<template>
  <div class="app-container">
    <div class="filter-container">
      <el-input v-model="listQuery.keyWord" placeholder="租户名称" style="width: 200px;" class="filter-item" />
      <el-select v-model="listQuery.isActive" placeholder="是否激活" clearable class="filter-item" style="width: 130px">
        <el-option v-for="item in isActiveOption" :key="item.value" :label="item.label" :value="item.value" />
      </el-select>
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
      <el-table-column label="租户账号" align="center">
        <template slot-scope="{row}">
          <span>{{ row.tenancyName }}</span>
        </template>
      </el-table-column>
      <el-table-column label="租户名称" align="center">
        <template slot-scope="{row}">
          <span>{{ row.name }}</span>
        </template>
      </el-table-column>
      <!-- <el-table-column label="链接串" align="center">
        <template slot-scope="{row}">
          <span>{{ row.connectionString }}</span>
        </template>
      </el-table-column> -->
      <el-table-column label="状态" class-name="status-col" width="100">
        <template slot-scope="{row}">
          <el-tag :type="row.isActive?'success':'danger'">
            {{ row.isActive?'激活':'停用' }}
          </el-tag>
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
          <el-button v-if="row.status!='deleted'" size="mini" type="danger" @click="handleDelete(row)"
            :disabled="row.id===1">
            删除
          </el-button>
          <el-button type="success" size="mini" style="width:80px;">
            租户管理员
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <pagination v-show="total>0" :total="total" :float-right="true" :page.sync="listQuery.page"
      :limit.sync="listQuery.maxResultCount" @pagination="getAllTenants" />
    <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialogFormVisible">
      <el-form ref="dataForm" :rules="rules" :model="temp" label-position="left" label-width="100px"
        style="width: 500px; margin-left:50px;">
        <el-form-item label="租户账号" prop="tenancyName">
          <el-input v-model="temp.tenancyName" :disabled="dialogStatus==='update'" />
        </el-form-item>
        <el-form-item label="租户名称" prop="name">
          <el-input v-model="temp.name" />
        </el-form-item>
        <!-- <el-form-item label="链接串" prop="connectionString">
          <el-input v-model="temp.connectionString" />
        </el-form-item> -->
        <el-form-item v-if="dialogStatus==='create'" label="邮箱地址" prop="adminEmailAddress">
          <el-input v-model="temp.adminEmailAddress" type="email" placeholder="管理员邮箱地址" />
        </el-form-item>
        <el-form-item v-if="dialogStatus==='create'" label="默认密码" prop="adminPassword">
          <el-input v-model="temp.adminPassword" show-password placeholder="管理员默认密码" />
        </el-form-item>
        <el-form-item label="是否激活" prop="isActive">
          <el-select v-model="temp.isActive" class="filter-item" placeholder="请选择">
            <el-option v-for="item in isActiveOption.filter(function(el){
                // 过滤全选
                return el.value!=undefined
              })" :key="item.key" :label="item.label" :value="item.value" />
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
  </div>
</template>

<script>
import waves from '@/directive/waves' // waves directive
import Pagination from '@/components/Pagination' // secondary package based on el-pagination

import {
  createTenant,
  deleteTenant,
  getAllTenants,
  updateTenant
} from '@/api/tenant'

export default {
  name: 'Tenant',
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
        tenancyName: undefined,
        name: undefined,
        adminEmailAddress: undefined,
        connectionString: undefined,
        isActive: true,
        adminPassword: undefined
      },
      rules: {
        tenancyName: [
          { required: true, message: '租户账户是必须的', trigger: 'change' },
          {
            pattern: /^[a-zA-Z][a-zA-Z0-9_-]{1,}$/,
            message: '由字母，数字组成,首字符为字母'
          }
        ],
        name: [
          { required: true, message: '租户名称是必须的', trigger: 'change' }
        ],
        adminEmailAddress: [
          { required: true, message: '邮箱地址是必须的', trigger: 'change' },
          { type: 'email', message: '邮箱地址不符合规范' }
        ],
        adminPassword: [
          {
            required: true,
            message: '默认管理员密码是必须的',
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
      dialogStatus: ''
    }
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
    this.getAllTenants()
  },
  methods: {
    /** 根据条件获取所有租户信息 */
    getAllTenants() {
      this.listLoading = true
      getAllTenants(this.listQuery).then(response => {
        const { totalCount, items } = response.result
        this.list = items
        this.total = totalCount

        // Just to simulate the time of the request
        setTimeout(() => {
          this.listLoading = false
        }, 1.5 * 1000)
      }).catch(()=>{
          this.listLoading = false
      })
    },
    /** 过滤查询租户 */
    handleFilter() {
      this.listQuery.skipCount = 0
      this.getAllTenants()
    },
    resetTemp() {
      this.temp = (() => {
        return {
          id: undefined,
          tenancyName: undefined,
          name: undefined,
          adminEmailAddress: undefined,
          connectionString: undefined,
          isActive: true,
          adminPassword: '@aA123456'
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
      this.$confirm('此操作将删除租户, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          deleteTenant(row.id).then(response => {
            const that = this
            this.$message({
              type: 'success',
              message: '删除成功!',
              onClose: function() {
                that.getAllTenants()
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
          createTenant(this.temp).then(response => {
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
          updateTenant(tempData).then(response => {
            const { result } = response
            console.log(result)
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
    }
  }
}
</script>
