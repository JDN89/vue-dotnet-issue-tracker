<script setup lang="ts">
import draggable from 'vuedraggable'

import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()

onBeforeUpdate(async() => {
  watch(store.Closed!, async(value) => {
    await store.updateAllClosedIssues(value)
  })
})
</script>

<template>
  <draggable

    :list="store.getClosed!"
    group="Issues"
    item-key="id"
    ghost-class="ghost"
    animation=" 400"
  >
    <template #item="{ element }">
      <div class="m-4 ">
        <IssueCard :id="element.id" :title="element.title" :urgency="element.urgency" :date="element.localDate" :type="element.type" :description="element.description" :progress="'Closed'" />
      </div>
    </template>
  </draggable>
</template>
