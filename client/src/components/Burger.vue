<script setup>
import { Burger } from '@/models/Burger.js';


defineProps({
  b: { type: Burger, required: true }
})
</script>


<template>
  <div class="card">
    <div class="card-header">
      {{ b.name }}
    </div>
    <div class="card-body">
      <img :src="b.imgUrl" alt="">
      <div>$<span>{{ b.price }}</span></div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
}
</style>