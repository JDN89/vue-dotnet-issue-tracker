<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
import type { FocusedIssue } from '~/types/interfaces'

const store = useProjectStore()
const focusedIssue: FocusedIssue = store.getFocussedIssue!
const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])

const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(focusedIssue.urgency)!
})
const editButtonHidden = ref<boolean>(false)
const editFieldsHidden = ref<boolean> (true)
const editting = async(item: string) => {
  switch (item) {
    case 'Edit':
      console.log('edit logic')
      editFieldsHidden.value = false
      editButtonHidden.value = true

      break
    case 'Delete':
      console.log('delete logic')
      if (store.getFocussedIssue) return await store.deleteIssue(store.getFocussedIssue)
      break
  }
}
const uploadEdditedIssue = () => {
  editFieldsHidden.value = true
  store.ShowFocusedIssue = false
  console.log('send new Issue options to the store')
}
</script>

<template>
  <div
    class="flex bg-gray-700 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center"
  >
    <div
      class=" min-h-44 min-w-auto max-h-auto w-full m-1 p-2 sm:max-w-70 content-center sm:mx-auto mx-auto"
    >
      <div class="square-border bg-light-500" :class="`${urgencyStyle}`">
        <div
          class=" flex justify-between m-3"
        >
          <p class="font-semibold font-sans tracking-wide text-sm">
            {{ store.getFocussedIssue!.title }}
          </p>
          <Urgency :urgency="store.getFocussedIssue!.urgency">
            {{ store.getFocussedIssue!.urgency.toUpperCase() }}
          </Urgency>
          <EditButton v-if="!editButtonHidden" class="relative" @edit="editting" />
          <i v-else i-carbon-fetch-upload-cloud @click="uploadEdditedIssue" />
        </div>
        <div class="flex m-2 justify-between items-center">
          <span class="text-sm text-gray-600 dark:text-gray-300">{{ store.getFocussedIssue!.date }}</span>
          <Badge :type="store.getFocussedIssue!.type">
            {{ focusedIssue.type }}
          </Badge>
        </div>
        <div class="flex mx-auto justify-between items-center">
          <p v-if="editFieldsHidden" class="m-2 ">
            {{ store.getFocussedIssue!.description }}
          </p>
          <textarea v-else v-model="store.getFocussedIssue!.description" class="min-h-lg h-auto min-w-full overflow-auto" />
        </div>
      </div>
    </div>
  </div>
</template>
