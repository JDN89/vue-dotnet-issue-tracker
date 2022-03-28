<script setup lang="ts">

const isHidden = ref(true)
const editArr: string [] = ['Edit', 'Delete']
</script>

<template>
  <button v-if="isHidden" i-bx-dots-vertical-rounded />
  <ul v-else>
    <li v-for="item in editArr" :key="item">
      {{ item }}
    </li>
  </ul>
</template>
