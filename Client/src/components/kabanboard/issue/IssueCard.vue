<script setup lang="ts">
const props = defineProps<{ title: string; urgency: string; date: string; type: string }>()

const myUrgencyStyles = new Map<string, string>([['medium', 'border-1'], ['low', 'border-dotted dark:border-dotted'], ['high', 'border-2 dark:border-2 ']])

const urgencyStyle = computed(() => {
  return myUrgencyStyles.get(props.urgency)!
})
</script>

<template>
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
</template>
