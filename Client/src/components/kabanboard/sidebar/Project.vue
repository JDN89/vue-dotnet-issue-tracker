<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()
const props = defineProps({ id: String, title: String })
const projectInputIsHidden = ref(true)

const title = ref<string>(props.title!)
const updateProject = (id: string, title: string) => {
  console.log(id)
  console.log(title)
  projectInputIsHidden.value = true
}

const editting = async(item: string) => {
  switch (item) {
    case 'Rename':
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
