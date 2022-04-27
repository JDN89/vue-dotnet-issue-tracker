import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import { router } from './composables/router'
import '@unocss/reset/tailwind.css'
import './styles/main.css'
import 'uno.css'
import 'uno:components.css'

const app = createApp(App)

app.use(router)
app.use(createPinia())
app.mount('#app')
