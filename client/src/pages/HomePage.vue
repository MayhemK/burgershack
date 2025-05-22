<script setup>
import { AppState } from '@/AppState.js';
import Burger from '@/components/Burger.vue';
import Dessert from '@/components/Dessert.vue';
import ListingCard from '@/components/ListingCard.vue';
import Salad from '@/components/Salad.vue';
import { burgersService } from '@/services/BurgersService.js';
import { dessertsService } from '@/services/DessertsService.js';
import { saladsService } from '@/services/SaladsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const B = computed(() => AppState.burgers)
const S = computed(() => AppState.salads)
const D = computed(() => AppState.desserts)
const account = computed(() => AppState.account)

onMounted(() => {
  GetAll()
})

async function GetAll() {
  try {
    await burgersService.GetAll()
    await saladsService.GetAll()
    await dessertsService.GetAll()
  }
  catch (error) {
    Pop.error(error);
  }
}



</script>

<template>
  <section class="container">
    <div class="row">
      <div class="col-12 text-center m-3 fs-2 fw-bold">
        Welcome to BurgerShack!
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-9 text-center m-3 border">
        Make your selections here!
      </div>
    </div>
    <div class="col-12">
      <div class="row">
        <div class="col-12">
          <div class="text-center bg-light fs-3 p-2 rounded-2 my-4">
            Burgers!!
          </div>
          <div class="row">
            <div v-for="b in B" :key="b.id" class="col-3">
              <ListingCard :l="b" />
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <div class="text-center bg-light fs-3 p-2 rounded-2 my-4">
            Salads!!
          </div>
          <div class="row">
            <div v-for="s in S" :key="s.id" class="col-3">
              <ListingCard :l="s" />
            </div>
          </div>
        </div>
      </div>
      <div class="row mb-5">
        <div class="col-12">
          <div class="text-center bg-light fs-3 p-2 rounded-2 my-4">
            Desserts!!
          </div>
          <div class="row">
            <div v-for="d in D" :key="d.id" class="col-3">
              <ListingCard :l="d" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss"></style>
