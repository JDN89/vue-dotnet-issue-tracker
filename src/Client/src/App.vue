<script setup lang="ts">
import { useUserStore } from './stores/users'

onBeforeMount(async() => {
  const userStore = useUserStore()
  const token = window.localStorage.getItem('token')
  if (token)
    userStore.token = token
})

</script>

<template>
  <main font-sans p="x-4 y-10" text="center gray-700 dark:gray-200">
    <router-view />
  </main>
</template>
