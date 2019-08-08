import variables from '@/styles/element-variables.scss'
import defaultSettings from '@/settings'
// 暂时不需要缓存的cookie
// import { getSettingCookies, changeSettingsCookies } from '@/utils/settings'

const { showSettings, tagsView, fixedHeader, sidebarLogo } = defaultSettings

const state = {
  theme: variables.theme, // getSettingCookies('theme') || variables.theme,
  showSettings: showSettings, // getSettingCookies('showSettings') || showSettings,
  tagsView: tagsView, // getSettingCookies('tagsView') || tagsView,
  fixedHeader: fixedHeader, // getSettingCookies('fixedHeader') || fixedHeader,
  sidebarLogo: sidebarLogo// getSettingCookies('sidebarLogo') || sidebarLogo
}

const mutations = {
  CHANGE_SETTING: (state, { key, value }) => {
    if (state.hasOwnProperty(key)) {
      state[key] = value
      // changeSettingsCookies(key, value)
    }
  }
}

const actions = {
  changeSetting({ commit }, data) {
    commit('CHANGE_SETTING', data)
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

