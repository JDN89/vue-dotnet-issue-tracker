<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
import type { FocusedIssue } from '~/types/interfaces'

const store = useProjectStore()
const newIssue: FocusedIssue = reactive(Object.assign({}, store.getFocussedIssue!))

const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])

const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(newIssue.urgency)!
})
const urgencyOptions = ['LOW', 'MEDIUM', 'HIGH']
const urgencyOptionsHidden = ref(true)
const showUrgencyOptions = () => {
  urgencyOptionsHidden.value = false
}
const updateUrgency = (urgency: string) => {
  store.FocusedIssue!.urgency = urgency
  urgencyOptionsHidden.value = true

  console.log(store.getFocussedIssue)
}

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
      if (store.getFocussedIssue) await store.deleteIssue(store.getFocussedIssue)
      store.ShowFocusedIssue = false
      break
  }
}
const uploadEdditedIssue = () => {
  editFieldsHidden.value = true
  store.ShowFocusedIssue = false
  console.log('send new Issue options to the store')
  console.log(newIssue)
}
</script>

<template>
  <div
    class="flex bg-gray-700 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center"
  >
    <div
      class=" min-h-44 min-w-lg w-auto max-h-auto w-full m-1 p-2 sm:max-w-70 content-center sm:mx-auto mx-auto"
    >
      <div class="square-border bg-light-500" :class="`${urgencyStyle}`">
        <div
          class=" flex justify-between m-3"
        >
          <p class="font-semibold font-sans tracking-wide text-sm">
            {{ store.getFocussedIssue!.title }}
          </p>
          <div v-if="urgencyOptionsHidden" class="flex justify-around">
            <Urgency urgency="store.getFocussedIssue!.urgency">
              {{ store.getFocussedIssue!.urgency.toUpperCase() }}
            </Urgency>
            <button v-if="!editFieldsHidden" i-bx-dots-vertical-rounded @click="showUrgencyOptions" />
          </div>
          <div v-else>
            <ul class="flex flex-col">
              <li v-for="(urgency ,index) in urgencyOptions" :key="index" class=" min-w-10 max-w-21 btn m-1 float-right" @click="updateUrgency(urgency)">
                {{ urgency }}
              </li>
            </ul>
          </div>
          <EditButton v-if="!editButtonHidden" class="relative" @edit="editting" />
          <i v-else i-carbon-fetch-upload-cloud @click="uploadEdditedIssue" />
        </div>
        <div class="flex m-1 justify-between items-center">
          <span class="ml-2 text-sm text-gray-600 dark:text-gray-300">{{ store.getFocussedIssue!.date }}</span>
          <Badge :type="store.getFocussedIssue!.type" class="pl-7">
            {{ newIssue.type }}
          </Badge>
          <span />
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
