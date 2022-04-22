<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
import type { FocusedIssue } from '~/types/interfaces'

const store = useProjectStore()
const props = defineProps<{ id: string; title: string; urgency: string; date: string; type: string; description: string; progress: string }>()
const focusedIssue: FocusedIssue|null = reactive({
  id: props.id,
  title: props.title,
  progress: props.progress,
  description: props.description,
  date: props.date,
  type: props.type,
  urgency: props.urgency,
})

const storeFocusedIssueInfo = async(issue: FocusedIssue) => {
  store.FocusedIssue = focusedIssue
  console.log(focusedIssue)

  store.ShowFocusedIssue = true
}
const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])

const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(props.urgency)!
})
</script>

<template>
  <div @click="storeFocusedIssueInfo(focusedIssue!)">
    <div class="square-border" :class="`${urgencyStyle}`">
      <div
        class=" flex justify-between m-3"
      >
        <p class="font-semibold font-sans tracking-wide text-sm">
          {{ props.title }}
        </p>
        <Urgency :urgency="props.urgency">
          {{ props.urgency.toUpperCase() }}
        </Urgency>
      </div>
      <div class="flex m-2 justify-between items-center">
        <span class="text-sm text-gray-600 dark:text-gray-300">{{ props.date }}</span>
        <Badge :type="props.type">
          {{ props.type }}
        </Badge>
      </div>
    </div>
  </div>
</template>
