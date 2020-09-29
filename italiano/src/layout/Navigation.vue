<template>
    <nav>
        <!-- Large sized navigation bar -->
        <v-app-bar 
            app 
            dark 
            fixed
        >
            <v-app-bar-nav-icon 
                class="white--text hidden-sm-and-up" 
                @click="drawer = true"
            ></v-app-bar-nav-icon>

            <div class="hidden-xs-only">
                <v-btn to="/">Home</v-btn>
                <v-btn to="/admin">Administrator</v-btn>
            </div>
        </v-app-bar>

        <!-- Small sized navigation bar -->
        <!-- Removing absolute on navigation drawer was the only way -->
        <!-- to fix the menu buttons disappearing on scrolling -->
        <v-navigation-drawer 
            v-model="drawer" 
            fixed 
            temporary 
            dark
        >
            <v-list nav>
                <v-list-item>
                    <v-btn block to="/">Home</v-btn>
                </v-list-item>

                <v-list-item>
                    <v-btn block to="/admin">Administrator</v-btn>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>
    </nav>
</template>

<script>

export default {
    name: "Navigation",
    data() {
        return {
            drawer: false
        }
    }
}
</script>