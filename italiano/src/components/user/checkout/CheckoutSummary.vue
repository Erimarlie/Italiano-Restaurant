<template>
    <v-card flat>
        <v-card-title class="justify-center headline">Your order is in the making!</v-card-title>

        <ShoppingCartItem 
            :orders="orders"
            :total="total"
            :totalItems="totalItems"
        />

        <v-card-title 
            class="justify-center headline"
        >Your order will be delivered to
        </v-card-title>

        <v-card class="mx-12">
            <v-card-subtitle class="text-left">
            Name: {{customer.firstName}} {{customer.lastName}}<br>
            Address: {{customer.address}}<br> 
            Postcode: {{customer.postcode}}<br><br>
            Comments: {{customer.comments}}
            </v-card-subtitle>
        </v-card>

        <v-card-title class="justify-center">
            Thank you for ordering from <br>
            Italiano<br>
            We hope you enjoy it!
        </v-card-title>
        <v-btn
            dark
            @click="clearCart"
        >Home</v-btn>
    </v-card>
</template>

<script>
import ShoppingCartItem from '@/components/user/shoppingcart/ShoppingCartItem'
import OrderStore from '@/store/OrderStore.js'

export default {
    name: "CheckoutSummary",
    components: {
        ShoppingCartItem
    },
    props: {
        orders: Array,
        customer: Array,
        total: Number,
        totalItems: Number
    },
    methods: {
        clearCart() {
            OrderStore.clearStore();

            // I had to use this because having to="/" on v-btn
            // didn't trigger the clearStore function
            window.location.href="/";
        }
    }
}
</script>