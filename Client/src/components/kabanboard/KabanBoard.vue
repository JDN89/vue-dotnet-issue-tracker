<script setup lang="ts">

import { useProjectStore } from '~/stores/projects'
const store = useProjectStore()
const addIssue = () => {
  store.ShowNewIssue = true
}
</script>

<template>
  <div>
    <div id="Kaban-Board" class="flex gap-3 flex-row justify-around flex-1">
      <div class="min-w-34 max-w-80">
        <div class="flex justify-center">
          <h1 class="text-3xl mb-5 pr-5">
            Open
          </h1>
          <i i-ant-design-plus-outlined class="mt-2.5" @click="addIssue" />
        </div>
        <OpenIssues />
      </div>
      <div class="min-w-24 max-w-80">
        <div class="flex justify-center">
          <h1 class="text-3xl mb-5 pr-5">
            In Progress
          </h1>
          <i i-ant-design-plus-outlined class="mt-2.5" @click="addIssue" />
        </div>
        <IssuesInProgress />
      </div>
      <div class="min-w-34 max-w-80">
        <div class="flex justify-center">
          <h1 class="text-3xl mb-5 pr-5">
            In Review
          </h1>
          <i i-ant-design-plus-outlined class="mt-2.5" @click="addIssue" />
        </div>
        <ReviewIssues />
      </div>
      <div class="min-w-34 max-w-80">
        <div class="flex justify-center">
          <h1 class="text-3xl mb-5 pr-5">
            Closed
          </h1>
          <i i-ant-design-plus-outlined class="mt-2.5" @click="addIssue" />
        </div>
        <ClosedIssues />
      </div>
    </div>
    <FocusedIssue v-if="store.getShowfocusedIssue" />
    <NewIssue v-if="store.getShowNewIssue" />
  </div>
</template>

<style scoped></style>
