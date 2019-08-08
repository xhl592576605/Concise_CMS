import Cookies from 'js-cookie'
const settingsKey = 'concise_CMS_seetting'

function getSettings() {
  const settingsJsonStr = Cookies.get(settingsKey) || ''
  if (settingsJsonStr !== '') {
    return JSON.parse(settingsJsonStr) || undefined
  }
  return undefined
}

export function getSettingCookies(key) {
  var settings = getSettings()
  if (settings === undefined) {
    return undefined
  }
  return settings[key]
}

export function changeSettingsCookies(key, value) {
  var settings = getSettings() || {}
  settings[key] = value
  Cookies.set(settingsKey, JSON.stringify(settings))
}

export function removeSettingCookies() {
  Cookies.remove(settingsKey)
}
