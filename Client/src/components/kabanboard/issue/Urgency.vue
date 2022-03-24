<script setup lang="ts">
const props = defineProps<{ urgency: string } >()

const myUrgencyColorMap = new Map<string, string>([['low', 'font-normal text-xs'], ['medium', 'font-semibold text-xs'], ['high', 'font-bold text-l']])

const urgencyColor = computed(() => {
  return myUrgencyColorMap.get(props.urgency)!
})

</script>
<template>
  <div
    class=" px-3 h-6 rounded-full flex items-center "
    :class="`${urgencyColor}`"
  >
    <span class="w-2 h-2 rounded-full mr-1" />
    <span>
      <slot />
    </span>
  </div>
</template>
