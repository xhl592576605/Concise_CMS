import Cookies from 'js-cookie'

const TokenKey = 'concise_CMS_token'

export function getToken() {
  return Cookies.get(TokenKey)
}

export function setToken(token, options = { expires: 1 }) {
  return Cookies.set(TokenKey, token, options)
}

export function removeToken() {
  return Cookies.remove(TokenKey)
}
