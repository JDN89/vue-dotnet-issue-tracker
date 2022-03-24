import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import routes from 'virtual:generated-pages'
import { createPinia } from 'pinia'
import App from './App.vue'

import '@unocss/reset/tailwind.css'
import './styles/main.css'
import 'uno.css'
import 'uno:components.css'

const app = createApp(App)
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

router.beforeEach((to, from, next) => {
  if (to.meta?.requiresAuth && window.localStorage.getItem('token') && window.localStorage.getItem('username'))

    next()

  else if (to.meta?.requiresAuth) next('/account/login')

  else next()
})

app.use(router)
app.use(createPinia())
app.mount('#app')
