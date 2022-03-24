<script setup lang="ts">
import draggable from 'vuedraggable'

import { useProjectStore } from '~/stores/projects'

const store = useProjectStore()
/* watch(() => store.OpenIssues, (newValue) => {
  console.log(newValue)

},

) */
/*
watcher store in onBeforeUpdate because:
the watch functions were loaded before the pinia store were installed
so the functions returned (watch: null) AND SEIZED working!!
so now on updates we watch the stores for changes
EDIT: triggers function and updates the correct DB?
but edit doesn't need to trigger and update event of the whole table, neither does DB
HOW TO SOLVE THIS??

on update, if @change vue draggable (move.index) == ture => watch the projectStore for changes
and update if necesarry!
if @change (move.index) == true
*/
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
    <template #item="{ element }">
      <div class="m-4 ">
        <IssueCard :title="element.title" :urgency="element.urgency" :date="element.date" :type="element.type" />
      </div>
    </template>
  </draggable>
</template>
