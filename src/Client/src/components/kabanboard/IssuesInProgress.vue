<script setup lang="ts">
import draggable from 'vuedraggable'

import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()
onBeforeUpdate(async() => {
  watch(store.InProgress!, async(value) => {
    await store.updateAllIssuesInProgress(value)
  })
})
</script>

<template>
  <draggable

    :list="store.getIssuesInProgress!"
    group="Issues"
    item-key="id"
    ghost-class="ghost"
    animation=" 400"
  >
    <template #item="{ element }">
      <div class="m-4 ">
        <IssueCard :id="element.id" :title="element.title" :urgency="element.urgency" :date="element.localDate" :type="element.type" :description="element.description" :progress="'InProgress'" />
      </div>
    </template>
  </draggable>
</template>
