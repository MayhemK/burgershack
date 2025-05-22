<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

const orderTotal = computed(() => {
  let total = 0;
  for (const item of AppState.clickedItems) {
    total += item.price * item.quantity;
  }
  return total;
});

const isOrderEmpty = computed(() => AppState.clickedItems.length === 0);
</script>

<template>
  <section class="card shadow-lg bg-white rounded-lg">
    <div class="card-header bg-primary text-white text-2xl font-bold p-4 rounded-t-lg">
      Your Order:
    </div>
    <div class="card-body p-4">
      <ul class="list-none p-0 mb-4 space-y-2" id="order-list">
        <li v-if="isOrderEmpty" class="text-gray-500 italic text-center py-4">Your order is empty. Click items to add
          them!</li>
        <li v-for="item in AppState.clickedItems" :key="item.name"
          class="flex justify-between items-center text-lg border-b pb-2 last:border-b-0 last:pb-0">
          <span class="font-semibold">{{ item.name }}</span>
          <span class="text-gray-600">Qty: {{ item.quantity }}</span>
          <span class="font-bold text-green-600">${{ (item.price * item.quantity).toFixed(2) }}</span>
        </li>
      </ul>
      <hr class="my-4 border-gray-300" v-if="!isOrderEmpty">
      <div v-if="!isOrderEmpty" class="text-right text-3xl font-extrabold text-green-700">
        Total: ${{ orderTotal.toFixed(2) }}
      </div>
    </div>
  </section>
</template>

<style lang="scss" scoped>
.card {
  border: 1px solid #e0e0e0;
}

.card-header {
  background-color: #007bff;
}
</style>