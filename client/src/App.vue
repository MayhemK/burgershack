<script setup>
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main class="main-bg">
    <RouterView />
  </main>
  <footer class=" text-center">
    Made with <i class="mdi mdi-heart text-pink"></i> by Ivan
  </footer>
</template>

<style lang="scss">
.main-bg {
  background-image: url(https://texturelabs.org/wp-content/uploads/Texturelabs_Wood_160S.jpg);
  max-width: 100%;
  object-fit: cover;
}
</style>
