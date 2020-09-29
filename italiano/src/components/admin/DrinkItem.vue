<template>
    <tr :key="drinkId">
        <td class="text-left">{{ drinkId }}</td>
        <td class="text-left">{{ name }}</td>
        <td class="text-left">{{ category }}</td>
        <td class="text-left">{{ price }}</td>
        <td class="text-left">
            <v-btn 
                small 
                :to="`/edit/${categoryType}/${drinkId}`"
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
import DrinkStore from '@/store/DrinkStore.js'

export default {
    name: "DrinkItem",
    props: {
        drinkId: Number,
        name: String,
        category: String,
        description: String,
        price: Number
    },
    data() {
        return {
            btnDeleted: "Delete",
            btnColor: "",
            categoryType: "drink"
        }
    },
    methods: {
        deleteItem() {
            this.btnDeleted = "Deleted";
            this.btnColor = "red"
            DrinkStore.deleteDrink(this.drinkId);
        }
    }
}
</script>