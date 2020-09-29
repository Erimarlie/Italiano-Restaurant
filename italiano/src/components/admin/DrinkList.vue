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
            <!-- Table rows from admin/DrinkItem.vue -->
            <DrinkItem 
                v-for="item in drinkmenu" 
                :key="item.drinkId"
                :drink-id="item.drinkId"
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
import DrinkItem from '@/components/admin/DrinkItem'

export default {
    name: "DrinkList",
    props: {
        drinkmenu: Array
    },
    components: {
        DrinkItem
    },
}
</script>