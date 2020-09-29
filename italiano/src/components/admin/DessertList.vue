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
                <DessertItem 
                    v-for="item in dessertmenu" 
                    :key="item.dessertId"
                    :dessert-id="item.dessertId"
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
import DessertItem from '@/components/admin/DessertItem'

export default {
    name: "DessertList",
    props: {
        dessertmenu: Array
    },
    components: {
        DessertItem
    },
}
</script>