<script setup lang="ts">
import draggable from 'vuedraggable'

import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()
const focusedIssueIsHidden = ref<boolean>(false)
onBeforeUpdate(async() => {
  watch(store.OpenIssues!, async(value) => {
    await store.updateAllOpenIssues(value)
  })
})

</script>

<template>
  <draggable

    :list="store.getOpenIssues!"
    group="Issues"
    item-key="id"
    ghost-class="ghost"
    animation=" 400"
  >
    <template #item="{ element } ">
      <div class="m-4 ">
        <IssueCard :title="element.title" :urgency="element.urgency" :date="element.localDate" :type="element.type" :description="element.description" />
        <FocusedIssue v-if="focusedIssueIsHidden" :title="element.title" :urgency="element.urgency" :date="element.localDate" :type="element.type" :description="element.description" />
      </div>
    </template>
  </draggable>
</template>
