<template>
    <div class="mt-12">
        <v-row>
            <v-col 
                cols="12" 
                md="6" 
                lg="4" 
                sm="6" 
                v-for="item in foodmenu" 
                :key="item.foodId"
            >

                <FoodItem
                    :food-id="item.foodId"
                    :name="item.name"
                    :description="item.description"
                    :category="item.category"
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
import FoodItem from '@/components/user/FoodItem'

export default {
    name: "FoodList",
    props: {
        foodmenu: Array
    },
    components: {
        FoodItem
    }
}
</script>