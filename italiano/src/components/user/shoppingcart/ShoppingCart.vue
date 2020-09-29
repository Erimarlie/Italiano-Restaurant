<template>
    <div>
        <v-btn
            fab
            dark
            bottom
            sticky
            right
            fixed
            @click="dialog = !dialog; getSummary()"
        >
            <v-icon>mdi-cart</v-icon>
        </v-btn>

        <v-dialog 
            v-model="dialog" 
            max-width="70%"
        >
            <v-card>
                <v-card-title 
                    class="justify-center headline grey lighten-2"
                    primary-title
                >Shopping cart</v-card-title>
                
                <ShoppingCartItem 
                    :orders="orders"
                    :total="total"
                    :totalItems="totalItems"
                />

                <v-card-actions>
                    <v-btn 
                        dark
                        block
                        to="/checkout"
                    >Checkout</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
import OrderStore from '@/store/OrderStore.js'
import ShoppingCartItem from '@/components/user/shoppingcart/ShoppingCartItem'

export default {
    name: "ShoppingCart",
    components: {
        ShoppingCartItem
    },
    data() {
        return {
            dialog: false,
            orders: [],
            total: 0,
            totalItems: 0
        }
    },
    created() {
        this.orders = OrderStore.getOrder();
        this.total = OrderStore.getTotal();
    },
    methods: {
        getSummary() {
            this.total = OrderStore.getTotal();
            this.totalItems = OrderStore.getTotalItems();
        }
    }
}
</script>

<style>

</style>