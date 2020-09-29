<template>
    <v-simple-table>
        <template v-slot:default>
            <thead>
                <tr>
                    <th class="text-center">Name</th>
                    <th class="text-center">Price</th>
                </tr>
            </thead>
            <tbody>
                <tr 
                    v-for="(item, index) in orders"
                    :key="index"
                >
                    <td class="text-center text">{{ item.name }}</td>
                    <td class="text-center">{{ item.price }}</td>
                </tr>
            </tbody>

            <thead>
                <tr>
                    <th class="text-center">Total items</th>
                    <th class="text-center">Total amount</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="text-center font-weight-bold">{{ totalItems }}</td>
                    <td class="text-center font-weight-bold">Kr {{ total }}</td>
                </tr>
            </tbody>
        </template>
    </v-simple-table>
</template>

<script>
export default {
    name: "ShoppingCartItem",
    props: {
        orders: Array,
        total: Number,
        totalItems: Number
    }
}
</script>