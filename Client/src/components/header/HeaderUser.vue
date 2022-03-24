<script setup lang="ts">
import { useRouter } from 'vue-router'
import { isDark, toggleDark } from '../../composables'
import { useUserStore } from '~/stores/users'

const store = useUserStore()
const router = useRouter()
const logout = () => {
  store.logout()
  router.push('/')
}
</script>

<template>
  <div class="mx-auto">
    <nav text-xl mt-6 inline-flex gap-2>
      <router-link class="icon-btn mx-2" to="account/login" title="logout" @click="logout">
        <div class="i-carbon-logout" />
      </router-link>

      <div class="icon-btn mx-2" />
      <a
        class="icon-btn mx-2"
        i-carbon-logo-github
        rel="noreferrer"
        href="https://github.com/JDN89/issue-tracker"
        target="_blank"
        title="GitHub"
      />

      <button class="icon-btn mx-2 !outline-none" @click="toggleDark()">
        <div v-if="isDark" i-carbon-moon />
        <div v-else i-carbon-sun />
      </button>
    </nav>
  </div>
</template>
