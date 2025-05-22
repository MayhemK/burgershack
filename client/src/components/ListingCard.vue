<script setup>
import { defineProps, defineEmits } from 'vue';
import { Food } from '@/models/Food.js';
import { logger } from '@/utils/Logger.js';

const props = defineProps({
  l: { type: Food, required: true }
})

const emit = defineEmits(['itemClicked']);

function handleClick() {
  emit('itemClicked', props.l);
  logger.log('click', props.l)
}
</script>


<template>
  <div class="card m-1" @click="handleClick" type="button">
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