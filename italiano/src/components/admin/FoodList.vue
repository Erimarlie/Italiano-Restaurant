<template>
    <v-simple-table>
        <template v-slot:default>
            <thead>
                <tr>
                    <th class="text-left">ID</th>
                    <th class="text-left">Name</th>
                    <th class="text-left">Category</th>
                    <th class="text-left">Price</th>
                    <th class="text-left">Edit</th>
                    <th class="text-left">Delete</th>
                </tr>
            </thead>
            <tbody>
                <!-- Table rows from admin/FoodItem.vue -->
                <FoodItem 
                    v-for="item in foodmenu" 
                    :key="item.foodId"
                    :food-id="item.foodId"
                    :name="item.name"
                    :category="item.category"
                    :description="item.description"
                    :price="item.price"
                />
            </tbody>
        </template>
    </v-simple-table>
</template>

<script>
import FoodItem from '@/components/admin/FoodItem'

export default {
    name: "FoodList",
    props: {
        foodmenu: Array
    },
    components: {
        FoodItem
    },
}
</script>