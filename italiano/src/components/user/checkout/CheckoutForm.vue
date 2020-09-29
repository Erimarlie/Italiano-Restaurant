<template>
    <!-- Used for filling in customer information on checkout -->
    <v-form>
        <v-text-field
            v-model="customer.firstName"
            label="First name"
            required
        ></v-text-field>

        <v-text-field
            v-model="customer.lastName"
            label="Last name"
            required
        ></v-text-field>

        <v-text-field
            v-model="customer.address"
            label="Address"
            required
        ></v-text-field>

        <v-textarea
            v-model="customer.postcode"
            class="mb-5"
            label="Postcode"
            auto-grow
            clearable
            rows="1"
            required
        ></v-textarea>

        <v-textarea
            v-model="customer.comments"
            class="mb-5"
            label="Additional comments"
            auto-grow
            clearable
            rows="1"
            required
        ></v-textarea>
    </v-form>
</template>

<script>
import OrderStore from '@/store/OrderStore.js'

export default {
    name: "CheckoutForm",
    data() {
        return {
            customer: {}
        }
    },
    created() {
        this.customer = OrderStore.getCustomer();
    }
}
</script>