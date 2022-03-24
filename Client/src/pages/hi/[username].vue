
<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
const props = defineProps<{ username: string }>()

const store = useProjectStore()

onBeforeMount(async() => {
  // onbefore mount load the first project in the array!! fetch project[0].id
  await store.fetchProjects()
  if (store.getProjects) {
    const firstProject = store.getProjects[0].projectId
    await store.fetchOpenIssues(firstProject)
    await store.fetchAllReviewIssues(firstProject)
    await store.fetchIssuesInProgress(firstProject)
    await store.fetchClosedIssues(firstProject)
  }
})
</script>

<template>
  <HeaderUser />
  <h1 text-2xl pb-3>
    Hi, {{ props.username.toUpperCase() }}
  </h1>

  <div id="container" class="flex flex-row justify-center py-10">
    <div id="main" class="order-2">
      <KabanBoard class="m-7 p-5 h-auto bg-light-300 dark:bg-dark-500 rounded-border  w-auto mx-auto flex-row" />
    </div>
    <div id="sideBar" class="order-1 ">
      <SideBar class="h-auto bg-light-300 dark:bg-dark-500 rounded-border border-r p-5 m-7" />
    </div>
  </div>
</template>

<route lang="yaml">
meta: {requiresAuth: true}
</route>
