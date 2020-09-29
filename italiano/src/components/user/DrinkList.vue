<template>
    <div>
        <!-- Drink items -->
        <v-row>
            <v-col 
                cols="12" 
                md="6" 
                lg="4" 
                sm="6" 
                v-for="item in drinkmenu" 
                :key="item.drinkId"
            >

                <DrinkItem
                    :drink-id="item.drinkId"
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
        <!-- End Drink items -->
    </div>
</template>

<script>
import DrinkItem from '@/components/user/DrinkItem'

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