import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { HomeView } from '../views';

const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'member',component: () => import('../layout/Empty.vue'), children: [ 
    { path:'/', component:HomeView },
  ] },
]

const router = createRouter({
  history: createWebHistory(""),
  routes
})

export default router
