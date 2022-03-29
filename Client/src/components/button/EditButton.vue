<script setup lang="ts">

const editOptions = ['Rename', 'Delete']

const isHidden = ref(true)
</script>

<template>
  <button v-if="isHidden" class="float-right" i-bx-dots-vertical-rounded @click="isHidden=false" />
  <div v-else class="flex flex-col justify-end">
    <ul @click="isHidden=true">
      <li v-for="(option,index) in editOptions" :key="index" class=" min-w-10 max-w-21 btn m-1 float-right" @click="$emit('edit',option)">
        {{ option }}
      </li>
    </ul>
  </div>
</template>
