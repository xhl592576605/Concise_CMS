import defaultSettings from '@/settings'

const title = defaultSettings.title || 'Concise_CMS'

export default function getPageTitle(pageTitle) {
  if (pageTitle) {
    return `${pageTitle} - ${title}`
  }
  return `${title}`
}
