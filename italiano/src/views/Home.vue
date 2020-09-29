<template>
    <v-card 
        flat 
        class="mb-12"
    >
        <v-card-title 
            class="justify-center text--primary" 
            style="font-size: 65px"
        >Italiano!</v-card-title>
        <v-card-text 
            style="font-size: 25px"
        >We offer great italian food at great prices</v-card-text>
        <v-card-text 
            style="font-size: 20px"
        >Try our home delivery!
        </v-card-text>

        <!-- Food -->
        <h1 class="mt-12">Food</h1>
        <v-divider class="mt-5 mb-5"></v-divider>
        <!-- Food Search -->
        <v-row class="mb-10">
            <v-spacer class="hidden-xs-only"></v-spacer>
            <v-col>
                <v-text-field 
                    id="searchFood"
                    placeholder="Search by category (pizza, pasta...)"
                    type="text" 
                    label="Search"
                    width="10%"
                ></v-text-field>
                <v-btn 
                    dark 
                    @click="searchFoodByCategory"
                >Search</v-btn>
                <v-btn 
                    dark 
                    @click="resetFoodSearch"
                >Reset</v-btn>
            </v-col>
            <v-spacer class="hidden-xs-only"></v-spacer>
        </v-row>
        <!-- End Food Search -->

        <FoodList :foodmenu="foodmenu" />
        <!-- End food -->
        
        <!-- Drinks -->
        <h1 class="mt-12">Drinks</h1>
        <v-divider class="mt-5 mb-5"></v-divider>
        <!-- Drinks Search -->
        <v-row class="mb-10">
            <v-spacer class="hidden-xs-only"></v-spacer>
            <v-col>
                <v-text-field 
                    id="searchDrinks"
                    placeholder="Search by category (soda, water, beer...)"
                    type="text" 
                    label="Search"
                    width="10%"
                ></v-text-field>
                <v-btn 
                    dark
                    @click="searchDrinksByCategory"
                >Search</v-btn>
                <v-btn 
                    dark
                    @click="resetDrinksSearch"
                >Reset</v-btn>
            </v-col>
            <v-spacer class="hidden-xs-only"></v-spacer>
        </v-row>
        <!-- End Drinks Search -->
        <DrinkList :drinkmenu="drinkmenu" />
        <!-- End Drinks -->

        <!-- Dessert -->
        <h1 class="mt-12">Desserts</h1>
        <v-divider class="mt-5 mb-5"></v-divider>
        <!-- Dessert Search -->
        <v-row class="mb-10">
            <v-spacer class="hidden-xs-only"></v-spacer>
            <v-col>
                <v-text-field 
                    id="searchDessert"
                    placeholder="Search by category (cake, icecream...)"
                    type="text" 
                    label="Search"
                    width="10%"
                ></v-text-field>
                <v-btn 
                    dark
                    @click="searchDessertByCategory"
                >Search</v-btn>
                <v-btn 
                    dark
                    @click="resetDessertSearch"
                >Reset</v-btn>
            </v-col>
            <v-spacer class="hidden-xs-only"></v-spacer>
        </v-row>
        <!-- End Dessert Search -->
        <DessertList :dessertmenu="dessertmenu" />
        <!-- End Dessert -->
        
        <!-- Shopping cart -->
        <ShoppingCart />
    </v-card>
</template>

<script>
import axios from 'axios';
import FoodList from '@/components/user/FoodList'
import DrinkList from '@/components/user/DrinkList'
import DessertList from '@/components/user/DessertList'
import ShoppingCart from '@/components/user/shoppingcart/ShoppingCart'

import FoodStore from '@/store/FoodStore.js'
import DrinkStore from '@/store/DrinkStore.js'
import DessertStore from '@/store/DessertStore.js'

export default {
    name: 'Home',
    data() {
        return {
            foodmenu: [],
            drinkmenu: [],
            dessertmenu: [],
            dialog: false
        }
    },
    components: {
        FoodList,
        DrinkList,
        DessertList,
        ShoppingCart
    },
    created() {

        const webAPI_foodinfo = "https://localhost:5001/foodinfo"
        const webAPI_drinkinfo = "https://localhost:5001/drinkinfo"
        const webAPI_dessertinfo = "https://localhost:5001/dessertinfo"

        // Get from API
        axios.get(webAPI_foodinfo).then( response => {
            this.foodmenu = response.data;
            FoodStore.setFood(response.data);
        })

        // Get from API
        axios.get(webAPI_drinkinfo).then( response => {
            this.drinkmenu = response.data;
            DrinkStore.setDrink(response.data);
        })
        
        // Get from API
        axios.get(webAPI_dessertinfo).then( response => {
            this.dessertmenu = response.data;
            DessertStore.setDessert(response.data);
        })
    },
    methods: {
        // Search methods for each menu type
        searchFoodByCategory() {
            const search = document.getElementById("searchFood").value;

            axios.get(`https://localhost:5001/foodinfo/${search}`).then(response => {
                this.foodmenu = response.data;
            })
        },
        resetFoodSearch() {
            this.foodmenu = FoodStore.getFood();
        },
        searchDrinksByCategory() {
            const search = document.getElementById("searchDrinks").value;

            axios.get(`https://localhost:5001/drinkinfo/${search}`).then(response => {
                this.drinkmenu = response.data;
            })
        },
        resetDrinksSearch() {
            this.drinkmenu = DrinkStore.getDrink();
        },
        searchDessertByCategory() {
            const search = document.getElementById("searchDessert").value;

            axios.get(`https://localhost:5001/dessertinfo/${search}`).then(response => {
                this.dessertmenu = response.data;
            })
        },
        resetDessertSearch() {
            this.dessertmenu = DessertStore.getDessert();
        }
    }
}
</script>