<template>
    <tr :key="foodId">
        <td class="text-left">{{ foodId }}</td>
        <td class="text-left">{{ name }}</td>
        <td class="text-left">{{ category }}</td>
        <td class="text-left">{{ price }}</td>
        <td class="text-left">
            <v-btn 
                small 
                :to="`/edit/${categoryType}/${foodId}`"
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
import FoodStore from '@/store/FoodStore.js'

export default {
    name: "FoodItem",
    props: {
        foodId: Number,
        name: String,
        category: String,
        description: String,
        price: Number
    },
    data() {
        return {
            btnDeleted: "Delete",
            btnColor: "",
            categoryType: "food"
        }
    },
    methods: {
        deleteItem() {
            this.btnDeleted = "Deleted";
            this.btnColor = "red"
            FoodStore.deleteFood(this.foodId);
        }
    }
}
</script>