<template>
    <tr :key="dessertId">
        <td class="text-left">{{ dessertId }}</td>
        <td class="text-left">{{ name }}</td>
        <td class="text-left">{{ category }}</td>
        <td class="text-left">{{ price }}</td>
        <td class="text-left">
            <v-btn 
                small 
                :to="`/edit/${categoryType}/${dessertId}`"
            >Edit</v-btn>
        </td>
        <td class="text-left">
            <v-btn 
                small 
                @click="deleteItem" 
                :color="btnColor"
            >{{ btnDeleted }}</v-btn>
        </td>
    </tr>
</template>

<script>
import DessertStore from '@/store/DessertStore.js'

export default {
    name: "DessertItem",
    props: {
        dessertId: Number,
        name: String,
        category: String,
        description: String,
        price: Number
    },
    data() {
        return {
            btnDeleted: "Delete",
            btnColor: "",
            categoryType: "dessert"
        }
    },
    methods: {
        deleteItem() {
            this.btnDeleted = "Deleted";
            this.btnColor = "red"
            DessertStore.deleteDessert(this.dessertId);
        }
    }
}
</script>