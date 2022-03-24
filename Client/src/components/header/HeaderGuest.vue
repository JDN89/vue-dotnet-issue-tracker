<script setup lang="ts">
import { isDark, toggleDark } from '../../composables'
</script>

<template>
  <div class="mx-auto">
    <nav text-xl mt-6 inline-flex gap-2>
      <router-link class="icon-btn mx-2" to="/" title="Home">
        <div class="i-carbon-campsite" />
      </router-link>

      <router-link class="icon-btn mx-2" to="/account/login" title="Login">
        <div class="i-carbon-login" />
      </router-link>

      <router-link
        class="icon-btn mx-2"
        to="/account/register"
        title="Register"
      >
        <div class="i-carbon-group-account" />
      </router-link>
      <div class="icon-btn mx-2" />
      <div class="icon-btn mx-2" />
      <a
        class="icon-btn mx-2"
        i-carbon-logo-github
        rel="noreferrer"
        href="https://github.com/JDN89/issue-tracker"
        target="_blank"
        title="GitHub"
      />

      <button class="icon-btn mx-2 !outline-none" @click="toggleDark()">
        <div v-if="isDark" i-carbon-moon />
        <div v-else i-carbon-sun />
      </button>
    </nav>
  </div>
</template>
