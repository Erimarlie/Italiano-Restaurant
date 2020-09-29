import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Admin from '../views/Admin.vue'
import Edit from '../views/Edit.vue'
import Add from '../views/Add.vue'
import Checkout from '../views/Checkout.vue'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/admin',
        name: 'Admin',
        component: Admin
    },
    {
        path: '/edit/:category/:id',
        name: 'Edit',
        component: Edit
    },
    {
        path: '/add/:category',
        name: 'Add',
        component: Add
    },
    {
        path: '/checkout',
        name: "Checkout",
        component: Checkout
    }
]

const router = new VueRouter({
  routes
})

export default router
