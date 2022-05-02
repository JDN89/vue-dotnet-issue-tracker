import { createRouter, createWebHistory } from 'vue-router'
import routes from 'virtual:generated-pages'

export const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

// place route gaurd in main.ts or router.ts (if you ise file based routing plugin from vue)
// answer in github vitesse discussions on question :
// Q: How to configure beforeEnter in Per-Route Guards #290
// Answer : Because it's difficult to serialize the function then pass it to frontend,
// I suggest you modify the routes directly from ~pages import in main.ts.
router.beforeEach(async (to, from, next) => {
  if (to.meta?.requiresAuth && window.localStorage.getItem('token') && window.localStorage.getItem('username'))

    next()

  else if (to.meta?.requiresAuth) next('/account/login')

  else next()
})
// create seperate logout function
// I couldn't find a way to import router into pinia store or axios interceptors
// to logout and push to login upon 401 status
// so created a special logout function for this scenario that I can import where needed
export const logout = async () => {

  window.localStorage.removeItem('token')
  window.localStorage.removeItem('username')
  await router.push('/account/login')
}
