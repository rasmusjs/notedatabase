<script setup lang="ts">
import {useTheme} from 'vuetify'

// Computed property to dynamically generate navigation pages
const pages = computed<Page[]>(() => [
  {to: '/', title: 'Home', icon: 'mdi mdi-home'},
  {to: '/view', title: 'View', icon: 'mdi mdi-database'},
  {to: '/create', title: 'Create', icon: 'mdi mdi-creation'},
  {to: '/login', title: 'Log In', icon: 'mdi mdi-login'},
  {to: '/register', title: 'Register', icon: 'mdi mdi-account-plus'}
]);

const router = useRouter();
const route = useRoute();

const changeTitle = (title: string) => {
  useHead({title: `Sheetdatabase -  ${title}`});
};


// Change title based on the page we are on
watch(route, () => {
  const currentPage = pages.value.find(page => page.to === route.path);
  if (currentPage) {
    changeTitle(currentPage.title);
  }
}, {immediate: true});


const theme = useTheme()

function toggleTheme() {
  theme.global.name.value = theme.global.current.value.dark ? 'light' : 'dark'
}
</script>

<template>
  <v-app-bar flat>
    <v-container class="mx-auto d-flex align-center justify-center">
      <!--
              <v-avatar
                  class="me-4 "
                  color="grey-darken-1"
                  size="32"
              ></v-avatar>
      -->
      <v-btn
          v-for="(page, index) in pages"
          :key="index"
          :to="page.to"
          class="nuxt-link-inline"
          :class="{ 'margin-right-2px': index !== pages.length - 1 }"
      >
        {{ page.title }}

        <template v-slot:prepend>
          <v-icon :icon="page.icon" size="small" class="ml-1"></v-icon>
        </template>
      </v-btn>
      <v-btn
          @click="toggleTheme"
      >
        <v-icon size="small"
                class="ml-md-auto" icon="mdi-theme-light-dark"/>
      </v-btn>
      <v-spacer></v-spacer>

      <v-responsive max-width="160">
        <v-text-field
            density="compact"
            label="Search"
            rounded="lg"
            variant="solo-filled"
            flat
            hide-details
            single-line
        ></v-text-field>
      </v-responsive>
    </v-container>
  </v-app-bar>
</template>