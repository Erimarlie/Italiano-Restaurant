<template>
    <v-card height="100%" :key="drinkId">
        <v-row>
            <v-col>
                <v-img 
                    contain 
                    :src="`https://localhost:5001/images/${imgSrc}`" 
                    height="200px" 
                />

                <v-card-title 
                    class="headline justify-center"
                >{{ name }}</v-card-title>

                <v-card-subtitle 
                    class="text--primary"
                >{{ category }}<br>Kr {{price}},-</v-card-subtitle>

                <v-rating
                    dense
                    hover
                    class="ma-1"
                    :value="avgRating"
                    @input="drinkRating"
                ></v-rating>
                <span>({{votes}})</span>

                <v-card-text 
                    class="text--primary text--accent-4"
                >{{description}}</v-card-text>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn 
                        dark
                        right 
                        @click="addToCart"
                    >Add to cart</v-btn>
                </v-card-actions>
            </v-col>
        </v-row>
    </v-card>
</template>

<script>
import OrderStore from '@/store/OrderStore.js'
import DrinkStore from '@/store/DrinkStore.js'

export default {
    name: "DrinkItem",
    props: {
        drinkId: Number,
        name: String,
        description: String,
        category: String,
        price: Number,
        imgSrc: String,
        avgRating: Number,
        totalVotes: Number
    },
    data() {
        return {
            votes: this.totalVotes,
        }
    },
    methods: {
        drinkRating(event) {
            DrinkStore.setDrinkRating(event, this.drinkId);
            this.votes = this.totalVotes + 1;
        },
        addToCart() {
            let drink = DrinkStore.getDrinkById(this.drinkId);
            OrderStore.setOrder(drink);
        }
    },
}
</script>