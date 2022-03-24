<script setup lang="ts">
const props = defineProps<{ type: string } >()

const myTextMap = new Map<string, string>([['Design', 'text-purple-800'], ['Feature Request', 'text-teal-800'], ['Backend', 'text-blue-800'], ['QA', 'text-green-800'], ['default', 'text-teal-800']])

const textColor = computed(() => {
  return myTextMap.get(props.type)!
})
const myDarkTextMap = new Map<string, string>([['Design', 'dark:text-purple-100'], ['Feature Request', 'dark:text-teal-100'], ['Backend', 'dark:text-blue-100'], ['QA', 'dark:text-green-100'], ['default', 'dark:text-teal-100']])

const DarkTextColor = computed(() => {
  return myDarkTextMap.get(props.type)!
})

const myBgMap = new Map<string, string>([['Design', 'bg-purple-100'], ['Feature Request', 'bg-teal-100'], ['Backend', 'bg-blue-100'], ['QA', 'bg-green-100'], ['default', 'bg-teal-100']])

// const type = (props.type)

const BgColor = computed(() => {
  return myBgMap.get(props.type)!
})
const myDarkBgMap = new Map<string, string>([['Design', 'dark:bg-purple-800'], ['Feature Request', 'dark:bg-teal-800'], ['Backend', 'dark:bg-blue-800'], ['QA', 'dark:bg-green-800'], ['default', 'dark:bg-teal-800']])
const DarkBgColor = computed(() => {
  return myDarkBgMap.get(props.type)!
})

const MyDarkRoundedFullMap = new Map<string, string>([['Design', 'dark:bg-purple-100'], ['Feature Request', 'dark:bg-teal-100'], ['Backend', 'dark:bg-blue-100'], ['QA', 'dark:bg-green-100'], ['default', 'dark:bg-teal-100']])
const darkRoundedFullColor = computed(() => {
  return MyDarkRoundedFullMap.get(props.type)!
})

const MyRoundedFullMap = new Map<string, string>([['Design', 'bg-purple-800'], ['Feature Request', 'bg-teal-800'], ['Backend', 'bg-blue-800'], ['QA', 'bg-green-800'], ['default', 'bg-teal-800']])
const roundedFullColor = computed(() => {
  return MyRoundedFullMap.get(props.type)!
})

</script>
<template>
  <div
    class=" px-3 h-6 rounded-full text-xs font-semibold flex items-center "
    :class="`${BgColor} ${DarkBgColor} ${textColor} ${DarkTextColor}` "
  >
    <span class="w-2 h-2 rounded-full mr-1" :class="`${darkRoundedFullColor} ${roundedFullColor}`" />
    <span>
      <slot />
    </span>
  </div>
</template>
