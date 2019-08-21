import axios from 'axios'
import { Message } from 'element-ui' // MessageBox
import store from '@/store'
import { getToken } from '@/utils/auth'

// create an axios instance
const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API, // url = base url + request url
  // withCredentials: true, // send cookies when cross-domain requests
  timeout: 5000 // request timeout
})

// request interceptor
service.interceptors.request.use(
  config => {
    // do something before request is sent

    if (store.getters.token) {
      // let each request carry token
      // ['Authorization'] is a custom headers key
      // please modify it according to the actual situation
      config.headers['Authorization'] = `Bearer ${getToken()}`
    }
    return config
  },
  error => {
    // do something with request error
    console.log(error) // for debug
    return Promise.reject(error)
  }
)

// response interceptor
service.interceptors.response.use(
  /**
   * If you want to get http information such as headers or status
   * Please return  response => response
  */

  /**
   * Determine the request status by custom code
   * Here is just an example
   * You can also judge the status by HTTP Status Code
   */
  response => {
    const res = response.data

    // 处理ABP的WebApi接口返回数据
    if (!res.success) {
      const errorMessage = {
        message: '',
        type: 'error',
        duration: 5 * 1000
      }

      // TODO:判断token是否是失效，失效重新获取

      errorMessage.message = `${res.error.message}(${res.error.details || '无详细信息'})`
      Message(errorMessage)
    } else {
      return res
    }

    // if the custom code is not 20000, it is judged as an error.
    // if (res.code !== 20000) {
    //   Message({
    //     message: res.message || 'Error',
    //     type: 'error',
    //     duration: 5 * 1000
    //   })

    //   // 50008: Illegal token; 50012: Other clients logged in; 50014: Token expired;
    //   if (res.code === 50008 || res.code === 50012 || res.code === 50014) {
    //     // to re-login
    //     MessageBox.confirm('You have been logged out, you can cancel to stay on this page, or log in again', 'Confirm logout', {
    //       confirmButtonText: 'Re-Login',
    //       cancelButtonText: 'Cancel',
    //       type: 'warning'
    //     }).then(() => {
    //       store.dispatch('user/resetToken').then(() => {
    //         location.reload()
    //       })
    //     })
    //   }
    //   return Promise.reject(new Error(res.message || 'Error'))
    // } else {
    //   return res
    // }
  },
  error => {
    console.log('err' + error) // for debug
    const errorMessage = {
      message: '',
      type: 'error',
      duration: 5 * 1000
    }

    if (error.response.data instanceof Object) {
      const data = error.response.data
      if (data.success) {
        errorMessage.type = 'success'
      }
      errorMessage.message = `${data.error.message}(${data.error.details || '无详细信息'})`
    } else {
      errorMessage.message = error.message
    }
    Message(errorMessage)
    return Promise.reject(error)
  }
)

export default service
