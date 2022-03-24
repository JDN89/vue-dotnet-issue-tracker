<script setup lang="ts">
import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()

const fetchProject = async(id: string) => {
  // fetch project when ID !== current project  Id
  // store current project id in store
  return null
  // await store.fetchOpenIssues()
  // await store.fetchIssuesInProgress()
  // await store.fetchIssuesInProgress()
  // await store.fetchClosedIssues()
}
</script>

<template>
  <div id="sidebar" class="min-w-24 max-w-44 flex-1">
    <h1 text-3xl py-3>
      My Projects
    </h1>
    <ul>
      <li v-for="project in store.getProjects" :key="project.projectId" class="square-border my-2" @click="fetchProject(project.projectId)">
        {{ project.title }}
      </li>
    </ul>
    <button class="btn mb-2">
      add project
    </button>
  </div>
</template>
