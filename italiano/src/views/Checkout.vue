<template>
    <v-row>
        <v-spacer class="hidden-xs-only"></v-spacer>
            <v-col 
                cols="12" 
                lg="8" 
                md="10" 
                sm="8"
            >
                <v-card flat>
                    <div v-if="!finishCheckout">
                        <v-card-title class="justify-center">Your order</v-card-title>

                        <ShoppingCartItem 
                            :orders="orders"
                            :total="total"
                            :totalItems="totalItems"
                        />

                        <!-- Checkout form for userinput -->
                        <CheckoutForm />
                        <v-btn 
                            dark
                            @click="checkOut">Checkout</v-btn>
                    </div>

                    <CheckoutSummary 
                        v-else
                        :orders="orders"
                        :customer="customer"
                        :total="total"
                        :totalItems="totalItems"
                    />
                </v-card>
            </v-col>
        <v-spacer class="hidden-xs-only"></v-spacer>
    </v-row>
</template>

<script>
import OrderStore from '@/store/OrderStore.js'
import ShoppingCartItem from '@/components/user/shoppingcart/ShoppingCartItem'
import CheckoutForm from '@/components/user/checkout/CheckoutForm'
import CheckoutSummary from '@/components/user/checkout/CheckoutSummary'

export default {
    name: "Checkout",
    components: {
        ShoppingCartItem,
        CheckoutForm,
        CheckoutSummary
    },
    data() {
        return {
            orders: [],
            total: 0,
            totalItems: 0,
            finishCheckout: false
        }
    },
    created() {
        this.orders = OrderStore.getOrder();
        this.total = OrderStore.getTotal();
        this.totalItems = OrderStore.getTotalItems();
    },
    methods: {
        checkOut() {
            this.customer = OrderStore.getCustomer();
            this.finishCheckout = true;
        },
        clearCart() {
            window.location.href="/";
            OrderStore.clearStore();
        }
    }
}
</script>