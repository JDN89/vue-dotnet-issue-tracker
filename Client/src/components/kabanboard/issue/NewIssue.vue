<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
import type { NewIssue } from '~/types/interfaces'

const store = useProjectStore()

const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])

const newIssue: NewIssue = reactive({
  projectId: store.getLoadedProjectId!,
  title: '',
  type: 'QA',
  urgency: 'LOW',
  description: '',

})

const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(newIssue!.urgency)!
})
const urgencyOptions = ['LOW', 'MEDIUM', 'HIGH']
const urgencyOptionsHidden = ref(true)
const showUrgencyOptions = () => {
  urgencyOptionsHidden.value = false
}
const updateUrgency = (urgency: string) => {
  newIssue.urgency = urgency
  urgencyOptionsHidden.value = true
}

const IssueTypes = ['Design', 'Backend', 'Feature Request', 'QA']
const issueTypesHidden = ref(true)
const showFeatureTypes = () => {
  issueTypesHidden.value = false
}
const updateType = (type: string) => {
  newIssue.type = type
  issueTypesHidden.value = true
}
const addNewIssue = async () => {
  if (newIssue.title.length === 0 || newIssue.description.length === 0) {
    return alert('title and or description or missing!')
  }

  else {
    store.ShowNewIssue = false
    return await store.addIssue(newIssue)
  }
}
</script>

<template>
  <div class="flex bg-gray-700 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center">
    <div class=" min-w-lg h-auto m-1 p-2 sm:max-w-70 content-center sm:mx-auto mx-auto">
      <div class="square-border flex-col  h-auto w-auto bg-light-500" :class="`${urgencyStyle}`">
        <div class="flex h-auto justify-between m-3">
          <i i-carbon-fetch-upload-cloud class="cursor-pointer" @click="addNewIssue" />
          <div v-if="urgencyOptionsHidden" class="flex cursor-pointer justify-around">
            <Urgency urgency="newIssue.urgency" @click="showUrgencyOptions">
              {{ newIssue.urgency.toUpperCase() }}
            </Urgency>
          </div>
          <div v-else>
            <ul class="flex flex-col ">
              <li v-for="(urgency, index) in urgencyOptions" :key="index" class="min-w-10 max-w-21 btn m-1 "
                @click="updateUrgency(urgency)">
                {{ urgency }}
              </li>
            </ul>
          </div>
          <div v-if="issueTypesHidden" class="flex justify-start max-w-15 cursor-pointer ">
            <Badge :type="newIssue.type" class="pl-3" @click="showFeatureTypes">
              {{ newIssue.type }}
            </Badge>
          </div>
          <div v-else>
            <ul class="flex flex-col justify-end">
              <li v-for="(type, index) in IssueTypes" :key="index" class="min-w-10 max-w-39 btn m-1 float-right"
                @click="updateType(type)">
                {{ type }}
              </li>
            </ul>
          </div>
          <i i-carbon-close class="cursor-pointer" @click="store.ShowNewIssue = false" />
        </div>
        <div class="flex justify-start w-auto">
          <input v-model="newIssue.title" type="text" placeholder="Add a Title"
            class="bg-transparent focus:outline-none">
        </div>

        <div class=" flex w-auto ">
          <textarea v-model="newIssue.description" placeholder="Add a description (drag corner to expand texterea)"
            class="text-base focus:outline-none resize-y flex-grow bg-transparent" />
        </div>
      </div>
    </div>
  </div>
</template>
