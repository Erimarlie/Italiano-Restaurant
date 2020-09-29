<template>
    <div>
        <!-- Food items -->
        <v-row>
            <v-col 
                cols="12" 
                md="6" 
                lg="4" 
                sm="6" 
                v-for="item in dessertmenu" 
                :key="item.dessertId"
            >

                <DessertItem
                    :dessert-id="item.dessertId"
                    :name="item.name"
                    :category="item.category"
                    :description="item.description"
                    :price="item.price"
                    :imgSrc="item.imgSrc"
                    :avgRating="item.avgRating"
                    :totalVotes="item.totalVotes"
                />
            </v-col>
        </v-row>
        <!-- End Food items -->
    </div>
</template>

<script>
import DessertItem from '@/components/user/DessertItem'

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