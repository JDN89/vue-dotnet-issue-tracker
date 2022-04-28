
<script setup lang="ts">
import { useAlertStore } from "~/stores/alertStore";

const alertStore = useAlertStore();
const closeAlert = () => {
    console.log('i am clicked')
    alertStore.showAlert = false
}
</script>

<template>
    <div
        class="flex flex-grow flex-row w-auto bg-gray-800 bg-opacity-50 fixed left-0 right-0 bottom-0 top-0 items-center absolute">
        <div
            class="square-border bg-red-300 text-red-900 dark:bg-red-600 dark:text-light-300 w-auto justify-between prose content-center min-h-auto m-1 p-2 mx-auto">
            <h3 class="relative ">Alert: {{ alertStore.getAlertMessage }}</h3>

            <button i-carbon-close class="justify-end cursor-pointer mr-1" @click="closeAlert">
            </button>
        </div>


    </div>
</template>

<route lang="yaml">
meta:
  layout: dashboard
</route>
