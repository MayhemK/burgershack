<script setup>
import { Food } from '@/models/Food.js';

defineProps({
  l: { type: Food, required: true }
})
</script>


<template>
  <div class="card m-1">
    <div class="card-header">
      {{ l.name }}
    </div>
    <div class="card-body">
      <img :src="l.imgUrl" alt="">
      <div>$<span>{{ l.price }}</span></div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
img {
  max-width: 100%;
}
</style>