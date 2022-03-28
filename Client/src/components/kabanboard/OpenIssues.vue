<script setup lang="ts">
import draggable from 'vuedraggable'

import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()

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
        <IssueCard :title="element.title" :urgency="element.urgency" :date="element.localDate" :type="element.type" />
      </div>
    </template>
  </draggable>
</template>
