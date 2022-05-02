<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
import type { UpdateProject } from '~/types/interfaces'

const store = useProjectStore()
const props = defineProps({ id: String, title: String })
const projectInputIsHidden = ref(true)
const updatedProject: UpdateProject = reactive({
  projectId: null,
  title: null,

})

const title = ref<string>(props.title!)
const updateProject = async(id: string, title: string) => {
  updatedProject.projectId = id
  updatedProject.title = title
  await store.updateProject(updatedProject)

  projectInputIsHidden.value = true
}

const editting = async(item: string) => {
  switch (item) {
    case 'Edit':
      console.log('edit logic')
      projectInputIsHidden.value = false
      break
    case 'Delete':
      await store.deleteProject()
      break
  }
}

</script>

<template>
  <div>
    <div v-if="projectInputIsHidden" class="relative">
      {{ title }}
      <EditButton class="relative" @edit="editting" />
    </div>
    <input v-else v-model="title" class="bg-transparent overflow-hidden" type="text" @keyup.enter="updateProject(props.id!,title)">
  </div>
</template>
