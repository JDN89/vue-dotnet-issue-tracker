<script setup lang="ts">

const isHidden = ref(true)
const showHidden = () => {
  isHidden.value = false
}
/* const edit = (item: string) => {
  console.log(item)
} */

const editArr: string [] = ['Edit', 'Delete']
</script>

<template>
  <button v-if="isHidden" i-bx-dots-vertical-rounded @click="showHidden" />
  <ul v-else>
    <li v-for="item in editArr" :key="item" @click="$emit('edit',item)">
      {{ item }}
    </li>
  </ul>
</template>
