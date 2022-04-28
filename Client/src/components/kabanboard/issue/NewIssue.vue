<script setup lang="ts">

import { useField, useForm } from 'vee-validate'
import * as yup from 'yup'
import { useProjectStore } from '~/stores/projects'
import type { NewIssue } from '~/types/interfaces'

const store = useProjectStore()



const newIssue: NewIssue = reactive({
  projectId: store.getLoadedProjectId!,
  title: '',
  type: 'QA',
  urgency: 'LOW',
  description: '',

})
// ============ URGENCY =======================
// --style--
const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])
const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(newIssue!.urgency)!
})
// -- options--
const urgencyOptions = ['LOW', 'MEDIUM', 'HIGH']
const urgencyOptionsHidden = ref(true)
const showUrgencyOptions = () => {
  urgencyOptionsHidden.value = false
}
//--update logic--
const updateUrgency = (urgency: string) => {
  newIssue.urgency = urgency
  urgencyOptionsHidden.value = true
}
// ==================== ISSUE TYPE ===================
const IssueTypes = ['Design', 'Backend', 'Feature Request', 'QA']
const issueTypesHidden = ref(true)
const showFeatureTypes = () => {
  issueTypesHidden.value = false
}

const updateType = (type: string) => {
  newIssue.type = type
  issueTypesHidden.value = true
}

// ====== INPUT & TEXTEREA + validation
// Define a validation schema
const schema = yup.object({
  title: yup.string().required().min(4),
  description: yup.string().required().min(8),
})

// Create a form context with the validation schema
useForm({
  validationSchema: schema,
})

// No need to define rules for fields
const { value: title, errorMessage: titleError } = useField<string>('title')

const { value: description, errorMessage: descriptionError } = useField<string>('description')

const addNewIssue = async () => {
  newIssue.title = title.value
  newIssue.description = description.value
  store.ShowNewIssue = false
  return await store.addIssue(newIssue)
}
</script>

<template>
  <div class="flex bg-gray-700 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center">
    <div class=" min-w-lg h-auto m-1 p-2 sm:max-w-70 content-center sm:mx-auto mx-auto">
      <div class="square-border flex-col bg-light-500 dark:bg-dark-500 h-auto w-auto " :class="`${urgencyStyle}`">
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
          <input v-model="title" name="title" type="text" placeholder="Add a Title"
            class="bg-transparent focus:outline-none">
          <span>{{ titleError }}</span>
        </div>

        <div class=" flex w-auto ">
          <textarea name="description" v-model="description"
            placeholder="Add a description (drag corner to expand texterea)"
            class="text-base focus:outline-none resize-y flex-grow bg-transparent" />
          <span>{{ descriptionError }}</span>
        </div>
      </div>
    </div>
  </div>
</template>
