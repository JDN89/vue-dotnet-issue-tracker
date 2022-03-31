<script setup lang="ts">
const props = defineProps<{ title: string; urgency: string; date: string; type: string ;description: string }>()

const myUrgencyStyles = new Map<string, string>([['Medium', 'border-1'], ['Low', 'border-dotted dark:border-dotted'], ['High', 'border-2 dark:border-2 ']])

const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(props.urgency)!
})
</script>

<template>
  <div
    class="flex bg-gray-400 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center"
  >
    :w

    <div
      class="msg min-h-44 max-h-lg w-full m-1 p-2 sm:max-w-70 content-center sm:mx-auto mx-auto"
    >
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
        <div class="flex mx-2 mx-auto justify-between items-center">
          <p>{{ props.description }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
