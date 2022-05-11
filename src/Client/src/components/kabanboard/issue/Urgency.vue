<script setup lang="ts">
const props = defineProps<{ urgency: string }>()

const myUrgencyColorMap = new Map<string, string>([['LOW', 'font-normal text-xs'], ['MEDIUM', 'font-semibold'], ['HIGH', 'font-bold text-lg']])

const urgencyColor = computed(() => {
    return myUrgencyColorMap.get(props.urgency)!
})

</script>
<template>
    <div class=" px-3 h-6 rounded-full flex items-center " :class="`${urgencyColor}`">
        <span class="w-2 h-2 rounded-full mr-1" />
        <span>
            <slot />
        </span>
    </div>
</template>
