<script setup lang="ts">
import { useProjectStore } from '~/stores/projects'
import type { AddProject } from '~/types/interfaces'

const store = useProjectStore()

const isHidden = ref(true)
const newProject: AddProject = reactive({
  title: null,
})

const projectTitle = ref<string|null>(null)
const SendProjectToStore = async() => {
  if (newProject.title !== null) {
    try { await store.addProject(newProject) }
    catch (error) { console.error(error) }
    finally {
      projectTitle.value = null
      isHidden.value = true
    }
  }

  else { alert('please add a project title') }
}

</script>

<template>
  <div id="sidebar" class="min-w-24 max-w-50 flex-1 ">
    <h1 text-3xl py-3>
      My Projects
    </h1>

    <ul>
      <li

        v-for="project in store.getProjects"
        :key="project.projectId"
        class="square-border my-2 "
        @click="store.fetchProjectRelatedIssues(project.projectId)"
      >
        <Project :id="project.projectId" :title="project.title" />
      </li>
    </ul>
    <button
      v-if="isHidden"
      i-carbon-add-alt
      class="btn mb-2" @click="isHidden=false"
    />
    <div v-else>
      <input
        v-model="newProject.title" class="max-w-44 bg-transparent square-border" type="text"
        @keyup.enter="SendProjectToStore"
      >
    </div>
  </div>
</template>
