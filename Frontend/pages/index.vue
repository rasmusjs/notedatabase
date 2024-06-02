<script setup lang="ts">

import Navigation from "~/layouts/navigation.vue";
</script>

<template>
  <!--
    Taken form https://vuetifyjs.com/en/wireframes/constrained/
  -->
  <v-app id="inspire">
    <Navigation></Navigation>

    <v-main class="bg-grey-lighten-3">
      <v-container>
        <h1>Welcome to note database for storing orchestral music</h1>
      </v-container>
    </v-main>
  </v-app>
</template>
