<template>
    <v-app>
        <Navigation />
        <v-content>
            <v-container>
            
            <router-view/>
            </v-container>
        </v-content>
    </v-app>
</template>

<script>
import Navigation from '@/layout/Navigation'

export default {
    components: {
        Navigation
    }
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
