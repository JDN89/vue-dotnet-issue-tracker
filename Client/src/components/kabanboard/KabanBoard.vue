<script setup lang="ts">

</script>

<template>
  <div id="Kaban-Board" class="flex gap-3 flex-row justify-around flex-1 ">
    <div class="min-w-34 max-w-80 ">
      <h1 text-3xl mb-5>
        openIssue
      </h1>
      <OpenIssues />
    </div>
    <div class="min-w-24 max-w-80 ">
      <h1 text-3xl mb-5>
        In Progress
      </h1>
      <IssuesInProgress />
    </div>
    <div class="min-w-34 max-w-80 ">
      <h1 text-3xl mb-5>
        Review
      </h1>
      <ReviewIssues />
    </div>
    <div class="min-w-34 max-w-80 ">
      <h1 text-3xl mb-5>
        Closed
      </h1>
      <ClosedIssues />
    </div>
  </div>
</template>

<style scoped></style>
