<template>
    <v-row>
        <v-spacer class="hidden-sm-and-down"></v-spacer>
            <v-col 
                cols="12" 
                lg="10" 
                md="10" 
                sm="12"
            >
                <v-card flat>
                    <v-card-title 
                        class="justify-center mt-5"
                        style="font-size: 35px"
                    >Administrator page</v-card-title>
                    <v-card-subtitle
                        class="ma-2"
                        style="font-size: 20px"
                    >Here you can add, delete and edit items in the database</v-card-subtitle>
                    
                    <v-divider class="mt-8 mb-10"></v-divider>

                    <v-toolbar flat>
                        <v-spacer></v-spacer>
                        <v-toolbar-title>Food</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <v-btn to="/add/food">Add food</v-btn>
                    </v-toolbar>

                    <FoodList :foodmenu="foodmenu" />
                    <v-divider class="mb-10"></v-divider>

                    <v-toolbar flat>
                        <v-spacer></v-spacer>
                        <v-toolbar-title>Drinks</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <v-btn to="/add/drink">Add drinks</v-btn>
                    </v-toolbar>

                    <DrinkList :drinkmenu="drinkmenu" />
                    <v-divider class="mb-10"></v-divider>

                    <v-toolbar flat>
                        <v-spacer></v-spacer>
                        <v-toolbar-title>Desserts</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <v-btn to="/add/dessert">Add dessert</v-btn>
                    </v-toolbar>

                    <DessertList :dessertmenu="dessertmenu" />
                </v-card>
            </v-col>
        <v-spacer class="hidden-sm-and-down"></v-spacer>
    </v-row>
</template>

<script>
// import axios from 'axios'
import FoodStore from '@/store/FoodStore.js'
import DrinkStore from '@/store/DrinkStore.js'
import DessertStore from '@/store/DessertStore.js'

import FoodList from '@/components/admin/FoodList'
import DrinkList from '@/components/admin/DrinkList'
import DessertList from '@/components/admin/DessertList'

export default {
    name: "Admin",
    data() {
        return {
            foodmenu: [],
            drinkmenu: [],
            dessertmenu: []
        }
    },
    components: {
        FoodList,
        DrinkList,
        DessertList
    },
    created() {
        this.foodmenu = FoodStore.getFood();
        this.drinkmenu = DrinkStore.getDrink();
        this.dessertmenu = DessertStore.getDessert();
    }
}
</script>
