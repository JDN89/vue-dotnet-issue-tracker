<script setup lang="ts">
import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()

const fetchProject = async(id: string) => {
  return null
}
const isHidden = ref(true)
const showAddProject = () => {
  isHidden.value = false
}
const projectTitle = ref<string|null>(null)
const SendProjectToStore = () => {
  if (projectTitle.value !== null) {
    store.addProject(projectTitle.value)
    projectTitle.value = null
    isHidden.value = true
  }
  else { alert('please add a project title') }
}

</script>

<template>
  <div id="sidebar" class="min-w-24 max-w-50 flex-1">
    <h1 text-3xl py-3>
      My Projects
    </h1>
    <ul>
      <li
        v-for="project in store.getProjects"
        :key="project.projectId"
        class="square-border my-2"
        @click="fetchProject(project.projectId)"
      >
        {{ project.title }}
      </li>
    </ul>
    <button
      v-if="isHidden"
      i-carbon-add-alt class="icon-:w
    btn mb-2" @click="showAddProject"
    />
    <div v-else>
      <input
        v-model="projectTitle" class="max-w-44 bg-transparent square-border" type="text"
        @keyup.enter="SendProjectToStore"
      >
    </div>
  </div>
</template>
